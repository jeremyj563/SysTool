using System.Collections.Generic;
using System.Management;
using System.Reflection;
using SysTool.Extensions;

namespace SysTool.Models.WMI
{
    public abstract class WMIBase<T>
    {
        public ManagementObject ManagementObject { get; set; }
        private IEnumerable<PropertyInfo> writableProperties { get; }

        public WMIBase()
        {
            this.writableProperties = typeof(T).GetWritableProperties();
        }

        public void Save()
        {
            UpdatetProperties();

            var putOptions = new PutOptions();
            putOptions.UseDefaultUpdateOptions(this.writableProperties);
            this.ManagementObject.Put(putOptions);
        }

        private void UpdatetProperties()
        {
            foreach (var property in this.writableProperties)
            {
                var name = property.Name;
                var value = property.GetValue(this);
                this.ManagementObject.SetPropertyValue(name, value);
            }
        }
    }
}
