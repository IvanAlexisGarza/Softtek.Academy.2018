using MyFirstASP.Models;
using MyFirstASP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstASP.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult MoviesReleasedByDate(int year, int month)
        {
            return Content($"Year: {year} | Month: {month}");
        }

        [Route("movies/GetMovieById/{id}")]
        public ActionResult GetMovieById(int id)
        {
            List<Movie> movies = GetMovies();
            Movie currentMovie = movies.FirstOrDefault(x => x.Id == id);

            if (currentMovie == null)
            {
                Response.Redirect("https://thebest404pageeverredux.com/");
            }

            return Content($"La Movie etz: {currentMovie.Name}");
        }

        public ActionResult MovieForm()
        {
            return View();
        }

        private List<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie{ Id =1, Name= "Shrek"},
                new Movie{ Id =2, Name= "Shrek 2"},
                new Movie{ Id =3, Name= "Shrek 3"},
                new Movie{ Id =4, Name= "Shrek Is Love"},
            };

            return movies;
        }

        private List<Genre> GetGenres()
        {
            var genres = new List<Genre>()
            {
                new Genre{ Id =1, Name= "Shrek"},
                new Genre{ Id =2, Name= "Shrek 2"},
                new Genre{ Id =3, Name= "Shrek 3"},
                new Genre{ Id =4, Name= "Shrek Is Love"},
            };

            return genres;
        }
    }
}