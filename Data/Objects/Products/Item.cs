using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects.Products
{
    public class Item
    {
        private int _actualValue;
        private int _cost;
        private int _depthInches;
        private int _heightInches;
        private int _inventoryValue;
        private int _newValue;
        private int _weight;
        private int _widthInches;
        private string _description;
        private string _group;
        private string _inventoryId;
        private string _itemId;
        private string _material;
        private string _modelNumber;
        private string _productID;
        private string _serialNumber;

        #region public properties
        public int ActualValue { get; set; }
        public int Cost{ get; set; }
        public int DepthInches { get; set; }
        public int HeightInches { get; set; }
        public int InventoryValue { get; set; }
        public int NewValue { get; set; }
        public int Weight { get; set; }
        public int WidthInches { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string InventoryId { get; set; }
        public string ItemId { get; set; }
        public string Material { get; set; }
        public string ModelNumber { get; set; }
        public string ProductID { get; set; }
        public string SerialNumber { get; set; }
        #endregion

    }
}
