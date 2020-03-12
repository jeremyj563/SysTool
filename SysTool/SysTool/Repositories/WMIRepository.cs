using System.Collections.Generic;
using System.Linq;
using System.Management;
using SysTool.Extensions;
using SysTool.Models.WMI;

namespace SysTool.Repositories
{
    public class WMIRepository<T> : IRepository<T>
        where T : WMIBase<T>, new()
    {
        private ManagementScope scope { get; set; }

        public WMIRepository(string scope)
        {
            this.scope = new ManagementScope(scope);
        }

        public IQueryable<T> Get(string className, string condition = default)
        {
            return this.Query(className, condition);
        }

        private IQueryable<T> Query(string className, string condition)
        {
            var instances = new List<T>();
            var query = new SelectQuery(className, condition);

            using (var searcher = new ManagementObjectSearcher(this.scope, query))
            {
                foreach (ManagementObject @object in searcher.Get())
                {
                    var instance = NewInstance(@object);
                    instances.Add(instance);
                }
            }

            return instances.AsQueryable();
        }

        private T NewInstance(ManagementObject @object)
        {
            var instance = new T() { ManagementObject = @object };

            foreach (var property in typeof(T).GetWritableProperties())
            {
                var name = property.Name;
                var value = @object.Properties[name].Value;
                property.SetValue(instance, value);
            }
            
            return instance;
        }
    }
}