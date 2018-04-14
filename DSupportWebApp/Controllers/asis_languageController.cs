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
    public class asis_languageController : Controller
    {
        private dsupportwebappEntities db = new dsupportwebappEntities();

        // GET: asis_language
        public ActionResult Index()
        {
            return View(db.asis_language.ToList());
        }

        // GET: asis_language/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_language asis_language = db.asis_language.Find(id);
            if (asis_language == null)
            {
                return HttpNotFound();
            }
            return View(asis_language);
        }

        // GET: asis_language/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asis_language/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAsisLanguage,NameNL,NameEN,Code,SortID,FlagFile,Culture,IsPublished,IDUserCreated,IDUserModified,DateTimeCreated,DateTimeModified")] asis_language asis_language)
        {
            if (ModelState.IsValid)
            {
                db.asis_language.Add(asis_language);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asis_language);
        }

        // GET: asis_language/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_language asis_language = db.asis_language.Find(id);
            if (asis_language == null)
            {
                return HttpNotFound();
            }
            return View(asis_language);
        }

        // POST: asis_language/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAsisLanguage,NameNL,NameEN,Code,SortID,FlagFile,Culture,IsPublished,IDUserCreated,IDUserModified,DateTimeCreated,DateTimeModified")] asis_language asis_language)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asis_language).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asis_language);
        }

        // GET: asis_language/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_language asis_language = db.asis_language.Find(id);
            if (asis_language == null)
            {
                return HttpNotFound();
            }
            return View(asis_language);
        }

        // POST: asis_language/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asis_language asis_language = db.asis_language.Find(id);
            db.asis_language.Remove(asis_language);
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
