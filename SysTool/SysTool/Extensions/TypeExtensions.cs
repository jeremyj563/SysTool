using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SysTool.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GetPublicInstanceProperties(this Type t)
        {
            return t
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .AsEnumerable();
        }

        public static IEnumerable<PropertyInfo> GetWritableProperties(this Type t)
        {
            return GetPublicInstanceProperties(t)
                .Where(p => p.CanRead && p.CanWrite);
        }
    }
}