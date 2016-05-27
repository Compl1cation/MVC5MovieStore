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
    public class HomeController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult MovieSearch(string q)
        {
            var movies = GetMovies(q);
            return PartialView(movies);
        }

        private List<Movie> GetMovies(string searchString)
        {
            return db.Movies
                .Where(a => a.Title.Contains(searchString))
                .ToList();
        }
    }
}