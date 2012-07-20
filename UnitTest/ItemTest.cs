using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utility.Type;
using Common.Extensions;
using Data.Objects.Shared;
using Data.DataAccess;
using System.Text.RegularExpressions;
using Common.Utility;

using Data.Objects.Products;

namespace UnitTest
{
    class ItemTest
    {
        private ItemsDo items; // = new ItemsDo();

        /*__________________________________________________________________________________________*/
        public void TestLoad()
        {
            ItemsDo items = new ItemsDo();
            items.LoadData();
            List<string> groupnames = items.GetUniqueGroups();
        }

    }
}
