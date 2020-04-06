using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SysTool.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GetProperties(Type t)
        {
            return t
                ?.GetProperties();
        }

        public static IEnumerable<PropertyInfo> GetWritableProperties(this Type t)
        {
            return GetProperties(t)
                ?.Where(p => p.CanWrite);
        }

        public static IEnumerable<PropertyInfo> GetWritableProperties<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetWritableProperties(t)
                ?.Where(p => Attribute.IsDefined(p, typeof(TAttribute)));
        }

        public static IEnumerable<PropertyInfo> GetWritableProperties<TAttribute1, TAttribute2>(this Type t)
            where TAttribute1 : Attribute
            where TAttribute2 : Attribute
        {
            return GetWritableProperties<TAttribute1>(t)
                ?.Where(p => Attribute.IsDefined(p, typeof(TAttribute2)));
        }

        public static IEnumerable<PropertyInfo> GetStringProperties(this Type t)
        {
            return GetProperties(t)
                ?.Where(p => p.PropertyType.Equals(typeof(string)));
        }
    }
}