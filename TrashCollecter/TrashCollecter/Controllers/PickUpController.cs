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
    public class PickUpController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickUp
        public ActionResult Index()
        {
            return View(db.PickUp.ToList());
        }

        // GET: PickUp/Details/5
        public ActionResult Details(int id)
        {
          Daymodel pickUp   = db.PickUp.Find(id);
            return View(pickUp);
        }

        // GET: PickUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PickUp/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,VacationStart,VacationEnd")] Daymodel daymodel)
        {
            if (ModelState.IsValid)
            {
                db.PickUp.Add(daymodel);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = daymodel.Id });
            }

            return View(daymodel);
        }
        // GET: PickUp/Edit/5
        public ActionResult Edit(int? id)
        {
            Daymodel daymodel = db.PickUp.Find(id);
            return View(daymodel);

        }

        // POST: PickUp/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,PickUpDay,VacationStart,VacationEnd,IsActive")] Daymodel daymodel)
        {
            if (ModelState.IsValid)
            { 
                db.Entry(daymodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(daymodel);
        }

        // GET: PickUp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daymodel daymodel = db.PickUp.Find(id);

            if (daymodel == null)
            {
                return HttpNotFound();
            }
            return View(daymodel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Daymodel daymodel = db.PickUp.Find(id);
            db.PickUp.Remove(daymodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
