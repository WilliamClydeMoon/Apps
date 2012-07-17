using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        /*__________________________________________________________________________________________*/
        public static string RemoveCharacters(this String stringValue, string phrase)
        {
            //return stringValue.Replace("\"" "");
            string newstring = stringValue.Replace(phrase, "");
            return newstring;
            //return stringValue.Replace("\"", "");
        }
        public static string ViewString( this String stringdata)
        {
            return stringdata;
        }
        //usage:
        //  string[] ia = { "aaa", "bbb", "ccc" };    
        //      Console.WriteLine(ia.StringConcatenate());
        /*__________________________________________________________________________________________*/
        public static string StringConcatenate(this IEnumerable<string> source)
        {
            return source.Aggregate(
                new StringBuilder(),
                (s, i) => s.Append(i),
                s => s.ToString());
        }

        //USAGE:
        //        XElement xmlDoc = XElement.Parse(
        //           @"<Root>
        //                 <Value>111</Value>
        //                 <Value>222</Value>
        //                 <Value>333</Value>
        //              </Root>");
        //        string s2 = xmlDoc.Elements().StringConcatenate(el => (string)el);
        /*__________________________________________________________________________________________*/
        public static string StringConcatenate<T>(this IEnumerable<T> source,Func<T, string> projectionFunc)
        {
            return source.Aggregate(
                new StringBuilder(),
                (s, i) => s.Append(projectionFunc(i)),
                s => s.ToString());
        }
        /// <summary>
        /// Formats the string according to the specified mask
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="mask">The mask for formatting. Like "A##-##-T-###Z"</param>
        /// <returns>The formatted string</returns>
        /*__________________________________________________________________________________________*/
        public static string FormatWithMask(this string input, string mask)
        {
            if (input.IsNullOrEmpty()) return input;
            var output = string.Empty;
            var index = 0;
            foreach (var m in mask)
            {
                if (m == '#')
                {
                    if (index < input.Length)
                    {
                        output += input[index];
                        index++;
                    }
                }
                else
                    output += m;
            }
            return output;
        }
        /*__________________________________________________________________________________________*/
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input) || input.Trim() == string.Empty;
        }
    }
   
}
