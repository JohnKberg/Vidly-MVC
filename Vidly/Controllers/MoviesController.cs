using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(c => c.Genre);
            //return View(movies);
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            
            return View("ReadOnlyList");            
        }

        public ActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(m => m.Id == id);

            if (Movie == null)
                return this.HttpNotFound();

            return View(Movie);
        }

        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                { 
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            
            
            if (movie.Id == 0)
            {
                // INSERT

                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                // EDIT 

                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        #region JUNK ACTIONS
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel 
            { 
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
            //return View();
        }

        #endregion
    }
}