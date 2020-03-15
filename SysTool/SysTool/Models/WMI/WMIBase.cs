using System.Collections.Generic;
using System.Management;
using System.Reflection;
using SysTool.Extensions;
using SysTool.Forms;

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
            UpdatePropertyValues();

            var options = new PutOptions();
            options.UseDefaultUpdateOptions(this.writableProperties);
            Save(options);
        }

        private void UpdatePropertyValues()
        {
            foreach (var property in this.writableProperties)
            {
                var name = property.Name;
                var value = property.GetValue(this);
                this.ManagementObject.SetPropertyValue(name, value);
            }
        }

        private void Save(PutOptions options)
        {
            try
            {
                using (this.ManagementObject)
                {
                    this.ManagementObject.Put(options);
                }
            }
            catch (ManagementException ex)
            {
                Notification.Show(GetType().BaseType, MethodBase.GetCurrentMethod(), ex.Message);
            }
        }
    }
}
