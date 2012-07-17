using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Objects;
using Data.Objects.Shared;
using Common.Extensions;

namespace UnitTest
{
    public class AssociationTest
    {
        private AssociationsDo associations; //= new AssociationsDo();
        private string childid;
        private string parentid;

        /*__________________________________________________________________________________________*/
        public void testGroupIDCombos()
        {
        AssociationsDo associations = new AssociationsDo();
        string childid;
        string Id;
        string parentgroup;
        string childgroup ;
        string message;

        message = "FRANCHESEE/CLIENT";
        Id = "00000000000000080533_00000001219860847215_00001";
        parentgroup = "FRANCHESEE";   // parent
        childgroup = "CLIENT";
        associations.Ids.Add(Id);
        associations.ParentGroup = parentgroup; // parent
        associations.ChildGroup = childgroup;
        associations.IDType = (int)AssociationIdx.PARENTID;
        List<Association> FranchessClientAssociation = associations.LoadData();
        associations.ReviewTestData(FranchessClientAssociation, message);
        associations.ReSet();

        message = "FRANCHESEE PARENT GROUP";
        parentgroup = "FRANCHESEE";   // parent
        associations.ParentGroup = parentgroup; // parent
        List<Association> FranchessAssociation = associations.LoadData();
        associations.ReviewTestData(FranchessAssociation, message);
        associations.ReSet();


        message = "FRANCHESEE CHILDGROUP"  ;
        childgroup = "FRANCHESEE";   // parent
        associations.ChildGroup = childgroup;
        List<Association> FranchessCHILDGROUPAssociation = associations.LoadData();
        associations.ReviewTestData(FranchessCHILDGROUPAssociation, message);
        associations.ReSet();


            message = "1-CLIENT/*BUY";
        Id = "00000000000000085967_00000001220429793929_03490";
        parentgroup = "CLIENT";      // parent
        childgroup = "BUY";
        associations.Ids.Add( Id);
        associations.ParentGroup = parentgroup; // parent
        associations.ChildGroup = childgroup;
        associations.IDType = (int)AssociationIdx.PARENTID;
        List<Association> BuyClientAssociation = associations.LoadData();
        associations.ReviewTestData(BuyClientAssociation, message);
        associations.ReSet();

            message = "1-BUY/1-ITEM       // POST INVENTORY IN";
        Id = "00000000000000085967_00000001220429793973_03493";
        parentgroup = "BUY";      // parent
        childgroup = "ITEM";
        associations.Ids.Add( Id);
        associations.ParentGroup = parentgroup; // parent
        associations.ChildGroup = childgroup;
        associations.IDType = (int)AssociationIdx.PARENTID;
        List<Association> BuyItemAssociation = associations.LoadData();
        associations.ReviewTestData(BuyItemAssociation, message);
        associations.ReSet();

            message = "1-TEM/1-SOLD     // POST INVENTORY OUT";
        Id = "00000000000000085967_00000001220429793929_01490";
        parentgroup = "ITEM";      // parent
        childgroup = "SOLD";
        associations.Ids.Add( Id);
        associations.ParentGroup = parentgroup; // parent
        associations.ChildGroup = childgroup;
        associations.IDType = (int)AssociationIdx.PARENTID;
        List<Association> ItemsSoldAssociation = associations.LoadData();
        associations.ReviewTestData(ItemsSoldAssociation, message);
        associations.ReSet();

        //1-SOLD/1-CUSTOMER  // INVENTORY OUT DEBIT
        Id = "00000000000000085967_00000001220429793973_03493";
        parentgroup = "SOLD";      // parent
        childgroup = "CUSTOMER";
        associations.Ids.Add( Id);
        associations.ParentGroup = parentgroup; // parent
        associations.ChildGroup = childgroup;
        associations.IDType = (int)AssociationIdx.PARENTID;
        List<Association> SoldCustomerAssociation = associations.LoadData();
        associations.ReviewTestData(SoldCustomerAssociation, message);
        associations.ReSet();

            message = "CUSTOMER/CONTACT";
        Id = "00000000000000102008_00000001220952018901_05207";
        parentgroup = "CUSTOMER";      // parent
        childgroup = "CONTACT";
        associations.Ids.Add( Id);
        associations.ParentGroup = parentgroup; // parent
        associations.ChildGroup = childgroup;
        associations.IDType = (int)AssociationIdx.PARENTID;
        List<Association> CustomerContactAssociation = associations.LoadData();
        associations.ReviewTestData(CustomerContactAssociation, message);
        associations.ReSet();

        associations.GetAll = true;
        associations.LoadData();

        var parentgrp = associations.GetUniqueParentGroups();
        var childgrp = associations.GetUniqueChildGroups();
        var pairedBuyClient  = associations.GetPairedParentGroupAndId(BuyClientAssociation);
        var quadBuyClient = associations.GetQuadDataList(BuyClientAssociation);
        }
        /*__________________________________________________________________________________________*/
        public void TestClassNew()
        {
                //AssociationsDo associations = new AssociationsDo();
        }
        /*__________________________________________________________________________________________*/
        public void TestAddRecord()
        {

            string parentid_ = "00000000000000085967_00000001220429793929_03490";
            string childid_ = "00000000000000078095_00000001219788540913_00010";
            string parentgroup_ = "NAME";
            string childgroup_ = "SALE";
            //AssociationsDo associations = new AssociationsDo();
            Association association = new Association();
            associations.Add(association.NewRecord(parentgroup_, parentid_,  childgroup_, childid_));

        }
        /*__________________________________________________________________________________________*/
         private void LoadClientData()
         {
             AssociationsDo associations = new AssociationsDo();
             string _francheseeId = "00000000000000080533_00000001219860847215_00001";

            //associations.ParentId = 
            associations.Ids.Add( _francheseeId);
            associations.ParentGroup = "FRANCHESEE"; // parent
            associations.ChildGroup = "CLIENT";
            associations.IDType = (int)AssociationIdx.PARENTID;
            //associations = new AssociationsDo(parentgroup, parentid, childgroup, "parent");
            
            List<Association> ClientAssociation = associations.LoadData();
             associations.ReSet();

             associations.Ids.Add(ClientAssociation.FindLast(element => element.ParentId == _francheseeId).ChildId);
             
            associations.ParentGroup = "CLIENT"; // parent            
            associations.ChildGroup = "CONTACT";
            associations.IDType = (int)AssociationIdx.PARENTID;
            //associations = new AssociationsDo(parentgroup, parentid, childgroup, "parent");
            List<Association > LoadClientContactData= associations.LoadData();

             NamesDo names = new NamesDo();
             names.Ids.Add(ClientAssociation.FindLast(element => element.ParentId == _francheseeId).ChildId);
             names.Group = "CLIENT";
             names.LoadData();
         }

        /*__________________________________________________________________________________________*/
        public void TestConstructors()
        {
            //string id = parentid;
            //string parent = 
            //AssociationsDo associations;

            //Associations = new List<Association>();
            int whichone = 3;
            switch( whichone)
            {
                case 3:
                    //AssociationsDo d = new AssociationsDo();
                    LoadClientData();
                    break;

                case 2:
                    //AssociationsDo a = new AssociationsDo(parentgroup, parentid,"childchild"); // Not Working
                    //a.LoadData();
                    break;
                case 1:
                    AssociationsDo b = new AssociationsDo();
                    b.GetAll = true; 
                    b.LoadData();
                    LoadClientData();
                    break; 
                case 0:

                    AssociationsDo c = new AssociationsDo(); // tested
                    c.GetAll = true; 
                    c.LoadData();
                    break;   
            }


            //associations.LoadData();

            //public AssociationsDo(string parentname, string parentid, string childname)
            //public AssociationsDo(List<string > Ids, string grouptype )
            //public AssociationsDo(bool GetAll)
            //public AssociationsDo(string grouptype)
        }

        /*__________________________________________________________________________________________*/
        public void TestLoads()
        {
            associations.LoadData();
        }
        /*__________________________________________________________________________________________*/      
        public void Test()
        {
            associations.LoadData();
            this.TestAddRecord();
            this.TestDisplayParentById();
            this.TestGetGroups();
            this.TestmatchPatterns();
        }
        /*__________________________________________________________________________________________*/
        public void TestDisplayParentById()
        {
            
            //foreach (var association in associations.Associations )
            //    Console.WriteLine(association .Connections.StringConcatenate() );
            Console.WriteLine(parentid); //association.Connections.StringConcatenate());
            associations.LoadData();
            foreach(var a in associations.GetAllAssociationMatchesByParentId(parentid ))//"00000000000000085967_00000001220429793929_03490"))
                Console.WriteLine( a.AssociationArray.StringConcatenate());
        }
        /*__________________________________________________________________________________________*/
        public void TestGetGroups()
        {
            //"ENTITY","NAME","00000000000000080533_00000001219860847215_00001","CONTACT","00000000000000080533_00000001219860851211_00011"
            //"ENTITY","NAME","00000000000000085967_00000001220429793929_03490","CONTACT","00000000000000085967_00000001220429793973_03493"
            //"ENTITY","NAME","00000000000000085967_00000001220429793929_03490","CONTACT","00000000000000085967_00000001220429793977_03495"
            //"ENTITY","NAME","00000000000000085967_00000001220429793929_03490","CONTACT","00000000000000085967_00000001220429793984_03497"
            //"ENTITY","NAME","00000000000000085967_00000001220429793929_03490","CONTACT","00000000000000085967_00000001220429793988_03499"
            //"ENTITY","NAME","00000000000000085967_00000001220429793929_03490","CONTACT","00000000000000129674_00000001222816572340_00147"
            //"ENTITY","NAME","00000000000000085967_00000001220429793929_03490","CONTACT","00000000000000129674_00000001222816619316_00150"


            //string id ="00000000000000085967_00000001220429793929_03490";
            var ids = associations.GetAllChildIdByParentId(parentid );
            var ndx = ids.FindIndex(val_ => val_ == childid); // "00000000000000085967_00000001220429793977_03495");
            var parentgroups = associations .GetUniqueParentGroups();
            var childgroups = associations.GetUniqueChildGroups();

            Console.WriteLine("Position of childId: " + childid + "    " + ndx.ToString());
            Console.WriteLine( "All Parent groups include: " + parentgroups.StringConcatenate());
            Console.WriteLine( "All Children groups include: " + childgroups.StringConcatenate());
        }
        /*__________________________________________________________________________________________*/
        public void TestmatchPatterns()
        {
            //var pgroup = associations.GetAllAssociationMatchesByParentIdAndGroup(parentid , parentgroup);
            //var cgroup = associations.GetAllAssociationMatchesByChildIDAndGroup(childid,childgroup);
            var byparentid = associations.GetAllAssociationMatchesByParentId(parentid );
            var bychildid = associations.GetAllAssociationMatchesByChildId(childid);
            var byParentGroup = associations.GetAllChildIdsByParentGroup("SALE");
            var byChildGroup = associations.GetAllParentIdsByParentGroup("SALE");
            var byParentIdByParentChildGroup = associations.GetParentIdsByParentAndChildGroup("SALE", "NAME");
            var byiChildIdByParentChildGroup = associations.GetChildIdsByParentAndChildGroup("SALE", "NAME");
            //Console.WriteLine( pgroup.Connections.StringConcatenate());
            //Console.WriteLine( cgroup.Connections.StringConcatenate());
            //Console.WriteLine(byparentid.Connections.StringConcatenate());
            //Console.WriteLine(bychildid.Connections.StringConcatenate());
        }
    }
}
