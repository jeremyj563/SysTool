using System.Collections.Generic;
using System.Management;
using System.Reflection;

namespace SysTool.Extensions {
    public static class PutOptionsExtensions {
        public static void UseDefaultUpdateOptions(this PutOptions putOptions, string[] updatedProperties) {
            putOptions.Context = NewPutOptionsContext(updatedProperties);
            putOptions.UseAmendedQualifiers = false;
            putOptions.Type = PutType.UpdateOnly;
        }

        public static void UseDefaultUpdateOptions(this PutOptions putOptions, IEnumerable<PropertyInfo> updatedProperties) {
            var properties = updatedProperties.SelectArray(p => p.Name);
            UseDefaultUpdateOptions(putOptions, properties);
        }

        private static ManagementNamedValueCollection NewPutOptionsContext(string[] updatedProperties) {
            return new ManagementNamedValueCollection {
                { "__PUT_EXT_PROPERTIES", updatedProperties },
                { "__PUT_EXTENSIONS", true },
                { "__PUT_EXT_CLIENT_REQUEST", true }
            };
        }
    }
}
