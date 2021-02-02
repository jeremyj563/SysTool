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

        #region Public Methods
        public List<T> Get<T>(string className = default, string condition = default)
            where T : WMIBase, new() {
            if (className == default) className = typeof(T).Name;
            return this.Query<T>(className, condition);
        }
        public Task<List<T>> GetAsync<T>(string className = default, string condition = default)
            where T : WMIBase, new() {
            if (className == default) className = typeof(T).Name;
            return this.QueryAsync<T>(className, condition);
        }
        #endregion

        #region Private Methods
        private List<T> Query<T>(string className, string condition)
            where T : WMIBase, new() {
            var instances = new List<T>();
            var query = new SelectQuery(className, condition);

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
        private Task<List<T>> QueryAsync<T>(string className, string condition)
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
            
            var query = new SelectQuery(className, condition);
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