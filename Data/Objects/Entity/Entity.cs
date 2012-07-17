using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects
{
    class Entity
    {
        private DateTime _sysDateTime;
        private string _addressId;
        private string _aliasId;
        private string _contactId;
        private string _entityId;

        private List<Name> Names = new List<Name>();
        private List<Contact> Contacts = new List<Contact>();
 
        public DateTime SysDateTime { get; set; }
        public string NameId{ get; set; }
        public string ContactId{ get; set; }
        public string EntityId{ get; set; }

    }
}
