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
    public class PhotoStorage
    {

        private string _photoId;
        private string _location;
        private List<PhotoStorage> _locations; 
        public string PhotoId { get; set; }
        public string Location { get; set; }
        
    }
}
