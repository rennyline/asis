using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSupportWebApp.Models;

namespace DSupportWebApp.Views
{
    public class asis_tablelistController : Controller
    {
        private dsupportwebappEntities db = new dsupportwebappEntities();

        // GET: asis_tablelist
        public ActionResult Index()
        {
            return View(db.asis_tablelist.ToList());
        }

        // GET: asis_tablelist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_tablelist asis_tablelist = db.asis_tablelist.Find(id);
            if (asis_tablelist == null)
            {
                return HttpNotFound();
            }
            return View(asis_tablelist);
        }

        // GET: asis_tablelist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asis_tablelist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAsisTableList,IDAsisModule,SortID,TableName,IsMultiLingual,DescriptionNL,DescriptionEN,IDUserCreated,IDUserModified,DateTimeCreated,DateTimeModified")] asis_tablelist asis_tablelist)
        {
            if (ModelState.IsValid)
            {
                db.asis_tablelist.Add(asis_tablelist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asis_tablelist);
        }

        // GET: asis_tablelist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_tablelist asis_tablelist = db.asis_tablelist.Find(id);
            if (asis_tablelist == null)
            {
                return HttpNotFound();
            }
            return View(asis_tablelist);
        }

        // POST: asis_tablelist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAsisTableList,IDAsisModule,SortID,TableName,IsMultiLingual,DescriptionNL,DescriptionEN,IDUserCreated,IDUserModified,DateTimeCreated,DateTimeModified")] asis_tablelist asis_tablelist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asis_tablelist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asis_tablelist);
        }

        // GET: asis_tablelist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_tablelist asis_tablelist = db.asis_tablelist.Find(id);
            if (asis_tablelist == null)
            {
                return HttpNotFound();
            }
            return View(asis_tablelist);
        }

        // POST: asis_tablelist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asis_tablelist asis_tablelist = db.asis_tablelist.Find(id);
            db.asis_tablelist.Remove(asis_tablelist);
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
