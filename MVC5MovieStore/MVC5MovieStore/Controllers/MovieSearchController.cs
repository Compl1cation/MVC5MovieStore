using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5MovieStore.Models;

namespace MVC5MovieStore.Controllers
{
    public class MovieSearchController : Controller
    {

        private MovieStoreDB db = new MovieStoreDB();

        public ActionResult Search(string q)
        {
            var movies = GetMovies(q);
            return PartialView("_MovieSearch",movies);
        }

        private IEnumerable<Movie> GetMovies(string searchString)
        {
            IEnumerable<Movie> movs = db.Movies
               .Include("Director")
               .Include("Year")
           .Where(a => a.Title.Contains(searchString) || a.Director.Name.Contains(searchString) || a.Year.ToString().Contains(searchString)).ToList().Take(5);
            return (movs);
        }
	}
}