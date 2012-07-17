using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extensions
{
    public static class ReferenceExtensions
    {
        /// <summary>
        /// Gets the property of that.
        /// </summary>
        /// <typeparam name="TC">The type of the class of that.</typeparam>
        /// <typeparam name="TP">The type of the property.</typeparam>
        /// <param name="that">The invoking object.</param>
        /// <param name="func">The function to calculate the value.</param>
        /// <returns>the result of the func or default(TP)</returns>
        public static TP GetProperty<TC, TP>(this TC that, Func<TC, TP> func)
            where TC : class
        {
            if (object.ReferenceEquals(that, null))
            {
                return default(TP);
            }
            return func(that);
        }
        /// <summary>
        /// Gets the property of that.
        /// </summary>
        /// <typeparam name="TC">The type of the class of that.</typeparam>
        /// <typeparam name="TP">The type of the property.</typeparam>
        /// <param name="that">The invoking object.</param>
        /// <param name="func">The function to calculate the value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>the result of the func or defaultValue</returns>
        public static TP GetProperty<TC, TP>(this TC that, Func<TC, TP> func, TP defaultValue)
            where TC : class
        {
            if (object.ReferenceEquals(that, null))
            {
                return defaultValue;
            }
            return func(that);
        }
        /// <summary>
        /// Gets the property of that.
        /// </summary>
        /// <typeparam name="TC">The type of the class of that.</typeparam>
        /// <typeparam name="TP">The type of the property.</typeparam>
        /// <param name="that">The invoking object.</param>
        /// <param name="func">The function to calculate the value.</param>
        /// <param name="funcDefault">The function to calculate the default value.</param>
        /// <returns>the result of the func or defaultValue</returns>
        public static TP GetProperty<TC, TP>(this TC that, Func<TC, TP> func, Func<TP> funcDefault)
            where TC : class
        {
            if (object.ReferenceEquals(that, null))
            {
                return funcDefault();
            }
            return func(that);
        }
        /// <summary>
        /// Calls the <paramref name="action"/> if <paramref name="that"/> is not null.
        /// </summary>
        /// <typeparam name="TC">The type of that.</typeparam>
        /// <param name="that">The invoking object.</param>
        /// <param name="action">The action to call.</param>
        public static void Call<TC>(this TC that, Action<TC> action)
            where TC : class
        {
            if (object.ReferenceEquals(that, null))
            {
                return;
            }
            action(that);
        }
        // add 2011-01-13 fgr : SetAs
        /// <summary>
        /// Sets <paramref name="thatAs"/>via the as-operator.
        /// </summary>
        /// <typeparam name="TThat">The source type (of that).</typeparam>
        /// <typeparam name="TAs">The target type (of thatAs).</typeparam>
        /// <param name="that">The invoking object.</param>
        /// <param name="thatAs">The target.</param>
        /// <returns>true if not null; otherwise false</returns>
        /// <remarks></remarks>
        public static bool SetAs<TThat, TAs>(this TThat that, out TAs thatAs)
            where TThat : class
            where TAs : class
        {
            thatAs = that as TAs;
            return !object.ReferenceEquals(thatAs, null);
        }
    }
}
