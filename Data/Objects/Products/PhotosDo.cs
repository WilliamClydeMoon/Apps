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
    public class PhotosDo
    {
        public List<string> Ids = new List<string>();
        private bool _getall;
        //private List<PhotoStorage> _photosStored;
        public List<Photo> Photos;
        /*__________________________________________________________________________________________*/
        public PhotosDo()
        {
            Photos = new List<Photo>();
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
        //public List<PhotosDo> Get 
        /*__________________________________________________________________________________________*/
        public void Add(Photo dataObject)
        {
            Photos.Add(dataObject);
        }
        /*__________________________________________________________________________________________*/
        public List<Photo> LoadData() // TODO Not Tested
        {
            if (Photos.IsNullOrEmpty())
            {
                string file = "Item.csv";
                string path = @"C:\MyStuff\Dev\Apps\Data\Communication\Test\Pull\";
                string filePath = path + file;

                System.Nullable<bool> isIdsEmpty = Ids.IsNullOrEmpty();

                var records = File.ReadLines(filePath).Select(
                    line => line.RemoveCharacters("\"").Split(',')).
                    Where(data =>
                    {
                        return GetAll //ALL
                                   ? true //GROUP
                                   : isIdsEmpty.Value
                                         ? true
                                         : Ids.FindIndex(val_ => val_ == data[(int)ItemsIdx.ITEMID]) >= 0;
                    }).Select(
                                  record => new Photo()
                                  {
                                      //TODO Add data
                                      //ActualValue = Utilities.GetDecimalValue(record[(int)ItemsIdx.ACTUALVALUE]),
                                      //Cost = Utilities.GetDecimalValue(record[(int)ItemsIdx.COST]),
                                  });


                foreach (var line in records)

                    Photos.Add(line);
            }

            return Photos;
        }
    }
}
