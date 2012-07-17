using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects
{
    class Order
    {

        private string _id;
        private string _pmtmethod;
        private string _ordrecvia;
        private string _route;
        private string _confirmationid;
        private string _shippingid;
        private string _billingid;
        private string _customerid;
        private string _companyid;
        private string _manifestid;
        private string _orderlogid;
        private decimal _subtotal;
        private decimal _discounttotal;
        private decimal _shippingcost;
        private decimal _taxtotal;
        private decimal _total;
        private DateTime _sysDateTime;

        public string Id { get; set; }
        public string PmtMethod { get; set; }
        public string OrdRecVia { get; set; }
        public string Route { get; set; }
        public string ConfirmationId { get; set; }
        public string ShippingId { get; set; }
        public string BillingId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyId { get; set; }
        public string ManifestId { get; set; }
        public string OrderLogId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime SysDateTime { get; set; }

    }
}
