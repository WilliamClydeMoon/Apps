using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utilities
{
    public class EnumHelper
    {
        /*__________________________________________________________________________________________*/
        public class KeyValuePair
        {
            public string Key { get; set; }

            public string Name { get; set; }

            public static List<KeyValuePair> ListFrom<T>()
            {
                var array = (T[])(Enum.GetValues(typeof(T)).Cast<T>());
                return array
                  .Select(a => new KeyValuePair
                  {
                      Key = a.ToString(),
                      Name = a.ToString()//.SplitCapitalizedWords()
                  })
                    .OrderBy(kvp => kvp.Name)
                   .ToList();
            }
        }
        //Usage:
        /*
        List<DayOfWeek> weekdays =
        EnumHelper.EnumToList<DayOfWeek>().FindAll(
            delegate(DayOfWeek x)
            {
                return x != DayOfWeek.Sunday && x != DayOfWeek.Saturday;
            });
         or
         EnumHelper.EnumToList<DayOfWeek>().FindAll( day => day != DayOfWeek.Sunday &&...
         http://devlicio.us/blogs/joe_niland/archive/2006/10/10/Generic-Enum-to-List_3C00_T_3E00_-converter.aspx 
        */
        /*__________________________________________________________________________________________*/
                public static List<T> EnumToList<T>()
                {
                    Type enumType = typeof (T);
                    // Can't use type constraints on value types, so have to do check like this
                    if (enumType.BaseType != typeof(Enum))
                        throw new ArgumentException("T must be of type System.Enum");

                    //Array enumValArray = Enum.GetValues(enumType);

                    //List<T> enumValList = new List<T>(enumValArray.Length);

                    //foreach (int val in enumValArray)
                    //{
                    //    enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
                    //}

                    return new List<T>(Enum.GetValues(enumType) as IEnumerable<T>);

                    //return enumValList;
                }
    }
}
