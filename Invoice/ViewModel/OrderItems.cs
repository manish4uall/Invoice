using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invoice.ViewModel;

namespace Invoice.ViewModel
{
    public class OrderItems
    {

        public string orderNo { get; set; }
        public DateTime date { get; set; }
        public string customerName { get; set; }
        public List<Items> Items { get; set; }
    }
}