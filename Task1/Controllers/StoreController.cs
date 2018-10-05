using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class StoreController : Controller
    {
        Task1Entities db = new Task1Entities();

        // GET: Store
        public ActionResult Index()
        {

            
            var model = new List<Store>();

            using (var db = new Task1Entities())
            {

                var query = db.Store.Select(row => row);

                foreach (var item in query)
                {
                    Store store = new Store();


                    store.Store_Name = item.Store_Name;
                    store.Store_Address = item.Store_Address;
                    store.Id = item.Id;

                    model.Add(store);
                }

            }
            return View("StoreIndex",model);
        }

        public JsonResult List()
        {
            using (var db = new Task1Entities())
            {
                var customer = db.Store.Select(x => new
                {
                    x.Id,
                    x.Store_Name,
                    x.Store_Address,
                }).ToList();
                return Json(customer, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            Product product = new Product();
            using (var db = new Task1Entities())
            {
                var query = db.Product.Where(row => row.Id==id);
                foreach (var item in query)

                {
                    
                    product.Product_Name = item.Product_Name;
                    product.Product_Price = item.Product_Price;
                    product.Id = item.Id;
                }

            }
                return View(product);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(Store store)
        {

            try
            {
                // TODO: Add insert logic here

                using (var db = new Task1Entities())
                {

                    bool exist = db.Store.Where(x => x.Store_Name == store.Store_Name).Any();

                    Store str = new Store();
                    str.Store_Name = store.Store_Name;
                    str.Store_Address = store.Store_Address;


                    if (!exist) //check to updat eor create
                    {
                        db.Store.Add(str);
                    }
                    else
                    {
                        str = db.Store.SingleOrDefault(x => x.Store_Name == store.Store_Name);
                        str.Store_Name = store.Store_Name;
                        str.Store_Address = store.Store_Address;
                    }
                    // executes the commands to implement the changes to the database
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
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

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            Store store = new Store();
            using (var db = new Task1Entities())
            {
                var query = db.Store.Where(row => row.Id == id);
                foreach (var item in query)

                {
                    store.Store_Name = item.Store_Name;
                    store.Store_Address = item.Store_Address;
                    store.Id = item.Id;
                }

            }
            return View(store);
        }
        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Store store)
        {
            try
            {
                // TODO: Add insert logic here

                using (var db = new Task1Entities())
                {

                    Store str= db.Store.SingleOrDefault(x => x.Id == store.Id);
                    db.Store.Remove(str);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return View();
            }
        }

      

      

    }
}
