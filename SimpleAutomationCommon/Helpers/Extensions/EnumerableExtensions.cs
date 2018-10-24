namespace SimpleAutomationCommon.Helpers.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var x in enumerable)
            {
                action(x);
            }
        }

        public static IEnumerable<T> Add<T>(this IEnumerable<T> enumerable, params T[] items)
        {
            return enumerable.Concat(items);
        }
    }
}