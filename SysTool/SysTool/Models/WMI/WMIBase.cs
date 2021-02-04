using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using SysTool.Attributes;
using SysTool.Extensions;
using SysTool.Forms;

namespace SysTool.Models.WMI {
    public abstract class WMIBase {

        #region Public Properties
        public ManagementObject ManagementObject { get; set; }
        #endregion

        #region Private Properties
        private IEnumerable<PropertyInfo> WritableProperties { get; }
        #endregion

        #region Constructors
        public WMIBase() {
            this.WritableProperties = this.GetType()
                .GetWritableProperties()
                .Where(p => Attribute.IsDefined(p, typeof(WMIPropertyAttribute)))
                .Where(p => Attribute.IsDefined(p, typeof(WMIWritableAttribute)));
        }
        #endregion

        #region Public Methods
        public void Save(string[] updatedPropertyNames, PutOptions options = default) {
            _ = updatedPropertyNames ?? throw new ArgumentNullException(nameof(updatedPropertyNames));
            var updatedProperties = new List<PropertyInfo>();
            foreach (var name in updatedPropertyNames) {
                var property = this.GetType().GetProperty(name);
                updatedProperties.Add(property);
            }
            this.Save(updatedProperties, options);
        }
        public void Save(IEnumerable<PropertyInfo> updatedProperties = default, PutOptions options = default) {
            if (!this.WritableProperties.Any()) return;
            updatedProperties ??= this.WritableProperties;
            options ??= new PutOptions().UseDefault(updatedProperties);
            this.UpdatePropertyValues(updatedProperties);
            this.ManagementObject.Put(options);
        }
        #endregion

        #region Private Methods
        private void UpdatePropertyValues(IEnumerable<PropertyInfo> updatedProperties = default) {
            foreach (var property in this.WritableProperties.Intersect(updatedProperties)) {
                var name = property.Name;
                var value = property.GetValue(this);
                this.ManagementObject.SetPropertyValue(name, value);
            }
        }
        #endregion
    }
}
