using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Data.Objects
{
    public class Association
    {
        //private string _group;
        private string _ParentGroup;
        private string _ParentId;
        private string _ChildGroup;
        private string _ChildId;
        //private DateTime _sysDateTime;

        public Association  NewRecord( string parentGroup, string parentId, string childGroup, string childId)
        {
            //Group = group;
            ParentGroup = parentGroup;
            ParentId = parentId;
            ChildGroup = childGroup;
            ChildId = childId;
            return this;
        }


        private string[] _associationArray;

        //public string Group { get; set; }
        public string ParentGroup { get; set; }
        public string ParentId { get; set; }
        public string ChildGroup { get; set; }
        public string ChildId { get; set; }
        //public DateTime SysDateTime { get; set; }
        public string[] AssociationArray
        {
            get
            {
                if (_associationArray == null)
                    _associationArray = new string[] { this.ParentGroup, this.ParentId, this.ChildGroup, this.ChildId };

                return _associationArray;
            }
            set { _associationArray = value; }
        }
    }
}
