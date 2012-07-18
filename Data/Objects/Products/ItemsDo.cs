using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utility.Type;
using Common.Extensions;
using Data.Objects.Shared;
using Data.DataAccess;
using System.Text.RegularExpressions;
using Common.Utility;

namespace Data.Objects.Products
{
    public class ItemsDo
    {
        private List<Item> _items;
        public List<string> Ids  = new List<string>();

        private string _Id;

        private bool _getall;
        private int _idtype;


        #region Contstructor
        /*__________________________________________________________________________________________*/
        public ItemsDo()
        {
          
            Items = new List<Item>();
        }
        #endregion
        #region private members
        /*__________________________________________________________________________________________*/
        public List<Item> Items { get; set; }
        /*__________________________________________________________________________________________*/
        public bool GetAll
        {
            get
            {
                if (_getall == null)
                    _getall = false;

                return _getall;
            }
            set { _getall = value; }
        }
        #endregion
        #region Data
        /*__________________________________________________________________________________________*/
        public void Add(Item dataObject)
        {
            Items.Add(dataObject);
        }
        /*__________________________________________________________________________________________*/
        public void LoadData()
        {
            if (Items.IsNullOrEmpty())
            {
                string file = "Item.csv";
                string path = @"C:\MyStuff\Dev\Apps\Data\Communication\Test\Pull\";
                string filePath = path + file;
                bool matchParentGroup = true;
                System.Nullable<bool> isIdsEmpty = Ids.IsNullOrEmpty();

                var records = File.ReadLines(filePath).Select(
                    line => line.RemoveCharacters("\"").Split(',')).
                    Where(data =>
                              {
                                  return GetAll               //ALL
                                              ? true            //GROUP
                                              : isIdsEmpty.Value ? true : Ids.FindIndex(val_ => val_ == data[(int)ItemsIdx.ITEMID]) >= 0;
                              }).Select(
                        record => new Item()
                        {
                            ActualValue  = Utilities.GetDecimalValue(record[(int)ItemsIdx.ACTUALVALUE] ) , 
                            Cost =  Utilities.GetDecimalValue(record[(int)ItemsIdx.COST]),

                            DepthInches  = Utilities.GetIntegerValue(record[(int)ItemsIdx.DEPTHINCHES]),
                            HeightInches = Utilities.GetIntegerValue(record[(int)ItemsIdx.HEIGHTINCHES]),
                            InventoryValue = Utilities.GetIntegerValue(record[(int)ItemsIdx.INVENTORYVALUE]),
                            NewValue = Utilities.GetDecimalValue(record[(int)ItemsIdx.NEWVALUE ]),
                            Weight = Utilities.GetIntegerValue(record[(int)ItemsIdx.WEIGHT]),
                            WidthInches = Utilities.GetIntegerValue(record[(int)ItemsIdx.WIDTHINCHES]),
                            Description  =  record[(int)ItemsIdx.DESCRIPTION],
                            Group   =  record[(int)ItemsIdx.GROUP],
                            InventoryId   =  record[(int)ItemsIdx.INVENTORYID],
                            ItemId   =  record[(int)ItemsIdx.ITEMID],
                            Material   =  record[(int)ItemsIdx.MATERIAL],
                            ModelNumber   =  record[(int)ItemsIdx.MODELNUMBER],
                            ProductID   =  record[(int)ItemsIdx.PRODUCTID],
                            SerialNumber   =  record[(int)ItemsIdx.SERIALNUMBER]
                        });
                //Select(z => { return z; })
                // filter out the values by group if passed in.
                //var lines = records.Select(line => line)
                //    .Where(line =>
                //               {
                //                   true;
                //                   //if (isParentGroup.HasValue && isParentGroup.Value)
                //                   //    matchParentGroup = line.Group == Group; // _parentgroup;

                //                   //return matchParentGroup;
                //               }).ToList();

                foreach (var line in records)
                {
                    Items.Add(line);
                }
            }
        }
        #endregion

    }
}
