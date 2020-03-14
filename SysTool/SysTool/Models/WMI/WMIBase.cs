using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
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
            if (ConfirmWritePermissions())
            {
                UpdatePropertyValues();

                var putOptions = new PutOptions();
                putOptions.UseDefaultUpdateOptions(this.writableProperties);
                this.ManagementObject.Put(putOptions);
            }
        }

        private bool ConfirmWritePermissions()
        {
            //var dn = this.ManagementObject.GetPropertyValue(nameof(Property.DS_distinguishedName));
            //var account = new System.Security.Principal.NTAccount("JERLYD", "jmj");
            //var targetType = account.GetType();
            //var accountSID = account.Translate(targetType);
            ////var path = $"ActiveDirectory:://RootDSE/{dn}";
            //var adSecurity = new System.DirectoryServices.ActiveDirectorySecurity();
            //var rules = adSecurity.GetAccessRules(true, true, targetType);
            this.ManagementObject.Get();

            foreach (var p in this.ManagementObject.Properties)
            {
                var qualifiers = p.Qualifiers;
                foreach (var q in qualifiers)
                {
                    Debug.WriteLine($"{p.Name} - {q.Name}: {q.Value}");
                }
            }

            return false;
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

        private enum Property
        {
            DS_distinguishedName,
            DS_securityIdentifier
        }
    }
}
