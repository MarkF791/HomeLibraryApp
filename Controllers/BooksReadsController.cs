using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeLibraryApp.Models;

namespace HomeLibraryApp.Controllers
{
    public class BooksReadsController : Controller
    {
        private MarkBookDbEntities db = new MarkBookDbEntities();

        // GET: BooksReads
        public ActionResult Index()
        {
            var booksReads = db.booksReads.Include(b => b.book).Include(b => b.reader);
            return View(booksReads.ToList());
        }

        // GET: BooksReads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booksRead booksRead = db.booksReads.Find(id);
            if (booksRead == null)
            {
                return HttpNotFound();
            }
            return View(booksRead);
        }

        // GET: BooksReads/Create
        public ActionResult Create()
        {
            ViewBag.Book_id = new SelectList(db.books, "Book_id", "Title");
            ViewBag.Reader_id = new SelectList(db.readers, "Reader_id", "FirstName");
            return View();
        }

        // POST: BooksReads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BooksRead_id,Book_id,Reader_id,DateRead")] booksRead booksRead)
        {
            if (ModelState.IsValid)
            {
                db.booksReads.Add(booksRead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_id = new SelectList(db.books, "Book_id", "Title", booksRead.Book_id);
            ViewBag.Reader_id = new SelectList(db.readers, "Reader_id", "FirstName", booksRead.Reader_id);
            return View(booksRead);
        }

        // GET: BooksReads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booksRead booksRead = db.booksReads.Find(id);
            if (booksRead == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_id = new SelectList(db.books, "Book_id", "Title", booksRead.Book_id);
            ViewBag.Reader_id = new SelectList(db.readers, "Reader_id", "FirstName", booksRead.Reader_id);
            return View(booksRead);
        }

        // POST: BooksReads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BooksRead_id,Book_id,Reader_id,DateRead")] booksRead booksRead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booksRead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_id = new SelectList(db.books, "Book_id", "Title", booksRead.Book_id);
            ViewBag.Reader_id = new SelectList(db.readers, "Reader_id", "FirstName", booksRead.Reader_id);
            return View(booksRead);
        }

        // GET: BooksReads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booksRead booksRead = db.booksReads.Find(id);
            if (booksRead == null)
            {
                return HttpNotFound();
            }
            return View(booksRead);
        }

        // POST: BooksReads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booksRead booksRead = db.booksReads.Find(id);
            db.booksReads.Remove(booksRead);
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
