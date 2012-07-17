using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects
{
    public class PhotosStoredDo
    {
        private List<PhotoStorage> _photosStored;
        public List<PhotoStorage> PhotosStored { get; set; } 
        public void Add(PhotoStorage dataObject)
        {
            PhotosStored.Add(dataObject);
        }
    }
}
