using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using SysTool.Attributes;
using SysTool.Extensions;
using SysTool.Models.WMI;

namespace SysTool.Repositories {
    public class WMIRepository {
        private ManagementScope Scope { get; set; }

        public WMIRepository(string scope) {
            this.Scope = new ManagementScope(scope);
        }

        public List<T> Get<T>(string className = default, string condition = default)
            where T : WMIBase, new() {
            if (className == default) className = typeof(T).Name;
            return this.Query<T>(className, condition);
        }

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
    }
}