using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sklep.Models;
using Sklep.Models.DbModels;

namespace Sklep.Controllers
{
    public class MoviesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Director).Include(m => m.Genre);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var directors = db.Directors.Select(s => new { DirectorID = s.DirectorID, FullName = s.FirstName + " " + s.LastName}).ToList();
            ViewBag.DirectorId = new SelectList(directors, "DirectorID", "FullName");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreID", "GenreName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,Title,Description,Country,Language,Minutes,Year,GenreId,DirectorId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var directors = db.Directors.Select(s => new { DirectorID = s.DirectorID, FullName = s.FirstName + " " + s.LastName }).ToList();
            ViewBag.DirectorId = new SelectList(directors, "DirectorID", "FullName", movie.DirectorId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreID", "GenreName", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            
            }
            var directors = db.Directors.Select(s => new { DirectorID = s.DirectorID, FullName = s.FirstName + " " + s.LastName }).ToList();
            ViewBag.DirectorId = new SelectList(directors, "DirectorID", "FullName", movie.DirectorId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreID", "GenreName", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,Title,Description,Country,Language,Minutes,Year,GenreId,DirectorId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var directors = db.Directors.Select(s => new { DirectorID = s.DirectorID, FullName = s.FirstName + " " + s.LastName }).ToList();
            ViewBag.DirectorId = new SelectList(directors, "DirectorID", "FullName", movie.DirectorId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreID", "GenreName", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DirectorDetails(int? id)
        {
            return RedirectToAction("Details", "Directors", new { id = id });
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
