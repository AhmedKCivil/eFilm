using eFilm.Data;
using eFilm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace eFilm.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MoviesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Movies()
        {
            IEnumerable<Movie> MovieList = _db.MoviesTable;

            return View(MovieList);
        }

        public IActionResult Details(int? id)
        {
            var findMovie = _db.MoviesTable.Find(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(findMovie);
        }

        //Get
        public IActionResult Update(int? id)
        {
            var findMovie = _db.MoviesTable.Find(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(findMovie);
        }

        //Post
        public IActionResult PostUpdate(Movie movie)
        {

            if (ModelState.IsValid)
            {
                _db.MoviesTable.Update(movie);
                _db.SaveChanges();
                return RedirectToAction("Movies");
            }
            return View(movie);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            var findMovie = _db.MoviesTable.Find(id);

            return View(findMovie);
        }

        //Post
        public IActionResult PostDelete(Movie movie)
        {
            _db.MoviesTable.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction("Movies");
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        public IActionResult PostCreate(Movie movie)
        {
            _db.MoviesTable.Add(movie);
            _db.SaveChanges();

            return RedirectToAction("Movies");
        }


    }
}
