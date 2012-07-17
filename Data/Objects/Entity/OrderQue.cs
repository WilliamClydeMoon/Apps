using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects
{
    class OrderQue
    {
        private string _orderid;
        private string _manifestid;
        private DateTime _quedatetime;
        private string _status;

        public string OrderId { get; set; }
        public string ManfiestID { get; set; }
        public DateTime SysDateTime { get; set; }
        public string Status { get; set; }
    }
}
