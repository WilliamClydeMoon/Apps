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

    public static class Utilities
    {

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
        public static bool GetBooleanValue(object oValueToParse)
        {
            return GetBooleanValue(oValueToParse, false);
        }

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
        public static DateTime GetDateTimeValue(object oValueToParse)
        {
            return GetDateTimeValue(oValueToParse, DateTime.MinValue);
        }

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
        public static decimal GetDecimalValue(object oValueToParse)
        {
            return GetDecimalValue(oValueToParse, 0);
        }

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
        public static double GetDoubleValue(object oValueToParse)
        {
            return GetDoubleValue(oValueToParse, Double.MinValue);
        }

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
        public static float GetFloatValue(object oValueToParse)
        {
            return GetFloatValue(oValueToParse, Single.MinValue);
        }

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
        public static int GetIntegerValue(object oValueToParse)
        {
            return GetIntegerValue(oValueToParse, Int32.MinValue);
        }

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
        public static int? GetNullableIntegerValue(object oValueToParse)
        {
            return GetNullableIntegerValue(oValueToParse, null);
        }

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
        public static string GetStringValue(object oValueToParse)
        {
            return GetStringValue(oValueToParse, System.String.Empty);
        }

        /*__________________________________________________________________________________________*/
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

        /*__________________________________________________________________________________________*/
        public static long GetLongValue(object oValueToParse)
        {
            return GetLongValue(oValueToParse, Int64.MinValue);
        }
        /*__________________________________________________________________________________________*/
        public static ulong GetULongValue(object oValueToParse)
        {
            return GetULongValue(oValueToParse, UInt64.MinValue);
        }
        /*__________________________________________________________________________________________*/
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
        /*__________________________________________________________________________________________*/
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
        /*__________________________________________________________________________________________*/
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
        /*__________________________________________________________________________________________*/
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
        /*__________________________________________________________________________________________*/
        public static bool IsNullOrDefault<T>(T input)
        {
            return (Equals(input, default(T)));
        }
        /*__________________________________________________________________________________________*/
        public static object GetEnumFromConstantName<T>(string inputStr)
        {
            if (System.String.IsNullOrEmpty(inputStr))
                return (null);

            return ((T)Enum.Parse(typeof(T), inputStr, true));
        }
        /*__________________________________________________________________________________________*/
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
        /*__________________________________________________________________________________________*/
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
        /*__________________________________________________________________________________________*/
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
        /*__________________________________________________________________________________________*/
        public static bool IsValidFFL(string ffl)
        {
            if (System.String.IsNullOrEmpty(ffl))
            {
                return false;
            }

            return ffl.Trim().Length == 15;
        }
        /*__________________________________________________________________________________________*/
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