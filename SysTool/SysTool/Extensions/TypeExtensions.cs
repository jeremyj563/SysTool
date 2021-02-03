using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SysTool.Extensions {
    public static class TypeExtensions {
        public static IEnumerable<PropertyInfo> GetProperties(Type t) {
            return t
                ?.GetProperties();
        }
        public static IEnumerable<PropertyInfo> GetWritableProperties(this Type t) {
            return GetProperties(t)
                ?.Where(p => p.CanWrite);
        }
        public static IEnumerable<PropertyInfo> GetStringProperties(this Type t) {
            return GetProperties(t)
                ?.Where(p => p.PropertyType.Equals(typeof(string)));
        }
    }
}