using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Task1.Controllers
{
    public class CustomerController : Controller
    {
        Task1Entities db = new Task1Entities();

        // GET: Customer
        public ActionResult Index()
        {
            var model = new List<Customer>();


            using (var db = new Task1Entities())
            {

                var query = db.Customer.Select(row => row);

                foreach (var item in query)
                {
                    Customer customer = new Customer();


                    customer.Cust_Name = item.Cust_Name;
                    customer.Cust_Address = item.Cust_Address;
                    customer.Id = item.Id;
                    model.Add(customer);

                }
               // var data1 = new JavaScriptSerializer().Deserialize(customer, typeof(IEnumerable<Customer>));

            }
            return View("CustomerIndex", model);
        }


        public JsonResult List()
        {
            using (var db = new Task1Entities())
            {
                var customer = db.Customer.Select(x => new
                {
                    x.Id,
                    x.Cust_Name,
                    x.Cust_Address,
                }).ToList();
                return Json(customer, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {

            try
            {
                // TODO: Add insert logic here

                using (var db = new Task1Entities())
                {

                    bool exist = db.Customer.Where(x => x.Cust_Name == customer.Cust_Name).Any();

                    Customer cust = new Customer();
                    cust.Cust_Name = customer.Cust_Name;
                    cust.Cust_Address = customer.Cust_Address;


                    if (!exist) //check to updat eor create
                    {
                        db.Customer.Add(cust);
                    }
                    else
                    {
                        cust = db.Customer.SingleOrDefault(x => x.Cust_Name == customer.Cust_Name);
                        cust.Cust_Name = customer.Cust_Name;
                        cust.Cust_Address = customer.Cust_Address;
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new List<Customer>();

            Customer customer = new Customer();
            using (var db = new Task1Entities())
            {
                var query = db.Customer.Where(row => row.Id == id);
                foreach (var item in query)

                {

                    customer.Cust_Name = item.Cust_Name;
                    customer.Cust_Address = item.Cust_Address;
                    customer.Id = item.Id;
                    model.Add(customer);
                }

            }
            return View("CustomerIndex", model);
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = new Customer();
            using (var db = new Task1Entities())
            {
                var query = db.Customer.Where(row => row.Id == id);
                foreach (var item in query)

                {
                    customer.Cust_Name = item.Cust_Name;
                    customer.Cust_Address = item.Cust_Address;
                    customer.Id = item.Id;
                }

            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add insert logic here

                using (var db = new Task1Entities())
                {

                    Customer cust = db.Customer.SingleOrDefault(x => x.Id == customer.Id);
                    db.Customer.Remove(cust);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return View();
            }
        }

      

    }
}
