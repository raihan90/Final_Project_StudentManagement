﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PzojectClassWordFriday.Models;

namespace PzojectClassWordFriday.Controllers
{
    public class SemesterController : Controller
    {
        private UniDbContext db = new UniDbContext();

        // GET: /Semester/
        public ActionResult Index()
        {
            return View(db.SemisterDbSet.ToList());
        }

        // GET: /Semester/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semister semister = db.SemisterDbSet.Find(id);
            if (semister == null)
            {
                return HttpNotFound();
            }
            return View(semister);
        }

        // GET: /Semester/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Semester/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SemisterId,SemisterName")] Semister semister)
        {
            if (ModelState.IsValid)
            {
                db.SemisterDbSet.Add(semister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semister);
        }

        // GET: /Semester/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semister semister = db.SemisterDbSet.Find(id);
            if (semister == null)
            {
                return HttpNotFound();
            }
            return View(semister);
        }

        // POST: /Semester/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SemisterId,SemisterName")] Semister semister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semister);
        }

        // GET: /Semester/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semister semister = db.SemisterDbSet.Find(id);
            if (semister == null)
            {
                return HttpNotFound();
            }
            return View(semister);
        }

        // POST: /Semester/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semister semister = db.SemisterDbSet.Find(id);
            db.SemisterDbSet.Remove(semister);
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
