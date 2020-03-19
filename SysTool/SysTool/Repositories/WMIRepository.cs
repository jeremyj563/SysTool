using System.Collections.Generic;
using System.Linq;
using System.Management;
using SysTool.Attributes;
using SysTool.Extensions;
using SysTool.Models;
using SysTool.Models.WMI;

namespace SysTool.Repositories
{
    public class WMIRepository
    {
        private ManagementScope scope { get; set; }

        public WMIRepository(string scope)
        {
            this.scope = new ManagementScope(scope);
        }

        public IQueryable<T> Get<T>(string className, string condition = default)
            where T : WMIBase, IDataUnit, new()
        {
            return this.Query<T>(className, condition);
        }

        private IQueryable<T> Query<T>(string className, string condition)
            where T : WMIBase, IDataUnit, new()
        {
            var instances = new List<T>();
            var query = new SelectQuery(className, condition);

            using (var searcher = new ManagementObjectSearcher(this.scope, query))
            {
                foreach (ManagementObject @object in searcher.Get())
                {
                    using (@object)
                    {
                        @object.Get();
                        var instance = NewInstance<T>(@object);
                        instances.Add(instance);
                    }
                }
            }

            return instances.AsQueryable();
        }

        private static T NewInstance<T>(ManagementObject @object)
            where T : WMIBase, IDataUnit, new()
        {
            var instance = new T() { ManagementObject = @object };

            foreach (var property in typeof(T).GetWritableProperties<WMIPropertyAttribute>())
            {
                var name = property.Name;
                var value = @object.Properties[name].Value;
                property.SetValue(instance, value);
            }
            
            return instance;
        }
    }
}