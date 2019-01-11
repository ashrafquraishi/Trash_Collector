using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollecter.Models;

namespace TrashCollecter.Controllers
{
    public class EmployeeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();




        public ActionResult Weekday()
        {

            return View();
        }
        [HttpPost, ActionName("Weekday")]
        public ActionResult Weekday(string chosenDay)
        {
            return RedirectToAction("SelectedDay", new { day = chosenDay });
        }
        public ActionResult Index()
        {
            return View(db.EmployeeModels.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {

            EmployeeModels employee = db.EmployeeModels.Find(id);


            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = " Id,FirstName,LastName,Email,Address,State,City,ZipCode")] EmployeeModels employee)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                var currentUser = (from u in db.Users where u.Id == userId select u).First();
                employee.ApplicationUserId = userId;

                db.EmployeeModels.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = employee.Id });
            }


            return View(employee);
        }


        // GET: Employee/Edit/5
        public ActionResult Edit(int? Id)
        {

            EmployeeModels employee = db.EmployeeModels.Find(Id);

            return View(employee);
        }


        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = " Id,FirstName,LastName,Email,Address,State,City,ZipCode")] EmployeeModels employee, int Id)
        {
            if (ModelState.IsValid)
            {
                EmployeeModels employees = db.EmployeeModels.Find(Id);
                if (employees == null)
                {
                    return RedirectToAction("DisplayError", "Employee");
                }
                employees.FirstName = employee.FirstName;
                employees.LastName = employee.LastName;
                employees.Email = employee.Email;
                employees.Address = employee.Address;
                employees.State = employee.State;
                employees.City = employee.City;
                employees.ZipCode = employee.ZipCode;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(employee);

        }

        public ActionResult CustomerDetails(int? id)
        {
            CustomerModels customer = null;
            if (id == null)
            {


                var UserId = User.Identity.GetUserId();

                customer = db.CustomerModels.Where(c => c.ApplicationUserId == UserId).FirstOrDefault();
                return View(customer);

            }

            else
            {
                customer = db.CustomerModels.Find(id);
            }

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult DefaultPickups()
        {
            var userId = User.Identity.GetUserId();
            var EmployeeLoggedin = (from e in db.EmployeeModels where e.ApplicationUserId == userId select e).FirstOrDefault();
            var ScheduledDay = DateTime.Now.DayOfWeek.ToString();
            var ScheduledDate = DateTime.Now.Date;
            var cusZipCode = (from c in db.CustomerModels where c.ZipCode == EmployeeLoggedin.ZipCode select c).ToList();
            if (!cusZipCode.Any())
            {
                return View();
            }
            else
            {
                var AnalyzePickups = db.CustomerModels.Where(c => (c.SpecialPickupDate == ScheduledDate || c.PickUpDay.ToString() == ScheduledDay));
                if (!AnalyzePickups.Any())
                {
                    return View();
                }
                else
                {
                    return View(AnalyzePickups);
                }
            }
        }


        public ActionResult SelectedDay(string day)
        {
            List<CustomerModels>SelectedDayCustomer = new List<CustomerModels>();
            var userId = User.Identity.GetUserId();
            var EmployeeLoggedIn = (from e in db.EmployeeModels where e.ApplicationUserId == userId select e).FirstOrDefault();
            var custZipCode = (from c in db.CustomerModels where c.ZipCode == EmployeeLoggedIn.ZipCode select c).ToList();
            if (custZipCode.Any())
            {
                foreach (var customer in custZipCode)
                {
                    var pickupDate = customer.SpecialPickupDate.ToString();
                    string ParticularPickup = null;

                    if (pickupDate != "")
                    {
                        ParticularPickup = DateTime.Parse(pickupDate).DayOfWeek.ToString();
                    }
                    if ((customer.PickUpDay.ToString() == day || ParticularPickup == day))

                    {
                        SelectedDayCustomer.Add(customer);
                    }



                }
            }

                ViewBag.dayToSee = day;
                return View(SelectedDayCustomer);
           
        }
    }
}