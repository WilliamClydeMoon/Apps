using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Extensions;

namespace Data.Objects
{
    public class InventoriesDo
    {
        public List<Inventory> Inventories;
        /*__________________________________________________________________________________________*/
        public InventoriesDo()
        {
            Inventories = new List<Inventory>();
        }
        /*__________________________________________________________________________________________*/
        public List<Inventory> GetAllProducts()
        {
            return Inventories;
        }
        /*__________________________________________________________________________________________*/
        public Inventory GetProductByInventoryId(string id)
        {
            int idx = 0;
            idx = Inventories.FindIndex(item => item.InventoryId == id);
            return Inventories[idx];
        }
        /*__________________________________________________________________________________________*/
        public List<Inventory> GetProductByLocation(string location)
        {
            var results = Inventories.FindAll(item => item.Location  == location);
            return results;
        }
        /*__________________________________________________________________________________________*/
        public List<string> GetUniqueLocations()
        {
            var results = Inventories.Distinct(items => items.Location).ToList();
            return results;
        }
        /*__________________________________________________________________________________________*/
        public void Add(Inventory dataObject)
        {
            Inventories.Add(dataObject);
        }
    }
}

     
