using System;
using System.Collections.Generic;
using System.Management;
using System.Reflection;
using System.Text;

namespace SysTool.Extensions
{
    public static class PutOptionsExtensions
    {
        public static void UseDefaultUpdateOptions(this PutOptions putOptions, IEnumerable<PropertyInfo> updatedProperties)
        {
            var properties = updatedProperties.SelectArray(p => p.Name);
            UseDefaultUpdateOptions(putOptions, properties);
        }
        public static void UseDefaultUpdateOptions(this PutOptions putOptions, string[] updatedProperties)
        {           
            putOptions.Context = NewPutOptionsContext(updatedProperties);
            putOptions.UseAmendedQualifiers = false;
            putOptions.Type = PutType.UpdateOnly;
        }

        private static ManagementNamedValueCollection NewPutOptionsContext(string[] updatedProperties)
        {
            var context = new ManagementNamedValueCollection();
            context.Add("__PUT_EXT_PROPERTIES", updatedProperties);
            context.Add("__PUT_EXTENSIONS", true);
            context.Add("__PUT_EXT_CLIENT_REQUEST", true);
            return context;
        }
    }
}
