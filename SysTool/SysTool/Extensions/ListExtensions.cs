using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTool.Extensions {
    public static class ListExtensions {
        public static async Task<List<T>> WhereAsync<T>(this IEnumerable<T> items, Func<T, Task<bool>> predicate) {
            var tasks = items
                .Select(i => new { Item = i, Task = predicate.Invoke(i) })
                .ToList();
            await Task.WhenAll(tasks.Select(t => t.Task));
            return tasks
                .Where(t => t.Task.Result)
                .Select(t => t.Item)
                .ToList();
        }
    }
}
