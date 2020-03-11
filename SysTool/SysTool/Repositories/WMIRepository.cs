using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

            var selectedProperties = NewSelectedProperties();
            var query = new SelectQuery(className, condition, selectedProperties);

            using (var searcher = new ManagementObjectSearcher(this.scope, query))
            {
                searcher.Get()
                    .OfType<ManagementObject>()
                    .ToList()
                    .ForEach(o => instances.Add(NewInstance(o)));
            }

            return instances.AsQueryable();
        }

        private string[] NewSelectedProperties()
        {
            return typeof(T)
                .GetPublicInstanceProperties()
                .Select(p => p.Name)
                .ToArray();
        }

        private T NewInstance(ManagementObject @object)
        {
            var instance = new T();
            instance.ManagementObject = @object;

            typeof(T).GetPublicInstanceProperties()
                .Where(p => p.CanWrite)
                .ToList()
                .ForEach(p => p.SetValue(instance, @object.Properties[p.Name].Value));
            
            return instance;
        }
    }
}