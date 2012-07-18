using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Extensions;
using Common.Utilities;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Data.Objects.Shared;
using Data.Objects;
using Data.DataAccess;
using Data.Objects.Products;

namespace UnitTest
{
    public class Tester
    {
        /*__________________________________________________________________________________________*/
        public void TestApp(string TestName )
        {
            switch (TestName.ToUpper( ))
            {
                case "ALL":
                    TestNames();
                    TestAssociations();
                    TestContacts();
                    TestAddContacts();
                    break;
                case "NAMES":
                    TestNames();
                    break;
                case "ASSOCIATIONS":
                    TestAssociations();
                    break;
                case "CONTACTS":
                    TestContacts();
                    break;
                case "ADDCONTACTS":
                    TestAddContacts();
                    break;
                case "EXTENSIONS":
                    var obj = new NamesDo();
                    TestExtensions(obj);
                    break;
                case "CUSTOMER":
                    TestCustomer();
                    break;
                case "ENTITY":
                    TestEntity();
                    break;
                case "XML":
                    testxml();
                    break;
                case "ITEMS":
                    TestItems();
                    break;
            }
        }
        private void testxml()
        {
            string xsdMarkup =
  @"<xs:schema attributeFormDefault='unqualified'
                       elementFormDefault='qualified'
                       xmlns:xs='http://www.w3.org/2001/XMLSchema'>
              <xs:element name='Snippet'>
                <xs:complexType>
                  <xs:attribute name='Id'
                                type='xs:unsignedByte' use='required' />
                </xs:complexType>
              </xs:element>
            </xs:schema>";
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(new StringReader(xsdMarkup)));
            XDocument snippet = XDocument.Parse("<Snippet Idx='0001'/>");
            string errors = null;
            snippet.Validate(schemas, (o, e) => errors += e.Message + Environment.NewLine);
            if (errors == null)
                Console.WriteLine("Passed Validation");
            else
                Console.WriteLine(errors);
        }
        /*__________________________________________________________________________________________*/
        private void TestItems()
        {
            ItemsDo items = new ItemsDo();
            items.LoadData();


        }
        /*__________________________________________________________________________________________*/
        private void TestEntity()
        {
        }

        /*__________________________________________________________________________________________*/
        private void TestCustomer()
        {
            //string id = "00000000000000085967_00000001220429793929_03490";
            //Session.Instance.EntityId = id;
            Customers customer = new Customers();
            customer.LoadDataObjects();

            //Customer customer = new Customer();
            //customer.LoadDataObjects();
            
        }
        /*__________________________________________________________________________________________*/
        private void TestExtensions(NamesDo  args)
        {
            var enumDict = AddressGroups.ADDRESS.ToList();
            var test = args.GetProperty(a => a.GetBestName("00000000000000085967_00000001220429793929_03490"));

        }
        /*__________________________________________________________________________________________*/
        private void TestNames()
        {
            NameTest testname = new NameTest();
            //testname.TestDisplay();
            testname.testGetGroup();
        }
        /*__________________________________________________________________________________________*/
        private void TestAssociations()
        {
            AssociationTest testassociation = new AssociationTest();
            testassociation.testGroupIDCombos();
            //testassociation.TestConstructors();
        }
        /*__________________________________________________________________________________________*/
        private void TestContacts()
        {
            ContactTest testcontact = new ContactTest();
            testcontact .TestDisplay(); 
            
            
        }
        /*__________________________________________________________________________________________*/
        private void TestAddContacts()
        {
            AddContactTest existingcontact = new AddContactTest();
            existingcontact.Test();                
        }
        //BuildEntityTestData test = new BuildEntityTestData();

       
    }
}
