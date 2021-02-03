using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SysTool.Extensions {
    public static class BindingListExtensions {
        public static void AddRange<T>(this BindingList<T> list, IEnumerable<T> items) {
            _ = items ?? throw new ArgumentNullException(nameof(items));

            foreach (T item in items) {
                list?.Add(item);
            }
        }
    }
}