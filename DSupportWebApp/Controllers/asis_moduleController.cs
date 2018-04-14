using System;
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
    public class asis_moduleController : Controller
    {
        private dsupportwebappEntities db = new dsupportwebappEntities();

        // GET: asis_module
        public ActionResult Index()
        {
            return View(db.asis_module.ToList());
        }

        // GET: asis_module/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_module asis_module = db.asis_module.Find(id);
            if (asis_module == null)
            {
                return HttpNotFound();
            }
            return View(asis_module);
        }

        // GET: asis_module/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asis_module/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDModule,NameNL,NameEN,Letter,Prefix,SortID,IDUserCreated,IDUserModified,DateCreated,DateModified")] asis_module asis_module)
        {
            if (ModelState.IsValid)
            {
                db.asis_module.Add(asis_module);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asis_module);
        }

        // GET: asis_module/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_module asis_module = db.asis_module.Find(id);
            if (asis_module == null)
            {
                return HttpNotFound();
            }
            return View(asis_module);
        }

        // POST: asis_module/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDModule,NameNL,NameEN,Letter,Prefix,SortID,IDUserCreated,IDUserModified,DateCreated,DateModified")] asis_module asis_module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asis_module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asis_module);
        }

        // GET: asis_module/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_module asis_module = db.asis_module.Find(id);
            if (asis_module == null)
            {
                return HttpNotFound();
            }
            return View(asis_module);
        }

        // POST: asis_module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asis_module asis_module = db.asis_module.Find(id);
            db.asis_module.Remove(asis_module);
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
