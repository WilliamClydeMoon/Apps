using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Common.Extensions;
using Data .Objects.Shared;
using Data.DataAccess;

namespace Data.Objects
{
    public class ContactsDo
    {
        public List<Contact> Contacts;
        /*__________________________________________________________________________________________*/

        public ContactsDo()
        {
            Contacts = new List<Contact>();
            this.LoadData();
        }

        /*__________________________________________________________________________________________*/

        public List<Contact> GetAllContacts()
        {
            return Contacts;
        }

        /*__________________________________________________________________________________________*/

        public Contact GetContactById(string id)
        {
            int idx = 0;
            idx = Contacts.FindIndex(item => item.ContactId == id);
            return Contacts[idx];
        }

        /*__________________________________________________________________________________________*/

        public List<Contact> GetContactByGroup(string GroupName)
        {
            var results = Contacts.FindAll(item => item.Group == GroupName);
            return results;
        }

        /*__________________________________________________________________________________________*/

        public List<string> GetUniqueGroups()
        {
            var results = Contacts.Distinct(items => items.Group).ToList();
            return results;
        }

        /*__________________________________________________________________________________________*/

        public void Add(Contact dataObject)
        {
            Contacts.Add(dataObject);
        }
        /*__________________________________________________________________________________________*/
        public void LoadData()
        {
            if (Contacts.IsNullOrEmpty())
            {
                string addressFile = "Addresses.csv";
                string emailFile = "Emails.csv";
                string phoneFile = "Phones.csv";

                List<string> ContactIds = new List<string>();
                string file = addressFile;
                string path = @"C:\MyStuff\Dev\Apps\Data\Communication\Test\Pull\";
                string filePath = path; // +file;
                string id = Session.Instance.EntityId;
                bool GetAll = Session.Instance.EntityId.IsNullOrEmpty();
                //Session.Instance.ContactIds =
                if (!GetAll)
                {
                    ContactIds = Session.Instance.Associations.GetAllChildIdByParentId(id);
                } // issue of integrity of id null or empty.

                var address = File.ReadLines(path + addressFile).Select(
                    line => line.RemoveCharacters("\"").Split(',').ToList()).
                    Where(line =>
                              {
                                  return GetAll
                                             ? true
                                             : ContactIds.FindIndex(val_ => val_ == line[(int) AddressIdx.ID]) >= 0;
                              }).Select(line => new Contact()
                                                    {
                                                        Group = line[(int) AddressIdx.GROUP],
                                                        ContactId = line[(int)AddressIdx.ID].ViewString(),
                                                        Street = line[(int) AddressIdx.STREET],
                                                        City = line[(int)AddressIdx.CITY],
                                                        State = line[(int) AddressIdx.STATE],
                                                        Zip  = line[(int) AddressIdx.ZIP],
                                                        SysDateTime = DateTime.Parse(line[(int) AddressIdx.DATE])
                                                    }
                    );

                //    .Where(items =>
                //{
                //    return GetAll ? true : ContactIds.FindIndex(val_ => val_ == items[(int) AddressIdx.ID]) >= 0;
                //}).
                //Select(items =>
                //       new Contact()
                //                     {
                //                         Group = items[(int)AddressIdx.GROUP],
                //                         ContactId = items[(int) AddressIdx.ID],
                //                         Street = items[(int) AddressIdx.STREET],
                //                         City = items[(int)AddressIdx.CITY],
                //                         State = items[(int) AddressIdx.STATE],
                //                         Zip  = items[(int) AddressIdx.ZIP],
                //                         SysDateTime = DateTime.Parse(items[(int) AddressIdx.DATE]),
                                       
                //                     }
                //                     );

                foreach (var items in address)
                    Contacts.Add(items);

                              //Select(z =>{return z;}).
                var email = File.ReadLines(path + emailFile).Select(
                    line => line.RemoveCharacters("\"").Split(',')).
                    Where(items =>
                    {
                        return GetAll ? true : ContactIds.FindIndex(val_ => val_ == items[(int)EmailIdx.ID]) >= 0;
                    }).
                    Select(
                        items => new Contact()
                                     {
                                         ContactId = items[(int) EmailIdx.ID],
                                         Url = items[(int) EmailIdx .URL],
                                         SysDateTime = DateTime.Now,
                                         Group = items[(int) EmailIdx.GROUP]
                                     });

                foreach (var items in email)
                    Contacts.Add(items);


                var phone = File.ReadLines(path + phoneFile).Select(
                    line => line.RemoveCharacters("\"").Split(',')).
                    Where(items =>
                    {
                        return GetAll ? true : ContactIds.FindIndex(val_ => val_ == items[(int)PhoneIdx.ID]) >= 0;
                    }).
                    Select(
                        items => new Contact()
                                     {
                                         ContactId = items[(int) PhoneIdx.ID],
                                         AreaCode = items[(int) PhoneIdx.AREA],
                                         Number = items[(int)PhoneIdx.NUMBER],
                                         Description = items[(int) PhoneIdx.TYPE],
                                         SysDateTime =
                                             items[(int) PhoneIdx.DATE] == ""
                                                 ? DateTime.Now
                                                 : DateTime.Parse(items[(int) PhoneIdx.DATE]),
                                         Group = items[(int) PhoneIdx.GROUP] // "PHONE";
                                     });

                foreach (var items in phone)
                    Contacts.Add(items);

            }
        }
    }
}




                //var address = File.ReadLines(path + addressFile).Select(
                //    line => line.RemoveCharacters("\"").Split(',')).
                //    Where(items =>
                //              {
                //                  return GetAll ? true : ContactIds.FindIndex(val_ => val_ == items[(int)AddressIdx.ID]) >= 0;
                //              }).

                //    Select(
                //        items => new Contact()    // TODO add logic to filter by ID
                //                     {
                //                         ContactId = items[(int) AddressIdx.ID],
                //                         Street = items[(int) AddressIdx.STREET],
                //                         City = items[(int)AddressIdx.CITY],
                //                         State = items[(int) AddressIdx.STATE],
                //                         Zip  = items[(int) AddressIdx.ZIP],
                //                         SysDateTime = DateTime.Parse(items[(int) AddressIdx.DATE]),
                //                         Group = items[(int) AddressIdx.GROUP],

                //                     });