using eFilm.Data;
using eFilm.Data.Services.Interfaces;
using eFilm.Data.ViewModels;
using eFilm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Runtime.InteropServices;

namespace eFilm.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            return View(allMovies);

        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);

            }

            return View("Index", allMovies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            return View(movieDetails);

        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid) //if form is invalid then proceeds to repopulate dropdown lists and returns the form view with original data so the user can correct inputs.
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.AddNewMovieAsync(movie); //if form is VALID then calls method AddNewMovie and redirects to Index w all other movies.

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(a => a.ActorId).ToList(), //a is each individual item in the Actors_Movies collection.
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));





            //public async Task<IActionResult> Create()
            //{
            //    var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            //    ViewBag.Cinemas = new SelectList()


            //}





            //public IActionResult Movies()
            //{
            //    IEnumerable<Movie> MovieList = _db.MoviesTable;

            //    return View(MovieList);
            //}

            //public IActionResult Details(int? id)
            //{
            //    var findMovie = _db.MoviesTable.Find(id);
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(findMovie);
            //}

            ////Get
            //public IActionResult Update(int? id)
            //{
            //    var findMovie = _db.MoviesTable.Find(id);
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(findMovie);
            //}

            ////Post
            //public IActionResult PostUpdate(Movie movie)
            //{

            //    if (ModelState.IsValid)
            //    {
            //        _db.MoviesTable.Update(movie);
            //        _db.SaveChanges();
            //        return RedirectToAction("Movies");
            //    }
            //    return View(movie);
            //}

            ////Get
            //public IActionResult Delete(int? id)
            //{
            //    var findMovie = _db.MoviesTable.Find(id);

            //    return View(findMovie);
            //}

            ////Post
            //public IActionResult PostDelete(Movie movie)
            //{
            //    _db.MoviesTable.Remove(movie);
            //    _db.SaveChanges();

            //    return RedirectToAction("Movies");
            //}

            ////Get
            //public IActionResult Create()
            //{
            //    return View();
            //}

            ////Post
            //public IActionResult PostCreate(Movie movie)
            //{
            //    _db.MoviesTable.Add(movie);
            //    _db.SaveChanges();

            //    return RedirectToAction("Movies");
            //}
        }
    }
}

