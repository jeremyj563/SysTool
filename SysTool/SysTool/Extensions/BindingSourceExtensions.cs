using System.Collections.Generic;
using System.Windows.Forms;

namespace SysTool.Extensions
{
    public static class BindingSourceExtensions
    {
        public static List<T> AsList<T>(this BindingSource bindingSource)
        {
            return bindingSource
                ?.DataSource as List<T>;
        }
    }
}