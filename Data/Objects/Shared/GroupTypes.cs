using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Objects ;

namespace Data.Objects.Shared
{
    static public class GroupTypes
    {
        static private List<Types> nameTypes; // = new List<Types>();
         
        static public List<Type> NameType { get; set; }

        static public  Boolean  NameTypes(string group)
        {
            //GROUPS

            List<Types> NameTypes = new List<Types>();
            NameTypes.Add(new Types { Key = "SUPPLIER", Value = false });
            NameTypes.Add(new Types { Key = "FRANCHESEE", Value = false });
            NameTypes.Add(new Types { Key = "EMPLOYEE", Value = true });
            NameTypes.Add(new Types { Key = "CLIENT", Value = true });
            NameTypes.Add(new Types { Key = "CUSTOMER", Value = true });
            NameTypes.Add(new Types { Key = "VISITOR", Value = true });
            NameTypes.Add(new Types { Key = "BUYER", Value = true });
            NameTypes.Add(new Types { Key = "OWNER", Value = true });

            var type = NameTypes.Find(keyItem => keyItem.Key == group);

            return type.Value;

        }
    }
}
