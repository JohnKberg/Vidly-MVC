﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var Movie = GetMovies().SingleOrDefault(m => m.Id == id);

            if (Movie == null)
                return this.HttpNotFound();

            return View(Movie);
        }

        // GET: Movies
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


        private IEnumerable<Movie> GetMovies()
        {
            var Movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek"},
                new Movie { Id = 2, Name = "Wall-E" }
            };

            return Movies;
        }
    }
}