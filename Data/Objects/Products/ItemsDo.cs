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
        public List<string> GroupNames = new List<string>();
        private string _Id;
        private string _group;
        private bool _getall;

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
        /*___________________________________________________________________________________________*/
        public string Group { get { return _group; } set { _group = value; } }

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
        #region Public Methods
        /*___________________________________________________________________________________________*/
        public List<Item>GetAllItemsByGroup(string groupname)
        {
            return Items.FindAll(items => items.Group == groupname);
        }

        /*___________________________________________________________________________________________*/
        public List<string>GetUniqueGroups()
        {
            var results = Items.Distinct(records => records.Group).ToList();
            results.Sort();
            return results;
        }
        /*__________________________________________________________________________________________*/
        public void ReSet()
        {
            _Id = null;
            _group = null;
            _getall = false;
            GroupNames.Clear();
            Ids.Clear();
            Items.Clear();
        }
        #endregion
        #region Fetch Data
        /*__________________________________________________________________________________________*/
        public void ReviewTestData(List<Item> list, string msg)
        {
            Console.WriteLine(msg);
            foreach (var line in list)
                Console.WriteLine(line.ItemArray.StringConcatenate());

        }
        #endregion
        #region Data
        /*__________________________________________________________________________________________*/
        public void Add(Item dataObject)
        {
            Items.Add(dataObject);
        }
        /*__________________________________________________________________________________________*/
        public List<Item> LoadData()
        {
            if (Items.IsNullOrEmpty())
            {
                string file = "Item.csv";
                string path = @"C:\MyStuff\Dev\Apps\Data\Communication\Test\Pull\";
                string filePath = path + file;
                bool matchParentGroup = true;
                System.Nullable <bool> isGroupNameEmpty = GroupNames.IsNullOrEmpty();
                System.Nullable<bool> isGroup = !Group.IsNullOrEmpty();
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
                            Description  =  Utilities.GetStringValue(record[(int)ItemsIdx.DESCRIPTION]),
                            Group   =  Utilities.GetStringValue(record[(int)ItemsIdx.GROUP]),
                            InventoryId   =  Utilities.GetStringValue(record[(int)ItemsIdx.INVENTORYID]),
                            ItemId   =  Utilities.GetStringValue(record[(int)ItemsIdx.ITEMID]),
                            Material   =  Utilities.GetStringValue(record[(int)ItemsIdx.MATERIAL]),
                            ModelNumber   =  Utilities.GetStringValue(record[(int)ItemsIdx.MODELNUMBER]),
                            ProductID   =  Utilities.GetStringValue(record[(int)ItemsIdx.PRODUCTID]),
                            SerialNumber   =  Utilities.GetStringValue(record[(int)ItemsIdx.SERIALNUMBER])
                        });
                //z => { return z; });
                // filter out the values by group if passed in.
                var lines = records.Select(line => line)
                        .Where(line =>
                            {
                                //if (isGroup.HasValue && isGroup.Value)
                                //    matchParentGroup = line.Group == Group; // _parentgroup;
                                return  isGroupNameEmpty.Value
                                    ? true
                                    : GroupNames.FindIndex(val_ => val_.Trim() == line.Group.Trim()) >= 0;

                                //return matchParentGroup;
                            }).ToList();

                foreach (var items in lines)
                {
                    Items.Add(items);
                }

            }
            return Items;
        }

        #endregion

    }
}
