using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects.Products
{
    public class Item
    {
        private decimal _actualValue;
        private decimal _cost;
        private int _depthInches;
        private int _heightInches;
        private int _inventoryValue;
        private decimal _newValue;
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
        #region public methods

        private string[] _itemArray ;
        /*___________________________________________________________________________________________*/
        public string[] ItemArray
        {
            get{ if (_itemArray == null)
                    _itemArray = new string[] { this.Group, this.Description, this.ItemId, this.ActualValue.ToString( ) , this.Cost.ToString( ) };

            return _itemArray;
            }
            set { _itemArray = value; }
        }
        #endregion
        #region public properties
        public decimal ActualValue { get; set; }
        public decimal Cost { get; set; }
        public int DepthInches { get; set; }
        public int HeightInches { get; set; }
        public int InventoryValue { get; set; }
        public decimal NewValue { get; set; }
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
