using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//http://www.codeproject.com/Articles/37921/Enums-Flags-and-C-Oh-my-bad-pun

namespace Common.Extensions
{
    public static class EnumerationExtensions
    {

        // usage:
        //var enumdict = Groups.ADDRESS.ToDictionary().ToList();
        //var select = enumdict.FindIndex(items => items.Value == Group);

        public static Dictionary<int, string> ToDictionary(this Enum @enum)
        {
            var type = @enum.GetType();
            return Enum.GetValues(type).Cast<object>().ToDictionary(e => (int)e, e => Enum.GetName(type, e));
        }

        public static Dictionary<int, string > ToDictionary2(this Enum @enum)
        {
            var type = @enum.GetType();
            return Enum.GetValues(type).Cast<object>().ToDictionary(e => (int)e, e => Enum.GetName(type, e));
        }



        public static List<KeyValuePair<int,string>> ToList(this Enum enumObject)
        {
            var results = enumObject.ToDictionary().ToList();
            return results;
        }

    }
}
