using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SysTool.Extensions {
    public static class TypeExtensions {
        public static IEnumerable<PropertyInfo> GetProperties(Type type) {
            _ = type ?? throw new ArgumentNullException(nameof(type));
            return type.GetProperties();
        }
        public static IEnumerable<PropertyInfo> GetWritableProperties(this Type type) {
            return TypeExtensions.GetProperties(type)
                .Where(p => p.CanWrite);
        }
        public static IEnumerable<PropertyInfo> GetStringProperties(this Type type) {
            return TypeExtensions.GetProperties(type)
                .Where(p => p.PropertyType.Equals(typeof(string)));
        }
    }
}