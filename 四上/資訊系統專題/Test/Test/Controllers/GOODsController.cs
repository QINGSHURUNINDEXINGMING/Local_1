﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class GOODsController : Controller
    {
        private ConnectDB db = new ConnectDB();

        // GET: GOODs
        public ActionResult Index()
        {
            return View(db.Good1.ToList());
        }

        // GET: GOODs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOOD gOOD = db.Good1.Find(id);
            if (gOOD == null)
            {
                return HttpNotFound();
            }
            return View(gOOD);
        }

        // GET: GOODs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GOODs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UID,name,price,discount,discount_price")] GOOD gOOD)
        {
            if (ModelState.IsValid)
            {
                double discount_price = 0;
                int price1, discount1;
                price1 = gOOD.price;
                discount1 = gOOD.discount;
                discount_price = (0.1 * discount1) * price1;
                gOOD.discount_price = (int)discount_price;

                db.Good1.Add(gOOD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            
            return View(gOOD);
        }

        // GET: GOODs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOOD gOOD = db.Good1.Find(id);
            if (gOOD == null)
            {
                return HttpNotFound();
            }
            return View(gOOD);
        }

        // POST: GOODs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UID,name,price,discount")] GOOD gOOD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gOOD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gOOD);
        }

        // GET: GOODs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOOD gOOD = db.Good1.Find(id);
            if (gOOD == null)
            {
                return HttpNotFound();
            }
            return View(gOOD);
        }

        // POST: GOODs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GOOD gOOD = db.Good1.Find(id);
            db.Good1.Remove(gOOD);
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
