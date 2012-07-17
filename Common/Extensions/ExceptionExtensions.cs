using System;
using System.Threading;
using System.Security;
using System.Runtime.InteropServices;

namespace Common.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// http://www.codeproject.com/Articles/271683/I-Love-Csharp-Extension-Methods
        /// Determines whether the specified exception is critical.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>
        /// 	<c>true</c> if the specified exception is critical; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCritical(this Exception exception)
        {
            return (exception is OutOfMemoryException)
                || (exception is ThreadAbortException)
                || (exception is StackOverflowException)
                || (exception is AccessViolationException)
                || (exception is AppDomainUnloadedException)
                || (exception is SecurityException)
                || (exception is SEHException)
                ;
        }
    }
}
