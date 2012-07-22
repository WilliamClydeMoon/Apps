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
    public class PhotosStoredDo
    {
        public List<string> Ids = new List<string>();
        private bool _getall;
        private List<PhotoStorage> _photosStored;
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
        public List<PhotoStorage> PhotosStored { get; set; }
        /*__________________________________________________________________________________________*/
        public List<PhotoStorage > GetPhotoById( string id)
        {
            return PhotosStored.FindAll(photo => photo.PhotoId == id);
        }
        /*__________________________________________________________________________________________*/
        public void Add(PhotoStorage dataObject)
        {
            PhotosStored.Add(dataObject);
        }
        /*__________________________________________________________________________________________*/
        public List<PhotoStorage> LoadData() // TODO Not Tested
        {
            if (PhotosStored.IsNullOrEmpty())
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
                                  record => new PhotoStorage()
                                  {
                                      //TODO Add data
                                      //ActualValue = Utilities.GetDecimalValue(record[(int)ItemsIdx.ACTUALVALUE]),
                                      //Cost = Utilities.GetDecimalValue(record[(int)ItemsIdx.COST]),
                                  });


                foreach (var line in records)

                    PhotosStored.Add(line);
            }

            return PhotosStored;
        }
    }
}
