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
        public WMIRepository(string path)
            : this(path, null) {
        }
        public WMIRepository(string path, ConnectionOptions options) {
            this.Scope = new ManagementScope(path, options);
        }
        public WMIRepository(ManagementScope scope) {
            this.Scope = scope;
        }
        #endregion

        #region Repository Methods
        public Task<Win32_PingStatus> GetPingStatusAsync(string address) {
            var condition = $"Address='{address}'";
            return this.GetOneAsync<Win32_PingStatus>(condition);
        }
        public Task<Win32_Process> GetProcessAsync(string name) {
            var condition = $"Name='{name}'";
            return this.GetOneAsync<Win32_Process>(condition);
        }
        #endregion

        #region Generic Methods
        public T GetOne<T>(string condition)
            where T : WMIBase, new() {
            if (string.IsNullOrWhiteSpace(condition)) return default;
            return this.GetOne<T>(default, condition);
        }
        public Task<T> GetOneAsync<T>(string condition)
            where T : WMIBase, new() {
            if (string.IsNullOrWhiteSpace(condition)) return default;
            return this.GetOneAsync<T>(default, condition);
        }
        public T GetOne<T>(string className = default, string condition = default)
            where T : WMIBase, new() {
            if (className == default) className = typeof(T).Name;
            var query = new SelectQuery(className, condition);
            return this.Query<T>(query).SingleOrDefault();
        }
        public async Task<T> GetOneAsync<T>(string className = default, string condition = default)
            where T : WMIBase, new() {
            if (className == default) className = typeof(T).Name;
            var query = new SelectQuery(className, condition);
            return (await this.QueryAsync<T>(query)).SingleOrDefault();
        }
        public List<T> Get<T>(string className = default, string condition = default)
            where T : WMIBase, new() {
            if (className == default) className = typeof(T).Name;
            var query = new SelectQuery(className, condition);
            return this.Query<T>(query);
        }
        public Task<List<T>> GetAsync<T>(string className = default, string condition = default)
            where T : WMIBase, new() {
            if (className == default) className = typeof(T).Name;
            var query = new SelectQuery(className, condition);
            return this.QueryAsync<T>(query);
        }
        #endregion

        #region Private Methods
        private List<T> Query<T>(SelectQuery query)
            where T : WMIBase, new() {
            var instances = new List<T>();
            using (var searcher = new ManagementObjectSearcher(this.Scope, query)) {
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
        private Task<List<T>> QueryAsync<T>(SelectQuery query)
            where T : WMIBase, new() {
            var tcs = new TaskCompletionSource<List<T>>();
            var instances = new List<T>();

            var observer = new ManagementOperationObserver();
            observer.ObjectReady += new ObjectReadyEventHandler((s, e) => {
                using var @object = e.NewObject as ManagementObject;
                var instance = NewInstance<T>(@object);
                instances.Add(instance);
            });
            observer.Completed += new CompletedEventHandler((s, e) => {
                tcs.TrySetResult(instances);
            });
            
            using var searcher = new ManagementObjectSearcher(this.Scope, query);
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