using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invoice.ViewModel;

namespace Invoice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Saves the Data to DataBase Table which is received by AJAX call
        [HttpPost]
        public JsonResult SaveToDb(OrderItems orderItems)
        {
            using(OrderManagementDBEntities dbObj = new OrderManagementDBEntities())
            {
                Order_mt order = new Order_mt()
                {
                    Order_no = orderItems.orderNo,
                    Order_date = orderItems.date,
                    Customer_name = orderItems.customerName
                };
                dbObj.Order_mt.Add(order);
                dbObj.SaveChanges();

                var id = dbObj.Order_mt.OrderByDescending(x => x.Order_id).First().Order_id;

                foreach ( var items in orderItems.Items)
                {                    
                    Order_dt order_Dt = new Order_dt()
                    {
                        Order_id = id,
                        item = items.itemName,
                        Quantity = items.quantity,
                        Rate = items.rate
                    };
                    dbObj.Order_dt.Add(order_Dt);
                    dbObj.SaveChanges();
                }  
            }

            return Json(new JsonResult(), JsonRequestBehavior.AllowGet);
        }

        // Fetches the data From the Database table Orders_mt and Sends to the AJAX Request
        [HttpGet]
        public JsonResult GetOrders()
        {
            using(OrderManagementDBEntities dbObj = new OrderManagementDBEntities())
            {
                var result = dbObj.Order_mt.ToList();
                return Json(result,JsonRequestBehavior.AllowGet);
            }

            
        }
    }
}