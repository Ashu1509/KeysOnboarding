using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class ProductController : Controller
    {
        Task1Entities db = new Task1Entities();

        // GET: Store
        public ActionResult Index()
        {


            var model = new List<Product>();


            using (var db = new Task1Entities())
            {

                var query = db.Product.Select(row => row);

                foreach (var item in query)
                {
                    Product product = new Product();


                    product.Product_Name = item.Product_Name;
                    product.Product_Price = item.Product_Price;
                    product.Id = item.Id;
                    model.Add(product);
                }

            }
            return View("Product", model);
        }

        public JsonResult List()
        {
            using (var db = new Task1Entities())
            {
                var customer = db.Product.Select(x => new
                {
                    x.Id,
                    x.Product_Name,
                    x.Product_Price,
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
                var query = db.Product.Where(row => row.Id == id);
                foreach (var item in query)

                {

                    product.Product_Name = item.Product_Name;
                    product.Product_Price = item.Product_Price;
                    product.Id = item.Id;
                }

            }
            return View("ProductDetails", product);
        }

        // GET: Store/Create
        public ActionResult Product_Create()
        {
            return View("Product_Create");
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Product_Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here

                using (var db = new Task1Entities())
                {

                    bool exist = db.Product.Where(x => x.Product_Name == product.Product_Name).Any();

                    Product prod = new Product();
                    prod.Product_Name = product.Product_Name;
                    prod.Product_Price = product.Product_Price;


                    if (!exist) //check to updat eor create
                    {
                        db.Product.Add(prod);
                    }
                    else
                    {
                        prod = db.Product.SingleOrDefault(x => x.Product_Name == product.Product_Name);
                        prod.Product_Name = product.Product_Name;
                        prod.Product_Price = product.Product_Price;
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
            var model = new List<Product>();

            Product product = new Product();
            using (var db = new Task1Entities())
            {
                var query = db.Product.Where(row => row.Id == id);
                foreach (var item in query)

                {

                    product.Product_Name = item.Product_Name;
                    product.Product_Price = item.Product_Price;
                    product.Id = item.Id;
                    model.Add(product);
                }

            }
            return View("Product", model);
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add insert logic here

                using (var db = new Task1Entities())
                {

                    Product prod = db.Product.SingleOrDefault(x => x.Product_Name == product.Product_Name);

                    prod.Product_Name = product.Product_Name;
                    prod.Product_Price = product.Product_Price;
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

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {

            Product product = new Product();
            using (var db = new Task1Entities())
            {
                var query = db.Product.Where(row => row.Id == id);
                foreach (var item in query)

                {
                    product.Product_Name = item.Product_Name;
                    product.Product_Price = item.Product_Price;
                    product.Id = item.Id;
                }

            }
            return View(product);

        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add insert logic here

                using (var db = new Task1Entities())
                {

                    Product prod = db.Product.SingleOrDefault(x => x.Id == product.Id);
                    db.Product.Remove(prod);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

       


    }
}
