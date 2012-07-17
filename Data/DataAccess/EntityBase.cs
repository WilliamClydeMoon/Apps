using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Objects;
using Common.Extensions;

namespace Data.DataAccess
{
    public abstract class EntityBase
    {
        #region private members
        ////Name
        //private string _nameId;
        //private string _group;
        //private string _first;
        //private string _fullName;
        //private string _last;
        //private string _middle;

        ////Address
        //private string _addressId;
        //private string _street;
        //private string _city ;
        //private string _state;
        //private string _zip;

        ////Email
        //private string _emailId;
        //private string _url;

        ////Phone
        //private string _phoneId;
        //private string _areaCode;
        //private string _number;
     

        ////Name
        //protected string NameId;
        //protected string Group;
        //protected string First;
        //protected string FullName;
        //protected string Last;
        //protected string Middle;

        ////Address
        //protected string AddressId;
        //protected string Street;
        //protected string City;
        //protected string State;
        //protected string Zip;

        ////Email
        //protected string EmailId;
        //protected string Url;

        ////Phone
        //protected string PhoneId;
        //protected string AreaCode;
        //protected string Number;

        //List
        public NamesDo names;
        public ContactsDo contacts;
        public AssociationsDo associations;

        //private Name name;
        
        ////private List<NamesDo,ContactsDo,AssociationsDo> = new List<NamesDo,ContactsDo,AssociationsDo>();
        ////workarea, workgroups, SalesInventoryDesktop
        #endregion
        #region Constructor
        /*__________________________________________________________________________________________*/
        protected EntityBase()
        {
            
            //Session.Instance.Associations = new AssociationsDo(); // .Associations. = Matches  => new AssociationsDo()
            //Session.Instance.Names = new NamesDo();
            //Session.Instance.Contacts = new ContactsDo();

            associations = new AssociationsDo(); // .Associations. = Matches  => new AssociationsDo()
            names = new NamesDo();
            contacts = new ContactsDo();
        }
        /*__________________________________________________________________________________________*/
        protected EntityBase(string nameId): this()
        {
            Session.Instance.EntityId = nameId;

            /*
                Open Contacts get,  matched records, get the contacts, populate the info go             
 
             * */


        }

        #endregion

        #region public methods
        /*__________________________________________________________________________________________*/
        public virtual void InitName() { }
        /*__________________________________________________________________________________________*/
        public virtual void InitAddress() { }
        /*__________________________________________________________________________________________*/
        public virtual void InitPhone() { }
        /*__________________________________________________________________________________________*/
        public virtual void InitEmail() { }
        #endregion
    }
}
