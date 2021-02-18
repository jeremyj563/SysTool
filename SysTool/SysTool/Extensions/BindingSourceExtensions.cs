using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SysTool.Extensions {
    public static class BindingSourceExtensions {
        public static List<T>? AsList<T>(this BindingSource bindingSource) {
            return bindingSource
                ?.DataSource as List<T>;
        }
        public static void UpdateItem<T>(this BindingSource bindingSource, T boundItem, T updatedItem) {
            _ = bindingSource ?? throw new ArgumentNullException(nameof(bindingSource));
            var index = bindingSource.IndexOf(boundItem);
            if (index != -1) {
                bindingSource[index] = updatedItem;
                bindingSource.ResetItem(index);
            }
        }
    }
}