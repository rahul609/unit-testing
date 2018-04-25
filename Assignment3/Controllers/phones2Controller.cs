using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class phones2Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: phones2
        public ActionResult Index()
        {
            return View(db.phones2.ToList());
        }

        // GET: phones2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phones2 phones2 = db.phones2.Find(id);
            if (phones2 == null)
            {
                return HttpNotFound();
            }
            return View(phones2);
        }

        // GET: phones2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: phones2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerno_,brand,phoneID")] phones2 phones2)
        {
            if (ModelState.IsValid)
            {
                db.phones2.Add(phones2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phones2);
        }

        // GET: phones2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phones2 phones2 = db.phones2.Find(id);
            if (phones2 == null)
            {
                return HttpNotFound();
            }
            return View(phones2);
        }

        // POST: phones2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerno_,brand,phoneID")] phones2 phones2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phones2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phones2);
        }

        // GET: phones2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phones2 phones2 = db.phones2.Find(id);
            if (phones2 == null)
            {
                return HttpNotFound();
            }
            return View(phones2);
        }

        // POST: phones2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            phones2 phones2 = db.phones2.Find(id);
            db.phones2.Remove(phones2);
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
    }
}
