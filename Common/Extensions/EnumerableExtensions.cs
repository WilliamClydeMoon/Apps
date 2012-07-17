using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extensions
{
    // usage
    //        var results = contacts.Distinct(items => items.Group).ToList();
    //        return results;
    ///*__________________________________________________________________________________________*/
    public static class EnumerableExtensions
    {
        public static IEnumerable<TKey> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector)
        {
            return source.GroupBy(selector).Select(x => x.Key);
        }
    }
}
