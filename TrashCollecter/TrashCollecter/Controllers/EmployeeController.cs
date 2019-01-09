using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollecter.Models;

namespace TrashCollecter.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            
            return View(db.EmployeeModels.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            ////ViewBag.Id = new SelectList(db.Users, "Id", "Name");
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            return View(employeeModel);
        }

        public ActionResult DefaultZip()
        {
            var userId = User.Identity.GetUserId();
            var CurrentEmployee = (from e in db.EmployeeModels where e.ApplicationId == userId select e).FirstOrDefault();
            var SortedDay = DateTime.Now.DayOfWeek.ToString();
            var CurrentDay = DateTime.Now.Date;
            var custZip = (from c in db.CustomerModels where c.ZipCode == CurrentEmployee.ZipCode select c).ToList();
            if(!custZip.Any())
            {
                return View();
            }
            else
            {
                var searchFound = db.CustomerModels.Where(c => (c.PickUpDay.ToString() == SortedDay) && c.ZipCode == CurrentEmployee.ZipCode).ToList();
                if(!searchFound.Any())
                {
                    return View();
                }
                else
                {
                    return View(searchFound);
                }
            }

        }

        //public ActionResult FilterByDate(string Date)
        //{

        //    var SearchDate = from m in db.CustomerModels
        //                  //   where m.PickUpDay = 
        //                     select m;
        //    CustomerModels customer = new CustomerModels();
        //    if (customer.PickUpDay != Date)
        //    {
        //        ViewBag.Message = "No PickUps Found";
        //        //    SearchDate = SearchDate.Where(s => s.CustomerModels.ToString().Contains(date));
        //    }
        //    else if (customer.PickUpDay == Convert.ToString(Date))
        //    {
        //        SearchDate = SearchDate.Where(s => s.PickUpDay.Contains(Date));

        //    }
        //    return View(SearchDate);
        //}
        public ActionResult FilterByWeekday()
        {
            return View();
        }
        [HttpPost,ActionName("FilterByWeekday")]
        public ActionResult FilterByWeekday(string chosenDay)
        {
            return RedirectToAction("SelectWeekday", new { day = chosenDay });
        }
        public ActionResult SelectWeekday(string day)
        {
            List<CustomerModels> ParticularDayCustomer = new List<CustomerModels>();
            var userId = User.Identity.GetUserId();
            var currentEmployee = (from e in db.EmployeeModels where e.ApplicationId == userId select e).FirstOrDefault();
            var customerZip = (from c in db.CustomerModels where c.ZipCode == currentEmployee.ZipCode select c).ToList();
            if (customerZip.Any())

            {
                foreach (var SpecialPickups in customerZip)
                {
                    var pickupDateString = SpecialPickups.ToString();
                    string specificDatePickup = null;
                    if (pickupDateString != "")
                    {
                        specificDatePickup = DateTime.Parse(pickupDateString).DayOfWeek.ToString();
                    }
                    if ((SpecialPickups.PickUpDay.ToString() == day || specificDatePickup == day))

                    {
                        ParticularDayCustomer.Add(SpecialPickups);
                    }
                }
            }
            ViewBag.dayToSee = day;
            return View(ParticularDayCustomer);
        }


    

    public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "Name");
            return View();
        }
        // GET: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
         
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Street,ZipCode")] EmployeeModel employeeModel)
        {
            if(ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                employeeModel.ApplicationId = user;
                db.EmployeeModels.Add(employeeModel);
                db.SaveChanges();
                return RedirectToAction("DefaultZip", new { id = employeeModel.Id });
            }
            return View(employeeModel);
        }

        // POST: Employee/Create
        

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            return View(employeeModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Street")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeModel).State =EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DefaultZip");
            }
            return View(employeeModel);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }
        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            db.EmployeeModels.Remove(employeeModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
