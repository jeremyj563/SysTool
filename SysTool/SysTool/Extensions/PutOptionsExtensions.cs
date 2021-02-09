using System;
using System.Collections.Generic;
using System.Management;
using System.Reflection;

namespace SysTool.Extensions {
    public static class PutOptionsExtensions {
        public static PutOptions UseDefault(this PutOptions options, string[] updatedProperties) {
            _ = options ?? throw new ArgumentNullException(nameof(options));
            options.Context = PutOptionsExtensions.NewContext(updatedProperties);
            options.UseAmendedQualifiers = false;
            options.Type = PutType.UpdateOnly;
            return options;
        }
        public static PutOptions UseDefault(this PutOptions putOptions, IEnumerable<PropertyInfo> updatedProperties) {
            var properties = updatedProperties.SelectArray(p => p.Name);
            return PutOptionsExtensions.UseDefault(putOptions, properties);
        }
        private static ManagementNamedValueCollection NewContext(string[] updatedProperties) {
            return new ManagementNamedValueCollection {
                { "__PUT_EXT_PROPERTIES", updatedProperties },
                { "__PUT_EXTENSIONS", true },
                { "__PUT_EXT_CLIENT_REQUEST", true }
            };
        }
    }
}
