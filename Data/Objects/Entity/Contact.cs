using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Extensions;
using Data.Objects.Shared;

namespace Data.Objects
{
    //[AttributeUsage(AttributeTargets.Parameter)]
    public class Contact
    {
        #region private members
        private enum Groups : int
        {
            ADDRESS,    // LineText1 Street, LineText2 City, LineText3 State,  LineText4 zip
            PHONE,      // LineText1 AreaCode, LineText2 Number
            EMAIL       // LineText1 URL
        }
        // COMMON
        private string _header;
        private string _id;
        // ADDRESS
        private string[] _addressArray; // _addressArray
        private string _addressString;
        private string _street;
        private string _city ;
        private string _state;
        private string _zip;
        

        private string[] _phoneArray;  // 
        private string _phoneString;
        private string _areaCode;
        private string _number;


        private string[] _emailArray;
        private string _emailString;// 
        private string _url;

        // RAW CONTENT        
        private DateTime _sysDateTime;
        private string _contactId;
        private string _group;
        private string _description;

        private string _status;
        #endregion
        #region Constructor
        /*__________________________________________________________________________________________*/
        public Contact(){}
        /*__________________________________________________________________________________________*/
        public Contact(string group, string Id )
        {
            this.Initialize(group, Id);
        }
        /*__________________________________________________________________________________________*/
        private void Initialize(string group,string Id)
        {
            _sysDateTime = DateTime.Now;
            string _contactId = Id;
            string _group = group;
            string _description = "";
            string _status = "";
            string _street = "";
            string _city = "";
            string _state = "";
            string _zip = "";
            string _areaCode = "";
            string _number = "";
            string _url = "";
        }
        #endregion
        #region STATE properties
        public DateTime SysDateTime { get; set; }
        public string ContactId { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Header { get; set; }
        public string Id { get; set; }
        #endregion
        /*__________________________________________________________________________________________*/
        public void AddRecordAddress(string street, string city, string state, string zip)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }
        /*__________________________________________________________________________________________*/
        public void AddRecordPhone(string areacode, string number)
        {
            AreaCode = areacode;
            Number = number;
        }
        /*__________________________________________________________________________________________*/
        public void AddRecordEmail(string url)
        {
            Url = url;
        }
        #region public properties
        /*__________________________________________________________________________________________*/
        public string Street { get; set; }
        /*__________________________________________________________________________________________*/
        public string City { get; set; }
        /*__________________________________________________________________________________________*/
        public string State { get; set; }
        /*__________________________________________________________________________________________*/
        public string Zip { get; set; }
        /*__________________________________________________________________________________________*/
        public string AreaCode { get; set; }
        /*__________________________________________________________________________________________*/
        public string Number { get; set; }
        /*__________________________________________________________________________________________*/
        public string Url { get; set; }
        /*__________________________________________________________________________________________*/
        public  string[] AddressArray{get{return new string[] { this.Header, this.Id, this.Street, this.City, this.State, this.Zip };}}
        /*__________________________________________________________________________________________*/
        public string[] PhoneArray{get{return new string[] { this.Header, this.Id, this.AreaCode, this.Number };}}
        /*__________________________________________________________________________________________*/
        public string[] EmailArray{get{return new string[] { this.Header, this.Id, this.Url };}}
        /*__________________________________________________________________________________________*/
        public string AddressString{get{return Street + " " + City + ", " + State + ". " + Zip;}}
        /*__________________________________________________________________________________________*/
        public string EmailString { get { return Url; }}
        /*__________________________________________________________________________________________*/
        public string PhoneString
        {
            get
            {
                string PhoneStr = AreaCode + Number;
                _phoneString = PhoneStr.FormatWithMask("(###) ###-####");
                return _phoneString;
            }
        }
        #endregion
        /*__________________________________________________________________________________________*/
        public string ContactArrayString()
        {
            // TODO work on removing the use of the ADDRESS
            var enumdict = Groups.ADDRESS.ToDictionary().ToList();
            var select = enumdict.FindIndex(items => items.Value == Group);

            string results = "";

            switch (select)
            {
                case (int)Groups.ADDRESS:
                    results = AddressArray.StringConcatenate();
                    break;
                case (int)Groups.PHONE:
                    results = PhoneArray.StringConcatenate();
                    break;
                case (int)Groups.EMAIL:
                    results = EmailArray.StringConcatenate();
                    break;
            }
            return results;
        }
        /*__________________________________________________________________________________________*/
        public void Display()
        {
            var enumdict = AddressGroups.ADDRESS.ToDictionary().ToList();
            var select = enumdict.FindIndex(items => items.Value == Group);

            switch (select)
            {
                case (int)AddressGroups.ADDRESS:
                    Console.WriteLine(this.AddressString); 
                    break;
                case (int)AddressGroups.PHONE:
                    Console.WriteLine(this.PhoneString);
                    break;
                case (int)AddressGroups.EMAIL:
                    Console.WriteLine(this.EmailString);
                    break;
            }
        }
    }
}
