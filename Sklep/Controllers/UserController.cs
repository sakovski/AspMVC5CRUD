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
    public class UserController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: User
        public ActionResult MoviesList()
        {
            var movies = db.Movies.Include(m => m.Director).Include(m => m.Genre).OrderBy(m => m.Title);
            return View(movies.ToList());       
        }

        public ActionResult MovieDetails(int? id)
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

        public ActionResult DirectorsList()
        {
            return View(db.Directors.OrderBy(d => d.LastName).ToList());
        }

        public ActionResult DirectorDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Include(m => m.Movies).First(i => i.DirectorID == id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        public ActionResult GenresList()
        {
            var genres = db.Genres.Include(m => m.Movies);
            return View(genres);
        }

        public ActionResult GenreDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movies = db.Movies.Where(m => m.GenreId == id).OrderBy(m => m.Title).ToList();
            var genreName = db.Genres.Where(g => g.GenreID == id).Select(g => g.GenreName).FirstOrDefault().ToString();
            ViewBag.GenreName = genreName;
            return View(movies);
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