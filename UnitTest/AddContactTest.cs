using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Objects;
using Common.Extensions;

namespace UnitTest
{
    public class AddContactTest
    {
        private AssociationsDo associations = new AssociationsDo();
        private NamesDo names = new NamesDo();
        private ContactsDo contacts = new ContactsDo();

        private string parentid = "00000000000000085967_00000001220429793929_03490";
        private string childid = "00000000000000078095_00000001219788540913_00009";
        private string parentgroup = "NAME";
        private string childgroup = "CONTACT";

        public void Test()
        {
            //associations.LoadData();
            names.LoadData();
            contacts.LoadData();

            var nme = names.GetBestName(parentid);
            Console.WriteLine(nme.FullName);

            //var associationInfo = 
            foreach (var matches in associations.GetAllAssociationMatchesByParentId(parentid))
                Console.WriteLine( contacts.GetContactById(matches.ChildId).ContactArrayString());




            //var addresses = associationInfo.
            //    select( data=> new{ group})

        }

    }
}
