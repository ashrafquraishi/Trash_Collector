using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollecter.Models;

namespace TrashCollecter.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerModels
        public ActionResult Index()
        {

            
            return View(db.CustomerModels.ToList());


        }
    
        // GET: CustomerModels/Details/5
        public ActionResult Details(int? id)
        {                                                                                                                                                                                                                                                                                                                                  
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = db.CustomerModels.Find(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }

        // GET: CustomerModels/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: CustomerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Address,ZipCode,City,State,PickUpDay")] CustomerModels customerModels)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                customerModels.ApplicationUserId = userId; 

                db.CustomerModels.Add(customerModels);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customerModels.Id });
            }

            return View(customerModels);
        }

        // GET: CustomerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            
            CustomerModels customerModels = db.CustomerModels.Find(id);
            return View(customerModels);
        }

        // POST: CustomerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Address,ZipCode,City,State,PickUpDay")] CustomerModels customerModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(customerModels);
        }

        // GET: CustomerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = db.CustomerModels.Find(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }
       // [HttpPost]
        public ActionResult FilterByDate(string date)
        {
            var SearchDate = from m in db.CustomerModels
                             select m;
            if (!string.IsNullOrEmpty(date))
            {
                SearchDate = SearchDate.Where(s => s.PickUpDay.ToString().Contains(date));
            }
            return View(SearchDate);
        }

        // POST: CustomerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerModels customerModels = db.CustomerModels.Find(id);
            db.CustomerModels.Remove(customerModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }  

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult CreateSpecialPickup()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult CreateSpecialPickup([Bind(Include = "SpecialPickupDate")] CustomerModels customerModels)
        {
            
                var userId = User.Identity.GetUserId();
                customerModels.ApplicationUserId = userId;

                var currentCustomer = (from c in db.CustomerModels where c.ApplicationUserId == userId select c).FirstOrDefault();
                currentCustomer.SpecialPickupDate = customerModels.SpecialPickupDate;

                db.SaveChanges();
                return RedirectToAction("SpecialDetails", new { id = customerModels.Id });
            

            return View(customerModels);
        }









        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateSpecialPickup([Bind(Include = "SpecialPickupDate")]CustomerModels customerModels)
        //{
        //    if (!ModelState.IsValid)
        //    {

        //        var userId = User.Identity.GetUserId();
        //        customerModels.ApplicationUserId = userId;
        //        var currentCustomer = (from c in db.CustomerModels where c.ApplicationUserId == userId select c).FirstOrDefault();
        //        currentCustomer.SpecialPickupDate = customerModels.SpecialPickupDate;
                


        //        db.SaveChanges();
        //        return RedirectToAction("SpecialDetails", new { id = customerModels.Id });
        //    }


        //    return View(customerModels);
        //}

        public ActionResult SpecialDetails()
        {

            var FoundUserId = User.Identity.GetUserId();
            CustomerModels customer = db.CustomerModels.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            return View(customer);
        }

        public ActionResult EditSpecialPickup(int? id)
        {

            CustomerModels customer = db.CustomerModels.Find(id);

            return View(customer);
        }
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult EditSpecial([Bind(Include = " SpecialPickupDate")] CustomerModels customerModels, int id)
        {
            if (ModelState.IsValid)
            {
                CustomerModels updatedCustomer = db.CustomerModels.Find(id);
                if (updatedCustomer == null)
                {
                    return RedirectToAction("DisplayError", "Customer");
                }
                updatedCustomer.SpecialPickupDate = customerModels.SpecialPickupDate;
               

                db.Entry(updatedCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DetailsOfSpecialPickup");
            }
            return View(customerModels);
        }


    }
}
