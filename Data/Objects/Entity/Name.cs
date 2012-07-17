using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Utility.Type;

using Data.Objects ;
using Data.Objects.Shared;

namespace Data 
{
    public class Name : IDataErrorInfo
    {
        #region private members
        private DateTime _sysDateTime;
        private string _nameId;
        private string _group;
        private string _first;
        private string _fullName;
        private string _last;
        private string _middle;
        private string[] _nameArray;

        private bool _isLastNameRequired;
        //PROPERTIES
        static readonly string[] ValidatedProperties = 
        { 
            "SysDateTime",
            "NameId",
            "Group",
            "First",
            "FullName",
            "Last",
            "Middle",
         };
        #endregion
        #region Constructor
        /*__________________________________________________________________________________________*/
        public Name() {}

        /*__________________________________________________________________________________________*/
        public Name(string group, string Id)
        {
            this.Intialize(group, Id);
        }
        /*__________________________________________________________________________________________*/
        public void Intialize(string group, string Id)
        {
            SysDateTime = DateTime.Now;
            NameId = Id;
            Group = group;
            First = "";
            Last = "";
            Middle = "";
            IsLastNameRequired = GroupTypes(this.Group);

        }
        #endregion
        #region Creation
        /*__________________________________________________________________________________________*/
        public void AddRecord( string group, string nameid, string first, string middle, string last )
        {
            Group = group;
            NameId = nameid;
            First = first;
            Middle = middle;
            Last = last;
        }

        #endregion // Creation
        #region Public Properties
        public DateTime SysDateTime { get; set; }
        public string NameId { get; set; }
        public string Group { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Middle { get; set; }
        /*__________________________________________________________________________________________*/
        public string FullName
        {
            get
            {
                //if (_fullName == null)
                _fullName = this.First + " " + this.Middle + " " + this.Last;

                return _fullName;
            }
            set { _fullName = value; }
        }
        /*__________________________________________________________________________________________*/
        public string[] NameArray //GROUP, ID, FIRST, MIDDLE, LAST, DATE 
        {
            get
            {
                if (_nameArray == null)
                    _nameArray = new string[] {Group, NameId, First, Middle, Last};

                return _nameArray; }

            //set { _nameArray = value; }
        }
        #endregion
        //public List<string>PropertiesToString()
        //{
        //    return 
        //        this.ToString().Select();
        //}

        /*__________________________________________________________________________________________*/
        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
        /*__________________________________________________________________________________________*/
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion // IDataErrorInfo Members

        #region Validation
        /*__________________________________________________________________________________________*/
        private bool GroupTypes(string group)
        {
            //GROUPS
            //TODO change this to some other logic
            List<Types> groupTypes = new List<Types>();
            groupTypes.Add(new Types { Key = "SUPPLIER"       , boolValue  = false});
            groupTypes.Add(new Types { Key = "FRANCHESEE"  , boolValue =  false });
            groupTypes.Add(new Types { Key = "EMPLOYEE"      , boolValue =  true });
            groupTypes.Add(new Types { Key = "CLIENT"          , boolValue =  true });
            groupTypes.Add(new Types { Key = "CUSTOMER"      , boolValue = true });
            groupTypes.Add(new Types { Key = "VISITOR"         , boolValue =  true });
            groupTypes.Add(new Types { Key = "BUYER"            , boolValue = true });
            groupTypes.Add(new Types { Key = "OWNER"         , boolValue =   true });

            var type = groupTypes.Find(keyItem => keyItem.Key == group);
            //PairType<string, bool> AddAddressToNames = new List<PairType<string, bool>>();
            //groupTypes.Add((new PairType<string, bool>("SUPPLIER", false)));
            //AddAddressToNames.Add("SUPPLIER",false);
            //AddAddressToNames.Add("FRANCHESEE",    false);
            //AddAddressToNames.Add("EMPLOYEE" ,      true  );
            ////AddAddressToNames.Add("CLIENT"   ,        true  );
            //AddAddressToNames.Add("CUSTOMER"  ,   true   );
            //AddAddressToNames.Add("VISITOR" ,         true );
            //AddAddressToNames.Add("BUYER"   ,        true  ) ;
            //AddAddressToNames.Add("OWNER" ,          true );

            return type.boolValue;

        }
        /*__________________________________________________________________________________________*/
        private bool IsLastNameRequired
        {
            get
            {
                if (_isLastNameRequired == null)
                    _isLastNameRequired = GroupTypes(this.Group);

                return _isLastNameRequired;
            }
            set
            {   _isLastNameRequired = value; }
        }

        //PROPERTIES
        //public DateTime SysDateTime { get; set; }
        //public string NameId { get; set; }
        //public string Group { get; set; }
        //public string First { get; set; }
        //public string FullName { get; set; }
        //public string Last { get; set; }
        //public string Middle { get; set; }

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        /*__________________________________________________________________________________________*/
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }
        /*__________________________________________________________________________________________*/
        string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                //case "Email":
                //    error = this.ValidateEmail();
                //    break;

                case "First":
                    error = this.ValidateFirstName();
                    break;

                case "Last":
                    error = this.ValidateLastName();
                    break;
                case "Middle":
                    error = this.ValidateMiddleName();
                    break;
                default:
                    Debug.Fail("Unexpected property being validated on Name: " + propertyName);
                    break;
            }

            return error;
        }
        //string ValidateEmail()
        //{
        //    if (IsStringMissing(this.Email))
        //    {
        //        return Strings.Customer_Error_MissingEmail;
        //    }
        //    else if (!IsValidEmailAddress(this.Email))
        //    {
        //        return Strings.Customer_Error_InvalidEmail;
        //    }
        //    return null;
        //}
        /*__________________________________________________________________________________________*/
        string ValidateFirstName()
        {
            if (IsStringMissing(this.First))
            {
                return Strings.Customer_Error_MissingFirstName;
            }
            return null;
        }
        /*__________________________________________________________________________________________*/
        string ValidateLastName()
        {
            if (this.IsLastNameRequired)
            {
                if (!IsStringMissing(this.Last))
                    return Strings.Customer_Error_CompanyHasNoLastName;
            }
            else
            {
                if (IsStringMissing(this.Last))
                    return Strings.Customer_Error_MissingLastName;
            }
            return null;
        }
        /*__________________________________________________________________________________________*/
        string ValidateMiddleName()
        {
            if (this.IsLastNameRequired)
            {
                if (!IsStringMissing(this.Middle))
                    return Strings.Customer_Error_CompanyHasNoLastName;
            }
            else
            {
                if (IsStringMissing(this.Middle))
                    return Strings.Customer_Error_MissingLastName;
            }
            return null;   
        }
        /*__________________________________________________________________________________________*/
        static bool IsStringMissing(string value)
        {
            return String.IsNullOrEmpty(value) || value.Trim() == String.Empty;
        }
        /*__________________________________________________________________________________________*/
        static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            // This regex pattern came from: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        #endregion // Validation
    }
}
