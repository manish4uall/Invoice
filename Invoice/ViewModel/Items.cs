using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.ViewModel
{
    public class Items
    {
        public string itemName { get; set; }
        public int quantity { get; set; }
        public decimal rate { get; set; }
    }
}