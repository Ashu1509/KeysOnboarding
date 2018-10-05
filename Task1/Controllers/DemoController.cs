using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;


namespace Task1.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        Task1Entities db = new Task1Entities();

        public ActionResult DemoView()
        {

            ViewBag.Customer = new SelectList(db.Customer, "Id", "Name");

            return View();
        }


        //public JsonResult List()
        //{
        //    using (db)
        //    {
        //        var psold = new ProductSold();
        //        ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", psold.Customer_Id);
        //        ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", psold.Product_Id);
        //        ViewBag.StoreId = new SelectList(db.Store, "Id", "Name", psold.Store_Id);
        //        var product = db.ProductSold.Include(c => c.Customer).Include(p => p.Product).Include(s => s.Store).Select(x => new {
        //            Id = x.Id,
        //            CustomerId = x.Customer_Id,
        //            Customer = x.Customer.Cust_Name,
        //            ProductId = x.Product_Id,
        //            Product = x.Product.Product_Name,
        //            StoreId = x.Store_Id,
        //            Store = x.Store.Store_Name,
        //            DateSold = x.Date_Sold
        //        }).ToList();
        //        return Json(product, JsonRequestBehavior.AllowGet);
        //    }

        //}
   }
}
