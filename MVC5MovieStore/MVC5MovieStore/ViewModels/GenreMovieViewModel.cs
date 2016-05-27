using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC5MovieStore.Models;

namespace MVC5MovieStore.ViewModels
{
    public class GenreMovieViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}