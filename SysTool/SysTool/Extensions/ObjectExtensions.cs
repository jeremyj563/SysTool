using System;
using System.Linq;

namespace SysTool.Extensions
{
    public static class ObjectExtensions
    {
        public static bool PropertiesContain(this object @object, string text, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var stringValues = @object
                .GetType()
                .GetStringProperties()
                .Select(p => (p.GetValue(@object) as string));

            return stringValues
                .Any(s => s.Contains(text, comparison));
        }
    }
}