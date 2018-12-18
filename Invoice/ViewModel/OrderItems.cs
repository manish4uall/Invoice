using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.ViewModel
{
    public class OrderItems
    {

        public string orderNo { get; set; }
        public DateTime date { get; set; }
        public string customerName { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
        public decimal rate { get; set; }
    }
}