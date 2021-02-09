using System;
using System.Collections.Generic;
using System.Linq;

namespace SysTool.Extensions {
    public static class IEnumerableExtensions {
        public static TResult[] SelectArray<T, TResult>(this IEnumerable<T> items, Func<T, TResult> selector) {
            return items
                .Select(selector)
                .ToArray();
        }
    }
}