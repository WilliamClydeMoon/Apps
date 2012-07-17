using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects
{
    class Manifest
    {
        private string _manifestid;
        private string _productid;
        private string _inventoryid;
        private int _quantity;
        private bool _instock;
        private bool _pricevalidated;
        private int _discount;
        private int _shippingcost;
        private int _tax;
        private int _totalcost;

        public bool InStock { get; set; }
        public bool PriceValidated { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public int ShippingCost { get; set; }
        public int Tax { get; set; }
        public int TotalCost { get; set; }
        public string InventoryId { get; set; }
        public string ManifestId { get; set; }
        public string ProductId { get; set; }


    }
}
