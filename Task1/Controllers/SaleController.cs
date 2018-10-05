using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {

            var model = new List<SaleInfo>();


            using (var db = new Task1Entities())
            {


                var query = (from ps in db.ProductSold
                         join c in db.Customer on ps.Customer_Id equals c.Id
                         join p in db.Product on ps.Product_Id equals p.Id
                         join s in db.Store on ps.Store_Id equals s.Id
                         select new
                         {
                             
                             c.Cust_Name,
                             p.Product_Name,
                             s.Store_Name,
                             ps.Date_Sold
                         }).ToList();


                foreach (var item in query)
                {
                    SaleInfo sale = new SaleInfo();

                    sale.Cust_Name = item.Cust_Name;
                    sale.Product_Name = item.Product_Name;
                    sale.Store_Name = item.Store_Name;
                    sale.Date_Sold = item.Date_Sold;
                    
                    model.Add(sale);
                }

            }

            return View("SaleIndex", model);
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            return View("Createsale");
        }

        // POST: Sale/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sale/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
