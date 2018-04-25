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
    public class phones1Controller : Controller
    {
        // db connection moved to EFphones1Repository
        //private Model1 db = new Model1();
        private IMockphones1Repository db;

        // default constructor - no dependency incoming => use the database

            public phones1Controller()
        {


            this.db = new EFphones1Repository();

        }

        // mock constructor - mock object passed as a dependency for unit testing

            public phones1Controller(IMockphones1Repository mockRepo)
        {

            this.db = mockRepo;

        }
        // GET: phones1
        public ActionResult Index()
        {
            return View(db.Phones1.ToList());
        }

        // GET: phones1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
           }
            // original code for ef only
            //phones1 phones1 = db.phones1.Find(id);

            // new code for  ef or unit testing
            phones1 phones = db.Phones1.SingleOrDefault(a => a.phoneID == id);

            if (phones == null)
            {
                //return HttpNotFound();
                return View("Error");

            }
            return View(phones);
        }

        // GET: phones1/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: phones1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "phoneID,phones,color")] phones1 phones1)
        {
            if (ModelState.IsValid)
            {
                //db.phones1.Add(phones1);
                //db.SaveChanges();
                db.Save(phones1);
                return RedirectToAction("Index");
            }

           return View("Create", phones1);
        }

        // GET: phones1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
           }
            //phones1 phones1 = db.phones1.Find(id);
            phones1 phones = db.Phones1.SingleOrDefault(a => a.phoneID == id);
           if (phones == null)
           {
                //return HttpNotFound();
                return View("Error");
            }
            return View(phones);
        }

        //// POST: phones1/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "phoneID,phones,color")] phones1 phones1)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(phones).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(phones1);
               return RedirectToAction("Index");
            }
            return View("Edit", phones1);
        }

        // GET: phones1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //phones1 phones1 = db.phones1.Find(id);
            phones1 phones = db.Phones1.SingleOrDefault(a => a.phoneID == id);
            if (phones == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View(phones);
        }

        // POST: phones1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //phones1 phones1 = db.phones1.Find(id);
            phones1 phones = db.Phones1.SingleOrDefault(a => a.phoneID == id);
            //db.phones1.Remove(phones);
            //db.SaveChanges();
            db.Delete(phones);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
