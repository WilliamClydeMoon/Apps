using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Objects;
using Data.Objects.Shared;
using Common.Extensions;

namespace UnitTest
{
    public class ContactTest
    {
        private ContactsDo contacts = new ContactsDo();
        private NamesDo names = new NamesDo();
        private AssociationsDo associations = new AssociationsDo();

        public void LoadTestData()
        {
            contacts .LoadData();
            names.LoadData();
            associations.LoadData();

        }

        public void TestDisplay()
        {
            var enumdict = AddressGroups.ADDRESS.ToDictionary().ToList();
            contacts.LoadData();
            Console.WriteLine("All contacts");
            foreach (var contact in contacts.Contacts)
            {
                var select = enumdict.FindIndex(items => items.Value == contact.Group);
                switch (select)
                {
                    case (int)AddressGroups.ADDRESS:

                        Console.WriteLine(contact.AddressString);
                        break;
                    case (int)AddressGroups.PHONE :
                        Console.WriteLine(contact.PhoneString);
                        break;
                    case (int)AddressGroups.EMAIL :
                        Console.WriteLine(contact.EmailString);
                        break;
                }
                Console.WriteLine(contact.ContactArrayString());
                    
            }
        }

    }
}
