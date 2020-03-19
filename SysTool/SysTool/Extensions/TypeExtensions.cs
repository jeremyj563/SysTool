using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SysTool.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GetWritableProperties(this Type t)
        {
            return t?
                .GetProperties()
                .Where(p => p.CanWrite);
        }

        public static IEnumerable<PropertyInfo> GetWritableProperties<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetWritableProperties(t)
                .Where(p => Attribute.IsDefined(p, typeof(TAttribute)));
        }
    }
}