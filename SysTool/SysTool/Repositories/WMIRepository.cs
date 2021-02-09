using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using SysTool.Attributes;
using SysTool.Extensions;
using SysTool.Models.WMI;

namespace SysTool.Repositories {
    public class WMIRepository {

        #region Private Properties
        private ManagementScope Scope { get; set; }
        #endregion

        #region Constructors
        public WMIRepository(string path, ConnectionOptions options = default)
            : this(new ManagementScope(path, options ?? new ConnectionOptions().UseDefault())) {
        }
        public WMIRepository(ManagementScope scope) {
            this.Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }
        #endregion

        #region Repository Methods
        public Win32_Process? GetExplorerProcess() {
            var name = "explorer.exe";
            return this.GetProcess(name);
        }
        public Win32_Process? GetLogonUIProcess() {
            var name = "logonui.exe";
            return this.GetProcess(name);
        }
        public Win32_Process? GetProcess(string name) {
            var condition = $"Name='{name}'";
            return this.GetOne<Win32_Process>(condition: condition);
        }
        public Win32_PingStatus? GetPingStatus(string address) {
            var condition = $"Address='{address}'";
            return this.GetOne<Win32_PingStatus>(condition: condition);
        }
        #endregion

        #region Generic Methods
        public T? GetOne<T>(string? className = default, string? condition = default, EnumerationOptions ? options = default, SelectQuery? query = default)
            where T : WMIBase, new() {
            (query, options) = WMIRepository.GetQueryParams<T>(className, condition, options, query);
            return this.Query<T>(query, options).SingleOrDefault();
        }
        public async Task<T?> GetOneAsync<T>(string? className = default, string? condition = default, EnumerationOptions? options = default, SelectQuery? query = default)
            where T : WMIBase, new() {
            (query, options) = WMIRepository.GetQueryParams<T>(className, condition, options, query);
            return (await this.QueryAsync<T>(query, options)).SingleOrDefault();
        }
        public List<T> Get<T>(string? className = default, string? condition = default, EnumerationOptions? options = default, SelectQuery? query = default)
            where T : WMIBase, new() {
            (query, options) = WMIRepository.GetQueryParams<T>(className, condition, options, query);
            return this.Query<T>(query, options);
        }
        public Task<List<T>> GetAsync<T>(string? className = default, string? condition = default, EnumerationOptions? options = default, SelectQuery? query = default)
            where T : WMIBase, new() {
            (query, options) = WMIRepository.GetQueryParams<T>(className, condition, options, query);
            return this.QueryAsync<T>(query, options);
        }
        #endregion

        #region Static Methods
        private static (SelectQuery, EnumerationOptions) GetQueryParams<T>(string? className, string? condition, EnumerationOptions? options, SelectQuery? query) {
            className ??= typeof(T).Name;
            options ??= new EnumerationOptions().UseDefault();
            query ??= new SelectQuery(className, condition);
            return (query, options);
        }
        #endregion

        #region Private Methods
        private List<T> Query<T>(SelectQuery query, EnumerationOptions options)
            where T : WMIBase, new() {
            var instances = new List<T>();
            using (var searcher = new ManagementObjectSearcher(this.Scope, query, options)) {
                foreach (ManagementObject @object in searcher.Get()) {
                    using (@object) {
                        @object.Get();
                        var instance = NewInstance<T>(@object);
                        instances.Add(instance);
                    }
                }
            }
            return instances;
        }
        private Task<List<T>> QueryAsync<T>(SelectQuery query, EnumerationOptions options)
            where T : WMIBase, new() {
            var tcs = new TaskCompletionSource<List<T>>();
            var instances = new List<T>();

            var observer = new ManagementOperationObserver();
            observer.ObjectReady += new ObjectReadyEventHandler((s, e) => {
                using var @object = e.NewObject as ManagementObject;
                var instance = NewInstance<T>(@object!);
                instances.Add(instance);
            });
            observer.Completed += new CompletedEventHandler((s, e) => {
                tcs.TrySetResult(instances);
            });

            using var searcher = new ManagementObjectSearcher(this.Scope, query, options);
            searcher.Get(observer);

            return tcs.Task;
        }
        private static T NewInstance<T>(ManagementObject @object)
            where T : WMIBase, new() {
            var instance = new T() { ManagementObject = @object };
            var properties = typeof(T).GetWritableProperties()
                .Where(p => Attribute.IsDefined(p, typeof(WMIPropertyAttribute)));

            foreach (var property in properties) {
                var name = property.Name;
                var value = @object.GetPropertyValue(name);
                property.SetValue(instance, value);
            }

            return instance;
        }
        #endregion
    }
}