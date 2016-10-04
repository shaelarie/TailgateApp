using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TailgateLive.Models;

namespace TailgateLive.Controllers
{
    public class UsersEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UsersEvents
        public ActionResult Index()
        {
            var usersEvents = db.UsersEvents.Include(u => u.Event).Include(u => u.User);
            return View(usersEvents.ToList());
        }

        // GET: UsersEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersEvents usersEvents = db.UsersEvents.Find(id);
            if (usersEvents == null)
            {
                return HttpNotFound();
            }
            return View(usersEvents);
        }

        // GET: UsersEvents/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.EventDb, "Id", "EventTitle");
            ViewBag.UserId = new SelectList(db.UserDb, "Id", "UserName");
            return View();
        }

        // POST: UsersEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,EventId")] UsersEvents usersEvents)
        {
            if (ModelState.IsValid)
            {
                db.UsersEvents.Add(usersEvents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.EventDb, "Id", "EventTitle", usersEvents.EventId);
            ViewBag.UserId = new SelectList(db.UserDb, "Id", "UserName", usersEvents.UserId);
            return View(usersEvents);
        }

        // GET: UsersEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersEvents usersEvents = db.UsersEvents.Find(id);
            if (usersEvents == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.EventDb, "Id", "EventTitle", usersEvents.EventId);
            ViewBag.UserId = new SelectList(db.UserDb, "Id", "UserName", usersEvents.UserId);
            return View(usersEvents);
        }

        // POST: UsersEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,EventId")] UsersEvents usersEvents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersEvents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.EventDb, "Id", "EventTitle", usersEvents.EventId);
            ViewBag.UserId = new SelectList(db.UserDb, "Id", "UserName", usersEvents.UserId);
            return View(usersEvents);
        }

        // GET: UsersEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersEvents usersEvents = db.UsersEvents.Find(id);
            if (usersEvents == null)
            {
                return HttpNotFound();
            }
            return View(usersEvents);
        }

        // POST: UsersEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersEvents usersEvents = db.UsersEvents.Find(id);
            db.UsersEvents.Remove(usersEvents);
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
