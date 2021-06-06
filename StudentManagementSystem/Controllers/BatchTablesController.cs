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
    public class BatchTablesController : Controller
    {
        private StudentManagementSystemEntities db = new StudentManagementSystemEntities();

        // GET: BatchTables
        public ActionResult Index()
        {
            return View(db.BatchTables.ToList());
        }

        // GET: BatchTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatchTable batchTable = db.BatchTables.Find(id);
            if (batchTable == null)
            {
                return HttpNotFound();
            }
            return View(batchTable);
        }

        // GET: BatchTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BatchTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Batch_Name,IsActive")] BatchTable batchTable)
        {
            if (ModelState.IsValid)
            {
                db.BatchTables.Add(batchTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(batchTable);
        }

        // GET: BatchTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatchTable batchTable = db.BatchTables.Find(id);
            if (batchTable == null)
            {
                return HttpNotFound();
            }
            return View(batchTable);
        }

        // POST: BatchTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Batch_Name,IsActive")] BatchTable batchTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batchTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(batchTable);
        }

        // GET: BatchTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatchTable batchTable = db.BatchTables.Find(id);
            if (batchTable == null)
            {
                return HttpNotFound();
            }
            return View(batchTable);
        }

        // POST: BatchTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BatchTable batchTable = db.BatchTables.Find(id);
            db.BatchTables.Remove(batchTable);
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
