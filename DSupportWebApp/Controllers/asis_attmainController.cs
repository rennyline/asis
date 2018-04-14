﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSupportWebApp.Models;

namespace DSupportWebApp.Controllers
{
    public class asis_attmainController : AsisBaseController
    {
        private dsupportwebappEntities db = new dsupportwebappEntities();

        // GET: asis_attmain
        //public ActionResult Index()
        //{
        //    var result = View(db.asis_attmain.ToList());
        //    return base.Intialize(result,"asis",1);
        //}

        // GET: asis_attmain/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_attmain asis_attmain = db.asis_attmain.Find(id);
            if (asis_attmain == null)
            {
                return HttpNotFound();
            }
            return View(asis_attmain);
        }

        // GET: asis_attmain/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asis_attmain/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAtMain,NameNL,NameEN,IDUserCreated,IDUserModified,DateCreated,DateModified")] asis_attmain asis_attmain)
        {
            if (ModelState.IsValid)
            {
                db.asis_attmain.Add(asis_attmain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asis_attmain);
        }

        // GET: asis_attmain/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.user_list = db.user_list.Select(u => new SelectListItem {Value = u.IDUser.ToString(), Text = u.Username}).ToList();

            asis_attmain asis_attmain = db.asis_attmain.Find(id);
            if (asis_attmain == null)
            {
                return HttpNotFound();
            }

            base.BeforeEdit(asis_attmain);

            return View(asis_attmain);
        }

        // POST: asis_attmain/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAttMain,NameNL,NameEN,IDUserCreated,IDUserModified,DateCreated,DateModified")] asis_attmain asis_attmain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asis_attmain).State = EntityState.Modified;
                db.SaveChanges();
                base.AfterEdit(asis_attmain, 1, Convert.ToInt32(Session["IDUser"]), "asis_attmain");
                return RedirectToAction("Index");
            }
            return View(asis_attmain);
        }

        // GET: asis_attmain/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_attmain asis_attmain = db.asis_attmain.Find(id);
            if (asis_attmain == null)
            {
                return HttpNotFound();
            }
            return View(asis_attmain);
        }

        // POST: asis_attmain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asis_attmain asis_attmain = db.asis_attmain.Find(id);
            db.asis_attmain.Remove(asis_attmain);
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
