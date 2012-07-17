using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extensions
{
    public static class ApplicationClassExtensions
    {
         //public static IEnumerable<TKey> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector)
        //public static IEnumerable<T> ToConcreteClass<T,TClass>(this IEnumerable<T> source , Action<T,TClass> sFunc)
        public static IEnumerable<T> ToConcreteClass<T>(this IEnumerable<T> source ) 
        {
            //foreach( var items in source)

                
            return source;
        }
    }
}
