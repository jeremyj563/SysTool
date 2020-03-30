using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using SysTool.Attributes;
using SysTool.Extensions;
using SysTool.Forms;

namespace SysTool.Models.WMI
{
    public abstract class WMIBase
    {
        public ManagementObject ManagementObject { get; set; }
        private IEnumerable<PropertyInfo> WritableProperties { get; }

        public WMIBase()
        {
            this.WritableProperties = this.GetType()
                .GetWritableProperties<WMIPropertyAttribute, WritableAttribute>();
        }

        public void Save()
        {
            if (!this.WritableProperties.Any()) return;

            UpdatePropertyValues();

            var options = new PutOptions();
            options.UseDefaultUpdateOptions(this.WritableProperties);
            Save(options);
        }

        private void UpdatePropertyValues()
        {
            foreach (var property in this.WritableProperties)
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
                Notification.Show(GetType(), ex);
            }
        }
    }
}
