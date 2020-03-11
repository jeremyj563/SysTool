using System.Linq;
using System.Management;
using SysTool.Extensions;

namespace SysTool.Models.WMI
{
    public abstract class WMIBase<T>
    {
        public ManagementObject ManagementObject { get; set; }
        private string[] properties { get { return typeof(T).GetPropertyNames(); } }

        public void Save()
        {
            UpdateManagementObjectProperties();
            
            var putOptions = NewPutOptions();
            this.ManagementObject.Put(putOptions);
        }

        private void UpdateManagementObjectProperties()
        {
            typeof(T).GetPublicInstanceProperties()
                .Where(p => p.CanRead)
                .ToList()
                .ForEach(p => this.ManagementObject.SetPropertyValue(p.Name, p.GetValue(this, null)));
        }

        private PutOptions NewPutOptions()
        {
            var context = NewPutOptionsContext();
            var putOptions = new PutOptions()
            {
                Context = context,
                UseAmendedQualifiers = false,
                Type = PutType.UpdateOnly
            };
            return putOptions;
        }

        private ManagementNamedValueCollection NewPutOptionsContext()
        {
            var context = new ManagementNamedValueCollection();
            context.Add("__PUT_EXT_PROPERTIES", this.properties);
            context.Add("__PUT_EXTENSIONS", true);
            context.Add("__PUT_EXT_CLIENT_REQUEST", true);
            return context;
        }
    }
}
