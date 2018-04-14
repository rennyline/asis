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
    public class asis_tablelogController : Controller
    {
        private dsupportwebappEntities db = new dsupportwebappEntities();

        // GET: asis_tablelog
        public ActionResult Index()
        {
            return View(db.asis_tablelog.ToList());
        }

        // GET: asis_tablelog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_tablelog asis_tablelog = db.asis_tablelog.Find(id);
            if (asis_tablelog == null)
            {
                return HttpNotFound();
            }
            return View(asis_tablelog);
        }

        // GET: asis_tablelog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asis_tablelog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAsisTableLog,IDAsisTableList,IDUser,IDAttRecordOperation,DateOperation,Logchange")] asis_tablelog asis_tablelog)
        {
            if (ModelState.IsValid)
            {
                db.asis_tablelog.Add(asis_tablelog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asis_tablelog);
        }

        // GET: asis_tablelog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_tablelog asis_tablelog = db.asis_tablelog.Find(id);
            if (asis_tablelog == null)
            {
                return HttpNotFound();
            }
            return View(asis_tablelog);
        }

        // POST: asis_tablelog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAsisTableLog,IDAsisTableList,IDUser,IDAttRecordOperation,DateOperation,Logchange")] asis_tablelog asis_tablelog)
        {
            if (ModelState.IsValid)
            {
                asis_tablelog.Logchange = AsisLibrary.AsisHtmlHelper.StripHTML((asis_tablelog.Logchange));

                db.Entry(asis_tablelog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asis_tablelog);
        }

        // GET: asis_tablelog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_tablelog asis_tablelog = db.asis_tablelog.Find(id);
            if (asis_tablelog == null)
            {
                return HttpNotFound();
            }
            return View(asis_tablelog);
        }

        // POST: asis_tablelog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asis_tablelog asis_tablelog = db.asis_tablelog.Find(id);
            db.asis_tablelog.Remove(asis_tablelog);
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
