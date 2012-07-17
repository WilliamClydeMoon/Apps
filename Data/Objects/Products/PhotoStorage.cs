using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects
{
    public class PhotoStorage
    {
        private string _photoId;
        private string _location;
        private List<PhotoStorage> _locations; 
        public string PhotoId { get; set; }
        public string Location { get; set; }
        
    }
}
