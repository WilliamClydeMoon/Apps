using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common.Extensions;
using Data.Objects;
using Data.Objects.Shared;
using System.Text.RegularExpressions;

namespace Data.Communication.Test
{
    public class BuildEntityTestData
    {
        private string _path = @"C:\MyStuff\Dev\Apps\Data\Communication\Test\Pull\";
        private string addressFile = "Addresses.csv";
        //private string NameFile     = "Name.csv";
        private string emailFile    = "Emails.csv";
        private string phoneFile   = "Phones.csv";
        private string NamesFile = "Names.csv";
        private string associationFile = "Associations.csv";

        ContactsDo contacts = new ContactsDo();
        NamesDo Names = new NamesDo();
        AssociationsDo associations = new AssociationsDo();
        
        //public Name ContactName

        //public enum NameIdx : int { GROUP, ID, FIRST, MIDDLE, LAST, DATE }
        //public enum AddressIdx : int {GROUP,ID,STREET,CITY,STATE,ZIP,DATE} // AddressIdx
        //public enum EmailIdx : int { GROUP,ID,URL}
        //public enum PhoneIdx : int { GROUP,ID,AREA,NUMBER,TYPE,DATE}
        //public enum AssociationIdx : int { GROUP,PARENT, PARENTID, CHILD, CHILDID }

        /*__________________________________________________________________________________________*/
        public  BuildEntityTestData()
        {
            //this.ReadNameFile(_path + NameFile);
            string parentid = "00000000000000102008_00000001220952018901_05207";
            this.ReadAssociationFile(_path + associationFile );
            var AssociationGroups = associations.GetUniqueParentGroups();
            var selectGroup = associations.GetAllAssociationMatchesByParentIdAndGroup("NAME", parentid);
            var selectByParentId = associations.GetAllAssociationMatchesByParentId(parentid);
            this.ReadAddressFile(_path + addressFile);
            this.ReadEmailFile(_path+emailFile);
            this.ReadPhoneFile(_path + phoneFile);
            this.ReadNameFile(_path + NamesFile);
            var addresses = contacts.GetContactByGroup("PHONE");
            var g = contacts.GetUniqueGroups();
            var a = Names.GetUniqueGroups();
            //var n = Names.GetCurrentNameById("00000000000000085967_00000001220429793929_03490");
            var data = Names.GetNamesInDateOrderById("00000000000000085967_00000001220429793929_03490");
            var nme = Names.GetBestName("00000000000000085967_00000001220429793929_03490");
            //var n = Names.GetNamesInDateOrder();

            foreach(var contact in contacts.GetAllContacts() )
                contact.Display();
            
            //foreach (var address in addresses)
            //    address.Display();
        }
        /*__________________________________________________________________________________________*/
        public void ReadAssociationFile( string filePath)
        {

            var lines = File.ReadLines(filePath).Select(
                line => line.RemoveCharacters("\"").Split(',')).Select(       
                     items => new Association()
                        {
                            ParentName = items[(int)AssociationIdx.PARENT],
                            ParentId = items[(int)AssociationIdx.PARENTID],
                            ChildName = items[(int)AssociationIdx.CHILD],
                            ChildId = items[(int)AssociationIdx.CHILDID],
                            Group = items[(int)AssociationIdx.GROUP]
                        });//.Select(<List>associations = new AssociationsDo() );                 

            foreach( var items in lines)
                associations.Add(items);

            //foreach (var items in File.ReadLines(filePath).Select(line => line.StringCleanUp("\"").Split(',')).ToList())
            //{
            //    {
            //        Association association = new Association();
            //        association.ParentName = items[(int)AssociationIdx.PARENT];
            //        association.ParentId = items[(int)AssociationIdx.PARENTID];
            //        association.ChildName = items[(int)AssociationIdx.CHILD];
            //        association.ChildId = items[(int)AssociationIdx.CHILDID];
            //        associations.Add(association);
            //    }
            //} 
        }

        /*__________________________________________________________________________________________*/
        public void ReadNameFile( string filePath)
        {

            var lines = File.ReadLines(filePath).Select(
                line => line.RemoveCharacters("\"").Split(',')).Select(
                items => new Name()
                 {
                    NameId = items[(int)NameIdx.ID],
                    First = items[(int)NameIdx.FIRST],
                    Middle = items[(int)NameIdx.MIDDLE],
                    Last = items[(int)NameIdx.LAST],
                    FullName = items[(int)NameIdx.FIRST] + "  " + items[(int)NameIdx.MIDDLE] + " " + items[(int)NameIdx.LAST],
                    SysDateTime = DateTime.Parse(items[(int)NameIdx.DATE]),
                    Group = items[(int)NameIdx.GROUP]
                 });

            foreach (var items in lines)
                Names.Add(items);

            /*

            foreach (string line in File.ReadLines(filePath))
            {
                {
                    string[] items = line.Split(',');
                    Name Name = new Name();
                    Name.NameId = items[(int)NameIdx.ID];
                    Name.First = items[(int)NameIdx.FIRST];
                    Name.Middle = items[(int)NameIdx.MIDDLE];
                    Name.Last = items[(int)NameIdx.LAST];
                    Name.FullName = Name.First + "  " + Name.Middle + " " + Name.Last;
                    //Name.SysDateTime = DateTime.Parse(items[(int)NameIdx.DATE]);
                    Name.Group = items[(int)NameIdx.GROUP];

                    display(line);
                    //Console.WriteLine(line);
                }
            } */
        }
        /*__________________________________________________________________________________________*/
        public  void ReadNamesFile( string filePath)
        {
            string[] Groups = new[] { "CUSTOMER", "SUPPLIER", "CLIENT", "EMPLOYEE", "FRANCHESEE" };
            
            foreach (string line in File.ReadLines(filePath))
            {
                {
                    string[] items = line.Split(',');
                    Name Name = new Name();
                    Name.NameId = items[(int)NameIdx.ID];
                    Name.First = items[(int)NameIdx.FIRST];
                    Name.Middle = items[(int)NameIdx.MIDDLE];
                    Name.Last = items[(int)NameIdx.LAST];
                    Name.FullName = Name.First + "  " + Name.Middle + " " + Name.Last;
                    //Name.SysDateTime = DateTime.Parse(items[(int)NameIdx.DATE]);
                    Name.Group = items[(int)NameIdx.GROUP];
                    Names.Add(Name);

                    display(line);
                    //Console.WriteLine(line);
                }
            } 
        }
        /*__________________________________________________________________________________________*/
        public void ReadPhoneFile(string filePath)
        {



            foreach (string line in File.ReadLines(filePath))
            {
                {
                    string[] items = line.Split(',');
                    Contact contact = new Contact();
                    contact.ContactId = items[(int)PhoneIdx.ID];
                    contact.LineText1 = items[(int)PhoneIdx.AREA];
                    contact.LineText2 = items[(int)PhoneIdx.NUMBER];
                    contact.Description = items[(int)PhoneIdx.TYPE];
                    contact.SysDateTime = items[(int)PhoneIdx.DATE] == "" ? DateTime.Now : DateTime.Parse(items[(int)PhoneIdx.DATE]);
                    contact.Group = items[(int) PhoneIdx.GROUP]; // "PHONE";
                    contacts.Add(contact);

                    display(line);
                    //Console.WriteLine(line);
                }
            }
            
        }
        /*__________________________________________________________________________________________*/
        public void ReadEmailFile(string filePath)
        {
            foreach (string line in File.ReadLines(filePath))
            {
                {
                    string[] items = line.Split(',');
                    Contact contact = new Contact();
                    contact.ContactId = items[(int)EmailIdx.ID];
                    contact.LineText1 = items[(int)EmailIdx.URL];
                    contact.SysDateTime = DateTime.Now;
                    contact.Group = items[(int)EmailIdx.GROUP]; //"EMAIL";
                    contacts.Add(contact);

                    display(line);
                    //Console.WriteLine(line);
                }
            }
        }

        /*__________________________________________________________________________________________*/
        public void ReadAddressFile(string filePath)
        {


            foreach (string line in File.ReadLines(filePath))
            {
                {
                    string[] items = line.Split(',');
                    Contact contact = new Contact();
                    contact.ContactId = items[(int)AddressIdx.ID];
                    contact.LineText1 = items[(int)AddressIdx.STREET];
                    contact.LineText2 = items[(int)AddressIdx.CITY];
                    contact.LineText3 = items[(int)AddressIdx.STATE];
                    contact.LineText4 = items[(int)AddressIdx.ZIP];
                    contact.SysDateTime = DateTime.Parse(items[(int) AddressIdx.DATE]);
                    contact.Group = items[(int)AddressIdx.GROUP]; // "ADDRESS";
                    contacts.Add(contact);

                    display(line);
                    //Console.WriteLine(line);
                }
            }
        }
        /*__________________________________________________________________________________________*/
        private void display(string line)
        {
            Console.WriteLine(line);
        }

        /*__________________________________________________________________________________________*/
        //private string StringCleanUp(string  strIn)
        //{
        //    //return Regex.Replace(strIn, @"[^\w\.@-]", "");
        //    //return Regex.Replace(strIn, @"^(\s|")+|(\s|")+$" , "")

        //    //string pattern = @"^\s*""?|""?\s*$";
        //    //string pattern = @"^(|")+|(\s | ")+$";
        //    //return Regex.Replace(strIn, pattern, "");
        //    //return strIn.Trim('"', ' ', '\t');
        //    return strIn.Replace("\"", "");
        //    //return strIn;
        //}
    }
}
