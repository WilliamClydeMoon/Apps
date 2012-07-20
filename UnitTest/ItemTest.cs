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
            // Test the Constructor
            ItemsDo items = new ItemsDo();
            items.LoadData();
            // Test the Unique logic
            List<string> groupnames = items.GetUniqueGroups();
            items.ReSet();

            //Test the Group filter
            items.GroupNames =  groupnames.FindAll(  line => line == "Fire Arms");
            items.ReviewTestData(items.LoadData(),"Items by group");
            items.ReSet();
            
            //Test by Id Filter
            items.Ids = new List<string>()
                {
                    "C50BD2CB1046024EE043AC15832FD7DC",
                    "C50BD2CB1049024EE043AC15832FD7DC",
                    "C50BD2CB104C024EE043AC15832FD7DC",
                    "C50BD2CB104F024EE043AC15832FD7DC",
                    "C50BD2CB1052024EE043AC15832FD7DC",
                    "C50BD2CB1055024EE043AC15832FD7DC",
                    "C50BD2CB1058024EE043AC15832FD7DC",
                    "C50BD2CB105B024EE043AC15832FD7DC",
                    "C50BD2CB0EB1024EE043AC15832FD7DC",
                    "C50BD2CB0EB4024EE043AC15832FD7DC",
                    "C50BD2CB0EB7024EE043AC15832FD7DC",
                    "C50BD2CB0EBA024EE043AC15832FD7DC",
                    "C50BD2CB0EBD024EE043AC15832FD7DC",
                    "C50BD2CB0EC0024EE043AC15832FD7DC",
                    "C50BD2CB0EC3024EE043AC15832FD7DC",
                    "C50BD2CB0EC6024EE043AC15832FD7DC"
                };


            items.ReviewTestData(items.LoadData(), "Items by Ids");

        }

    }
}
