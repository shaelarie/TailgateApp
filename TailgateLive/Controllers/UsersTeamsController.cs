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
    public class UsersTeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UsersTeams
        public ActionResult Index()
        {
            var usersTeams = db.UsersTeams.Include(u => u.Team).Include(u => u.User);
            return View(usersTeams.ToList());
        }

        // GET: UsersTeams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTeams usersTeams = db.UsersTeams.Find(id);
            if (usersTeams == null)
            {
                return HttpNotFound();
            }
            return View(usersTeams);
        }

        // GET: UsersTeams/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.TeamDb, "Id", "TeamName");
            ViewBag.UserId = new SelectList(db.UserDb, "Id", "UserName");
            return View();
        }

        // POST: UsersTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,TeamId")] UsersTeams usersTeams)
        {
            if (ModelState.IsValid)
            {
                db.UsersTeams.Add(usersTeams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.TeamDb, "Id", "TeamName", usersTeams.TeamId);
            ViewBag.UserId = new SelectList(db.UserDb, "Id", "UserName", usersTeams.UserId);
            return View(usersTeams);
        }

        // GET: UsersTeams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTeams usersTeams = db.UsersTeams.Find(id);
            if (usersTeams == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.TeamDb, "Id", "TeamName", usersTeams.TeamId);
            ViewBag.UserId = new SelectList(db.UserDb, "Id", "UserName", usersTeams.UserId);
            return View(usersTeams);
        }

        // POST: UsersTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,TeamId")] UsersTeams usersTeams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersTeams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.TeamDb, "Id", "TeamName", usersTeams.TeamId);
            ViewBag.UserId = new SelectList(db.UserDb, "Id", "UserName", usersTeams.UserId);
            return View(usersTeams);
        }

        // GET: UsersTeams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTeams usersTeams = db.UsersTeams.Find(id);
            if (usersTeams == null)
            {
                return HttpNotFound();
            }
            return View(usersTeams);
        }

        // POST: UsersTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersTeams usersTeams = db.UsersTeams.Find(id);
            db.UsersTeams.Remove(usersTeams);
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
