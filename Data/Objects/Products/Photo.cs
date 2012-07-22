using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects
{
    public class Photo
    {

        private DateTime _SysDateTime;
        private string _itemId;
        private string _photoId;
        private string _productID;

        public Photo()
        {
            this.intialize();
        }
        private void intialize()
        {
            _SysDateTime = DateTime.Now;
            _itemId = "";
            _photoId = "";
            _productID = "";
        }
        public DateTime SysDateTime { get; set; }
        public string itemId { get; set; }
        public string photoId { get; set; }
        public string productID { get; set; }


    }
}
