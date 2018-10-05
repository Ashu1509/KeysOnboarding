using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

using System.Data.Entity;
//using KeysOnboardingWithKnockout.Models;

namespace Task1.Controllers
{
    public class ProductSoldController : Controller
    {
        Task1Entities db = new Task1Entities();
        // GET: ProductSold
        public ActionResult ProductSold()
        {

            var product = db.ProductSold.Include(c => c.Customer).Include(p => p.Product).Include(s => s.Store);
            return View(product.ToList());
        }

        public JsonResult List()
        {
            using (db)
            {
                var psold = new ProductSold();
                ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", psold.Customer_Id);
                ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", psold.Product_Id);
                ViewBag.StoreId = new SelectList(db.Store, "Id", "Name", psold.Store_Id);
                var product = db.ProductSold.Include(c => c.Customer).Include(p => p.Product).Include(s => s.Store).Select(x => new {
                    Id = x.Id,
                    CustomerId = x.Customer_Id,
                    Customer = x.Customer.Cust_Name,
                    ProductId = x.Product_Id,
                    Product = x.Product.Product_Name,
                    StoreId = x.Store_Id,
                    Store = x.Store.Store_Name,
                    DateSold = x.Date_Sold
                }).ToList();
                return Json(product, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Add(ProductSold prod)
        {
            try
            {
                using (db)
                {
                    db.ProductSold.Add(prod);
                    db.SaveChanges();
                    return Json(prod, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return Json(prod, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult Edit(int id, ProductSold prod)
        {
            using (db)
            {
                var prod1 = db.ProductSold.Find(id);
                if (prod1 != null)
                {
                    db.Entry(prod1).State = EntityState.Detached;
                }
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return Json(prod, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete(int id)
        {
            using (db)
            {
                ProductSold prod = db.ProductSold.Find(id);
                db.ProductSold.Remove(prod);
                db.SaveChanges();
                return Json(prod, JsonRequestBehavior.AllowGet);
            }
        }
    }
}