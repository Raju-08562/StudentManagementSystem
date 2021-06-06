using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem;

namespace StudentManagementSystem.Controllers
{
    public class Course_RegistrationController : Controller
    {
        private StudentManagementSystemEntities db = new StudentManagementSystemEntities();

        // GET: Course_Registration
        public ActionResult Index()
        {
            var course_Registrations = db.Course_Registrations.Include(c => c.BatchTable).Include(c => c.CourseTable);
            return View(course_Registrations.ToList());
        }

        // GET: Course_Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Registration course_Registration = db.Course_Registrations.Find(id);
            if (course_Registration == null)
            {
                return HttpNotFound();
            }
            return View(course_Registration);
        }

        // GET: Course_Registration/Create
        public ActionResult Create()
        {
            ViewBag.Batch_ID = new SelectList(db.BatchTables, "ID", "Batch_Name");
            ViewBag.Course_ID = new SelectList(db.CourseTables, "ID", "Course_Name");
            return View();
        }

        // POST: Course_Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,Course_ID,Batch_ID")] Course_Registration course_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Course_Registrations.Add(course_Registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Batch_ID = new SelectList(db.BatchTables, "ID", "Batch_Name", course_Registration.Batch_ID);
            ViewBag.Course_ID = new SelectList(db.CourseTables, "ID", "Course_Name", course_Registration.Course_ID);
            return View(course_Registration);
        }

        // GET: Course_Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Registration course_Registration = db.Course_Registrations.Find(id);
            if (course_Registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Batch_ID = new SelectList(db.BatchTables, "ID", "Batch_Name", course_Registration.Batch_ID);
            ViewBag.Course_ID = new SelectList(db.CourseTables, "ID", "Course_Name", course_Registration.Course_ID);
            return View(course_Registration);
        }

        // POST: Course_Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Course_ID,Batch_ID")] Course_Registration course_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Batch_ID = new SelectList(db.BatchTables, "ID", "Batch_Name", course_Registration.Batch_ID);
            ViewBag.Course_ID = new SelectList(db.CourseTables, "ID", "Course_Name", course_Registration.Course_ID);
            return View(course_Registration);
        }

        // GET: Course_Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Registration course_Registration = db.Course_Registrations.Find(id);
            if (course_Registration == null)
            {
                return HttpNotFound();
            }
            return View(course_Registration);
        }

        // POST: Course_Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Registration course_Registration = db.Course_Registrations.Find(id);
            db.Course_Registrations.Remove(course_Registration);
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
