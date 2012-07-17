using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Objects;
using Common.Extensions;

namespace Data.DataAccess
{
    public sealed class Session
    {
        
        #region private member

        private static readonly Session instance = new Session();

        private List<NamesDo> names;
        private List<ContactsDo > contacts;
        private List<AssociationsDo> associations;
        private List<string> contactIds; 
        private string _entityId;

        private NamesDo _owner;
        private string _ownerId;
        private List<NamesDo > _franchesees;
        private NamesDo _franchesee;
        private string _francheseeId;
        private List<NamesDo > _clients;
        private NamesDo client;
        private string _clientId;
        private KeyValuePair<string, string> _francheseeNames;
        private KeyValuePair<string, string> _clientNames;
        private KeyValuePair< string,string > _customerNames;

        #endregion
        #region Constructor

        /*__________________________________________________________________________________________*/
        public Session()
        {
            AssociationsDo associations = new AssociationsDo();
        }
        /*__________________________________________________________________________________________*/
        public static Session Instance
        {
            get { return instance; }
        }
        /*__________________________________________________________________________________________*/
        public void ReSet()
        {
            FrancheseeId = null;
            ClientId = null;
        }

        #endregion
        #region public methods

        //public KeyValuePair<string, string> buildKeyPairList( object Do )
        //{
        //    Do.GetProperty()
        //}
        /*__________________________________________________________________________________________*/
        public KeyValuePair<string, string> FrancheseeNames { get; set; }
        /*__________________________________________________________________________________________*/
        public NamesDo Owner { get; set; }
        /*__________________________________________________________________________________________*/
        public NamesDo Franchesee { get; set; }
        /*__________________________________________________________________________________________*/
        public NamesDo Client { get; set; }
        /*__________________________________________________________________________________________*/
        public string FrancheseeId { get { return _francheseeId; } set { _francheseeId = value; } }
        /*__________________________________________________________________________________________*/
        public string ClientId { get { return _clientId; } set { _clientId = value; } }
        /*__________________________________________________________________________________________*/
        public string EntityId { get; set; }
        /*__________________________________________________________________________________________*/
        public NamesDo Names { get; set; }
        /*__________________________________________________________________________________________*/
        public ContactsDo Contacts { get; set; }
        /*__________________________________________________________________________________________*/
        public AssociationsDo Associations { get; set; }
        /*__________________________________________________________________________________________*/
        public List<string> ContactIds { get; set; }
        #endregion

    }
}
