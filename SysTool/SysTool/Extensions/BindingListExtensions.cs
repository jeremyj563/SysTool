using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SysTool.Extensions
{
    public static class BindingListExtensions
    {
        public static void AddRange<T>(this BindingList<T> list, IEnumerable<T> items)
        {
            if (items == null) return;

            foreach (T item in items)
            {
                list?.Add(item);
            }
        }
    }
}