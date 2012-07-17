using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects.Products
{
    public class ItemsDo
    {
        private List<Item> _Items;
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
        /*__________________________________________________________________________________________*/
        public List<Item> Items { get; set; }
    }
}
