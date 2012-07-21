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


namespace Data.Objects
{
    public class ProductsDo
    {
        private List<Product> _product;
        public List<string> Ids = new List<string>();
        public List<string> GroupNames = new List<string>();
        private string _Id;
        private string _group;
        private bool _getall;
        public List<Product> Products;

        /*__________________________________________________________________________________________*/

        public ProductsDo()
        {
            Products = new List<Product>();

        }

        /*___________________________________________________________________________________________*/

        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

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

        /*__________________________________________________________________________________________*/

        public List<Product> GetAllProducts()
        {
            return Products;
        }

        /*__________________________________________________________________________________________*/

        public Product GetProductByInventoryId(string id)
        {
            int idx = 0;
            idx = Products.FindIndex(item => item.InventoryId == id);
            return Products[idx];
        }

        /*__________________________________________________________________________________________*/

        public List<Product> GetProductByGroup(string GroupName)
        {
            var results = Products.FindAll(item => item.Group == GroupName);
            return results;
        }

        /*__________________________________________________________________________________________*/

        public List<string> GetUniqueGroups()
        {
            var results = Products.Distinct(items => items.Group).ToList();
            return results;
        }

        /*__________________________________________________________________________________________*/

        public void Add(Product dataObject)
        {
            Products.Add(dataObject);
        }

        /*__________________________________________________________________________________________*/

        public List<Product> LoadData() // TODO Not Tested
        {
            if (Products.IsNullOrEmpty())
            {
                string file = "Item.csv";
                string path = @"C:\MyStuff\Dev\Apps\Data\Communication\Test\Pull\";
                string filePath = path + file;
                bool matchParentGroup = true;
                System.Nullable<bool> isGroupNameEmpty = GroupNames.IsNullOrEmpty();
                System.Nullable<bool> isGroup = !Group.IsNullOrEmpty();
                System.Nullable<bool> isIdsEmpty = Ids.IsNullOrEmpty();

                var records = File.ReadLines(filePath).Select(
                    line => line.RemoveCharacters("\"").Split(',')).
                    Where(data =>
                              {
                                  return GetAll //ALL
                                             ? true //GROUP
                                             : isIdsEmpty.Value
                                                   ? true
                                                   : Ids.FindIndex(val_ => val_ == data[(int) ItemsIdx.ITEMID]) >= 0;
                              }).Select(
                                  record => new Product()
                                                {
                                                    //TODO Add data
                                                    //ActualValue = Utilities.GetDecimalValue(record[(int)ItemsIdx.ACTUALVALUE]),
                                                    //Cost = Utilities.GetDecimalValue(record[(int)ItemsIdx.COST]),
                                                });
                //z => { return z; });
                // filter out the values by group if passed in.
                var lines = records.Select(line => line)
                    .Where(line =>
                               {
                                   return isGroupNameEmpty.Value
                                              ? true
                                              : GroupNames.FindIndex(val_ => val_.Trim() == line.Group.Trim()) >= 0;
                               }).ToList();

                foreach (var line in lines)

                    Products.Add(line);
            }

            return Products;
        }
    }
}
