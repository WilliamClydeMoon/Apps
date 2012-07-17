using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects
{
    public class Product
    {
        private int _depthInches;
        private int _heightInches;
        private int _weight;
        private int _widthInches;
        private string _description;
        private string _group;
        private string _inventoryId;
        private string _manufactureId;
        private string _material;
        private string _modelNumber;

        private string _productId;
        private string _productType;
        private string _serialNumber;

        public int DepthInches { get; set; }
        public int HeightInches { get; set; }
        public int Weight { get; set; }
        public int WidthInches { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string InventoryId{ get; set; }
        public string ManufactureId { get; set; }
        public string Material { get; set; }
        public string ModelNumber { get; set; }

        public string ProductId { get; set; }
        public string ProductType { get; set; }
        public string SerialNumber { get; set; }
    }
}
