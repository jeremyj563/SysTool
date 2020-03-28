using System;

namespace SysTool.Extensions
{
    public static class ObjectExtensions
    {
        public static Type GetBase(this object @object)
        {
            return @object?.GetType().BaseType;
        }
    }
}
