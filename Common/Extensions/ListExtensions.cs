using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extensions
{
    public static class ListExtensions
    {
        /*__________________________________________________________________________________________*/
        public static void Sort<TSource, TValue>(this List<TSource> source,Func<TSource, TValue> selector)
        {
            var comparer = Comparer<TValue>.Default;
            source.Sort((x, y) => comparer.Compare(selector(x), selector(y)));
        }
        /*__________________________________________________________________________________________*/
        public static void SortDescending<TSource, TValue>(this List<TSource> source,Func<TSource, TValue> selector)
        {
            var comparer = Comparer<TValue>.Default;
            source.Sort((x, y) => comparer.Compare(selector(y), selector(x)));
        }
        /*__________________________________________________________________________________________*/
        public static bool IsNullOrEmpty<T>(this IList<T> items)
        {
            return items == null || !items.Any();
        }
    }
}
