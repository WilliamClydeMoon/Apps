using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Objects;
using Common.Extensions;

namespace Data.DataAccess
{
    public class Customers : EntityBase
    {
        #region private members

        private string _nameId;
        private Name _name;
        private Contact _address;
        private Contact _phone;
        private Contact _email;
        private List<Contact> _addresses;
        private List<Contact> _phones;
        private List<Contact> _emails;
        private bool IsNewName;
        private bool newEmail;
        private bool newPhone;
        private bool newAddress;

        #endregion
        // New        empty parameter
        //By Select  parameter = id on name/contact has list
        //by group  parameter = list of ids
        //by all       parameter = bool = true
        #region Constructor
        /*__________________________________________________________________________________________*/
        public Customers(string nameId) : base(nameId)
        {
            NameId = nameId;

        }
        /*__________________________________________________________________________________________*/
        public Customers():base()
        {}
        /*__________________________________________________________________________________________*/
        public void LoadDataObjects()
        {
            InitName();
            InitAddress();
            InitPhone();
            InitEmail();
        }
        #endregion
        #region public methods

        public Name _Name { get; set; }
        public Contact Address { get; set; }
        public Contact Phone { get; set; }
        public Contact Email { get; set; }
        public string NameId { get; set; }

        #endregion
        #region override Methods
        /*__________________________________________________________________________________________*/
        public override void InitName()
        {
            IsNewName = NameId.IsNullOrEmpty();

            switch (IsNewName)
            {
                case true:
                    _Name = new Name("CUSTOMER", Guid.NewGuid().ToString());
                    names.Add(_Name );
                    break;
                case false:
                    _Name = Session.Instance.Names.GetBestName(NameId);
                    break;
            }
        }
        /*__________________________________________________________________________________________*/
        public override void InitAddress()
        {
            //bool newAddress = true;
            switch(newAddress )
            {
                case true:
                    Address = new Contact("ADDRESS", Guid.NewGuid().ToString() );
                    contacts.Add(Address);
                    break;
                case false:
                    Address = new Contact( );
                    break;
            }
        }
        /*__________________________________________________________________________________________*/
        public override void InitPhone()
        {
            //bool newPhone = true;
            switch (newPhone)
            {
                case true:
                    Phone = new Contact("PHONE", Guid.NewGuid().ToString());
                    contacts.Add(Phone);
                    break;
                case false:
                    Phone = new Contact();
                    break;
            }
        }

        /*__________________________________________________________________________________________*/
        public override void InitEmail()
        {
            //bool newEmail = true;
            switch (newEmail)
            {
                case true:
                    Email = new Contact("EMAIL", Guid.NewGuid().ToString());
                    contacts.Add(Email);
                    break;
                case false:
                    Email = new Contact();
                    break;
            }
        }
        #endregion
    }
}
