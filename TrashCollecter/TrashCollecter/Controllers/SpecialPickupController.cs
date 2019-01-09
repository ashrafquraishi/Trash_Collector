using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TrashCollecter.Models
{

    public class SpecialPickupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpecialPickup
        public ActionResult Index()
        {
            return View(db.SpecialPickups.ToList());
        }

        // GET: SpecialPickup/Details/5
        public ActionResult Details(int? id)
        {
           SpecialPickup specialPickup = null;
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var FoundUserId = User.Identity.GetUserId();

                specialPickup = db.SpecialPickups.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
                return View(specialPickup);

            }

            else
            {
                specialPickup = db.SpecialPickups.Find(id);
            }

            if (specialPickup == null)
            {
                return HttpNotFound();
            }
            return View(specialPickup);
        }
        public ActionResult Create()
        {

            ViewBag.Id = new SelectList(db.SpecialPickups, "Id", "Name");
            return View();
        }
        // GET: SpecialPickup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SpecialPickup1,Address,ZipCode,ItemDescription")] SpecialPickup specialPickup)
        {
            if (ModelState.IsValid)
            {
                db.SpecialPickups.Add(specialPickup);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = specialPickup.Id });
            }

            return View(specialPickup);
        }

        // GET: SpecialPickup/Edit/5
        public ActionResult Edit(int? id)
        {

           SpecialPickup specialPickup = db.SpecialPickups.Find(id);
            return View(specialPickup);
        }

        // POST: CustomerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SpecialPickup1,Address,ZipCode,ItemDescription1")] SpecialPickup specialPickup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialPickup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialPickup);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialPickup specialPickup = db.SpecialPickups.Find(id);
            if (specialPickup == null)
            {
                return HttpNotFound();
            }
            return View(specialPickup);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialPickup specialPickup = db.SpecialPickups.Find(id);
            db.SpecialPickups.Remove(specialPickup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
