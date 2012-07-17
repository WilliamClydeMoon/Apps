using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Extensions;

namespace Data.Objects
{
    public class ProductsDo
    {
        public List<Product> Products;
        
        /*__________________________________________________________________________________________*/
        public ProductsDo()
        {
            Products = new List<Product>();
            
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
    }
}
