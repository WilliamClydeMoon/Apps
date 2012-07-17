using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.Objects;
using Common.Extensions;

namespace UnitTest
{
    public class NameTest
    {
        //private List<Name>  names   = new List<Name>();


        public void TestLoad()
        {
            NamesDo names = new NamesDo();
            //names.LoadData();    
        }
        //public void TestDisplayNames()
        //{
        //    this.TestLoad();//names.LoadData();
        //    Console.WriteLine("ALL Names");
        //    foreach (var name in names.Names)
        //    {
        //        Console.WriteLine(name.NameArray.StringConcatenate());
        //        Console.WriteLine(name.FullName);
        //    } 
        //}
        public void ReviewTestData(List<string> list,string message )
        {
            Console.WriteLine(message);
            foreach ( var line in list )
                Console.WriteLine(line);
        }
        public void testGetGroup()
        {
            List<string> returnVal;
            Name name;
            string message;
            NamesDo names = new NamesDo();




            message = "TEST GET ALL";
            names.GetAll = true;
            names.LoadData();
            ReviewTestData(names.NamesList(), message);
            var datapair = names.GetPairedNameAndId();
            names.ReSet();

            message = "TEST GET BY ID";
            names.Ids.Add("00000000000000085967_00000001220429793929_03490");
            names.LoadData();
            ReviewTestData(names.NamesList(), message);
            names.ReSet();

            message = "TEST GET BY SPECIFIC GROUP";
            names.GetAll = true;
            names.Group = "OWNER";
            names.LoadData();
            ReviewTestData(names.NamesList(), message);
            names.ReSet();

            message = "TEST GET UNIQUE GROUPS";
            names.GetAll = true;
            names.LoadData();
            names.GetUniqueGroups();
            ReviewTestData(names.NamesList(), message);
            names.ReSet();

            message = "TEST BEST NAME";
            names.GetAll = true;
            names.LoadData();
            name = names.GetBestName("00000000000000085967_00000001220429793929_03490");
            ReviewTestData(names.NamesList(name),message);
            names.ReSet();

            names.GetAll = true;
            names.LoadData();
            var UniqueGroups = names.GetUniqueGroups();

        }
        public void TestDisplay()
        {
        NamesDo names = new NamesDo();
            names.Ids.Add( "00000000000000085967_00000001220429793929_03490");
            names.Group = "OWNER";
            names.LoadData();
            

            Console.WriteLine("GetNamesInDateOrderById");
            foreach( var name in names.GetNamesInDateOrderById("00000000000000085967_00000001220429793929_03490"))
                //Console.WriteLine(name.FullName);
                Console.WriteLine();
                

            Console.WriteLine("GetBestName");
             var name2 = names.GetBestName("00000000000000085967_00000001220429793929_03490");
                Console.WriteLine(name2.FullName);

            names.GetUniqueNamesById();
        }

    }
}
