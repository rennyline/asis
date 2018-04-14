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
    public class asis_attsubController : Controller
    {
        private dsupportwebappEntities db = new dsupportwebappEntities();

        // GET: asis_attsub
        public ActionResult Index()
        {
            return View(db.asis_attsub.ToList());
        }

        // GET: asis_attsub/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_attsub asis_attsub = db.asis_attsub.Find(id);
            if (asis_attsub == null)
            {
                return HttpNotFound();
            }
            return View(asis_attsub);
        }

        // GET: asis_attsub/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asis_attsub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAttSub,IDAttMain,NameNL,NameEN,SortID,IDUserCreated,IDUserModified,DateCreated,DateModified")] asis_attsub asis_attsub)
        {
            if (ModelState.IsValid)
            {
                db.asis_attsub.Add(asis_attsub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asis_attsub);
        }

        // GET: asis_attsub/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_attsub asis_attsub = db.asis_attsub.Find(id);
            if (asis_attsub == null)
            {
                return HttpNotFound();
            }
            return View(asis_attsub);
        }

        // POST: asis_attsub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAttSub,IDAttMain,NameNL,NameEN,SortID,IDUserCreated,IDUserModified,DateCreated,DateModified")] asis_attsub asis_attsub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asis_attsub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asis_attsub);
        }

        // GET: asis_attsub/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_attsub asis_attsub = db.asis_attsub.Find(id);
            if (asis_attsub == null)
            {
                return HttpNotFound();
            }
            return View(asis_attsub);
        }

        // POST: asis_attsub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asis_attsub asis_attsub = db.asis_attsub.Find(id);
            db.asis_attsub.Remove(asis_attsub);
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
