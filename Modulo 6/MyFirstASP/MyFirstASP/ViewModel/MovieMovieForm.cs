using MyFirstASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstASP.ViewModel
{
    public class MovieMovieForm
    {
        public Movie Movie  { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}