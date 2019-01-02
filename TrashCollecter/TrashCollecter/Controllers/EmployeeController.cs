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
            return View();
        }



        public ActionResult FilterByDate(string date)
        {
            var SearchDate = from m in db.EmployeeModels
                             select m;
            if (!string.IsNullOrEmpty(date))
            {
                SearchDate = SearchDate.Where(s => s.CustomerModels.ToString().Contains(date));
            }
            return View(SearchDate);
        }
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "Name");
            return View();
        }
        // GET: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Street")] EmployeeModel employeeModel)
        {
            if(ModelState.IsValid)
            {
                db.EmployeeModels.Add(employeeModel);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = employeeModel.Id });
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
                return RedirectToAction("Index");
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
