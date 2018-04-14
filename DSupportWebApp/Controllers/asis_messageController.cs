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
    public class asis_messageController : Controller
    {
        private dsupportwebappEntities db = new dsupportwebappEntities();

        // GET: asis_message
        public ActionResult Index()
        {
            return View(db.asis_message.ToList());
        }

        // GET: asis_message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_message asis_message = db.asis_message.Find(id);
            if (asis_message == null)
            {
                return HttpNotFound();
            }
            return View(asis_message);
        }

        // GET: asis_message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asis_message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMessage,IDAttMessageType,NameNL,NameEN,IDUserCreated,IDUserModified,DateCreated,DateModified")] asis_message asis_message)
        {
            if (ModelState.IsValid)
            {
                db.asis_message.Add(asis_message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asis_message);
        }

        // GET: asis_message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_message asis_message = db.asis_message.Find(id);
            if (asis_message == null)
            {
                return HttpNotFound();
            }
            return View(asis_message);
        }

        // POST: asis_message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMessage,IDAttMessageType,NameNL,NameEN,IDUserCreated,IDUserModified,DateCreated,DateModified")] asis_message asis_message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asis_message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asis_message);
        }

        // GET: asis_message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asis_message asis_message = db.asis_message.Find(id);
            if (asis_message == null)
            {
                return HttpNotFound();
            }
            return View(asis_message);
        }

        // POST: asis_message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asis_message asis_message = db.asis_message.Find(id);
            db.asis_message.Remove(asis_message);
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
