using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects
{
    public class Inventory
    {
        private DateTime _inDateTime;
        private DateTime _outDateTime;
        private int _count;
        private string _inventoryId;
        private string _location;
        private string _productId;
        private string _status;


        private string _conditionIn;
        private string conditionOut;


        public Inventory()
        {
            this.Initialize();
        }

        private void Initialize()
        {
         _inDateTime = DateTime.Now;
         _outDateTime = DateTime.Now;
         _count = 0;
         _inventoryId = "";
         _location = "";
         _productId = "";
         _status = "";  
        }

        public DateTime InDateTime { get; set; }
        public DateTime OutDateTime { get; set; }
        public int Count { get; set; }
        public string InventoryId { get; set; }
        public string Location { get; set; }
        public string ProductId { get; set; }
        public string Status { get; set; }
        public string ConditionIn { get; set; }
        public string ConditionOut { get; set; }
    }
}
