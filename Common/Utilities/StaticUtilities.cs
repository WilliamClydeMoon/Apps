using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;


namespace Common.Utility
{
    //DO NOT RENAME THIS CLASS TO MATCH THE FILENAME - GJL 01/17/2012
    //DO NOT RENAME THE FILE TO MATCH THE CLASS NAME - GJL 01/17/2012
    public static class Utilities
    {

        // Provides Boolean value back.  
        public static bool GetBooleanValue(object oValueToParse, bool dDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return dDefaultValue;
                }

                return Boolean.Parse(oValueToParse.ToString());
            }
            catch
            {
                return dDefaultValue;
            }
        }

        // Provides Boolean value back with default false
        public static bool GetBooleanValue(object oValueToParse)
        {
            return GetBooleanValue(oValueToParse, false);
        }

        // Provides Char value back.  
        public static char GetCharValue(object oValueToParse, char dDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return dDefaultValue;
                }

                return Char.Parse(oValueToParse.ToString());
            }
            catch
            {
                return dDefaultValue;
            }
        }

        // Provides Char value back with default Char.MinValue.  
        public static char GetCharValue(object oValueToParse)
        {
            return GetCharValue(oValueToParse, Char.MinValue);
        }

        // Provides Date value back.  
        public static DateTime GetDateTimeValue(object oValueToParse, DateTime dDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return dDefaultValue;
                }

                return DateTime.Parse(oValueToParse.ToString());
            }
            catch
            {
                return dDefaultValue;
            }
        }

        // Provides Date value back with default MinValue
        public static DateTime GetDateTimeValue(object oValueToParse)
        {
            return GetDateTimeValue(oValueToParse, DateTime.MinValue);
        }

        // Provides Decimal value back.  
        public static decimal GetDecimalValue(object oValueToParse, decimal dDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return dDefaultValue;
                }

                return Decimal.Parse(oValueToParse.ToString());
            }
            catch
            {
                return dDefaultValue;
            }
        }

        // Provides Decimal value back with min value
        public static decimal GetDecimalValue(object oValueToParse)
        {
            return GetDecimalValue(oValueToParse, 0);
        }

        // Provides double value back.  
        public static double GetDoubleValue(object oValueToParse, double dDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return dDefaultValue;
                }

                return Double.Parse(oValueToParse.ToString());
            }
            catch
            {
                return dDefaultValue;
            }
        }

        // Provides Double value back with MinValue
        public static double GetDoubleValue(object oValueToParse)
        {
            return GetDoubleValue(oValueToParse, Double.MinValue);
        }

        // Provides Float value back.  
        public static float GetFloatValue(object oValueToParse, float fDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return fDefaultValue;
                }

                return Single.Parse(oValueToParse.ToString());
            }
            catch
            {
                return fDefaultValue;
            }
        }

        // Provides Float value back with default minvalue
        public static float GetFloatValue(object oValueToParse)
        {
            return GetFloatValue(oValueToParse, Single.MinValue);
        }

        // Provides Integer value back.  
        public static int GetIntegerValue(object oValueToParse, int iDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return iDefaultValue;
                }

                return Int32.Parse(oValueToParse.ToString());
            }
            catch
            {
                return iDefaultValue;
            }
        }

        // Provides Integer value back with MinValue
        public static int GetIntegerValue(object oValueToParse)
        {
            return GetIntegerValue(oValueToParse, Int32.MinValue);
        }

        // Provides Integer value back.  
        public static int? GetNullableIntegerValue(object oValueToParse, int? iDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return iDefaultValue;
                }

                return Int32.Parse(oValueToParse.ToString());
            }
            catch
            {
                return iDefaultValue;
            }
        }

        // Provides Integer value back with MinValue
        public static int? GetNullableIntegerValue(object oValueToParse)
        {
            return GetNullableIntegerValue(oValueToParse, null);
        }

        // Provides String value back. 
        public static string GetStringValue(object oValueToParse, string sDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return sDefaultValue;
                }

                return oValueToParse.ToString();
            }
            catch
            {
                return sDefaultValue;
            }
        }

        // Provides String value back as string.Empty
        public static string GetStringValue(object oValueToParse)
        {
            return GetStringValue(oValueToParse, System.String.Empty);
        }

        //provides long value back
        public static long GetLongValue(object oValueToParse, long iDefaultValue)
        {
            try
            {
                if (oValueToParse == null || oValueToParse == DBNull.Value)
                {
                    return iDefaultValue;
                }

                return Int64.Parse(oValueToParse.ToString());
            }
            catch
            {
                return iDefaultValue;
            }
        }

        //provides long value back with MinValue
        public static long GetLongValue(object oValueToParse)
        {
            return GetLongValue(oValueToParse, Int64.MinValue);
        }

        public static ulong GetULongValue(object oValueToParse)
        {
            return GetULongValue(oValueToParse, UInt64.MinValue);
        }

        public static ulong GetULongValue(object oValueToParse, ulong iDefaultValue)
        {
            if (oValueToParse == null || oValueToParse == DBNull.Value)
            {
                return iDefaultValue;
            }

            ulong rt;
            if (!UInt64.TryParse(oValueToParse.ToString(), out rt))
            {
                rt = iDefaultValue;
            }
            return (rt);
        }

        public static DateTime GetTimestampValue(object oValueTimestamp, DateTime defaultVal)
        {
            DateTime tStampVal;
            if (oValueTimestamp != null && oValueTimestamp is DateTime)
            {
                tStampVal = (DateTime)oValueTimestamp;
            }
            else if (oValueTimestamp != null)
            {
                try
                {
                    tStampVal = DateTime.Parse(oValueTimestamp.ToString());
                }
                catch (System.Exception)
                {
                    tStampVal = defaultVal;
                }
            }
            else
            {
                tStampVal = defaultVal;
            }

            return (tStampVal);
        }

        public static DateTime GetTimestampValue(object oValueTimestamp)
        {
            DateTime tStampVal;
            if (oValueTimestamp != null && oValueTimestamp is DateTime)
            {
                tStampVal = (DateTime)oValueTimestamp;
            }
            else if (oValueTimestamp != null)
            {
                try
                {
                    tStampVal = DateTime.Parse(oValueTimestamp.ToString());
                }
                catch (System.Exception)
                {
                    tStampVal = DateTime.MinValue;
                }
            }
            else
            {
                tStampVal = DateTime.MinValue;
            }

            return (tStampVal);
        }

        public static void WaitMillis(int millisecondsToWait)
        {
            if (millisecondsToWait < 0)
                return;

            DateTime start = DateTime.Now;
            while (true)
            {
                DateTime finish = DateTime.Now;
                TimeSpan span = finish - start;
                double totalMillis = span.TotalMilliseconds;
                var totalMillisWhole = (int)(Math.Floor(totalMillis));
                if (totalMillisWhole >= millisecondsToWait)
                {
                    break;
                }
            }
        }



        /// <summary>
        /// Checks whether an object/value type is null/default.  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrDefault<T>(T input)
        {
            return (Equals(input, default(T)));
        }

        public static object GetEnumFromConstantName<T>(string inputStr)
        {
            if (System.String.IsNullOrEmpty(inputStr))
                return (null);

            return ((T)Enum.Parse(typeof(T), inputStr, true));
        }

        public static bool CanCurrencyValueDistibuteOverItems(decimal currencyValue, int numberOfItems)
        {
            if (numberOfItems <= 0)
            {
                return false;
            }

            if (currencyValue == 0)
            {
                return true;
            }

            int numberOfCents = (int)(Math.Abs(Math.Round(currencyValue, 2)) * 100);
            return numberOfCents >= numberOfItems;
        }

        public static decimal[] GetDistributeValuesForCurrencyOverItems(decimal currencyValue, int numberOfItems)
        {
            List<decimal> values = new List<decimal>();

            if (numberOfItems == 0)
            {
                return new decimal[0];
            }

            if (currencyValue != 0)
            {
                int numberOfCents = (int)(Math.Round(currencyValue, 2) * 100);
                int amountPerItem = numberOfCents / numberOfItems;

                if (amountPerItem != 0)
                {
                    for (int i = 0; i < numberOfItems && Math.Abs(numberOfCents) > 0; i++)
                    {
                        values.Add((decimal)amountPerItem / 100M);
                        numberOfCents -= amountPerItem;
                    }
                }

                int idx = 0;
                decimal incrementValue = currencyValue > 0M ? .01M : -.01M;
                while (Math.Abs(numberOfCents) > 0)
                {
                    if (values.Count < numberOfItems)
                    {
                        values.Add(incrementValue);
                    }
                    else
                    {
                        values[idx] += incrementValue;
                        idx++;
                    }
                    numberOfCents -= currencyValue > 0M ? 1 : -1;
                }
            }

            while (numberOfItems > values.Count)
            {
                values.Add(0M);
            }

            return values.ToArray();
        }

        public static T ParseEnum<T>(string value, T defaultValue)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool IsValidFFL(string ffl)
        {
            if (System.String.IsNullOrEmpty(ffl))
            {
                return false;
            }

            return ffl.Trim().Length == 15;
        }

        public static bool IsParsableAs<T>(this string text)
        {
            var converters = new Dictionary<System.Type, Func<string, bool>>();
            converters.Add(typeof(int), s =>
            {
                int intResult;
                return (Int32.TryParse(text, out intResult));
            });
            converters.Add(typeof(string), s => true);
            converters.Add(typeof(DateTime), s =>
            {
                DateTime dt;
                return (DateTime.TryParse(text, out dt));
            });

            if (!converters.ContainsKey(typeof(T)))
                throw new NotSupportedException("Cannot determine parsability. Type not supported '" + typeof(T));
            return converters[typeof(T)](text);
        }

    }
}