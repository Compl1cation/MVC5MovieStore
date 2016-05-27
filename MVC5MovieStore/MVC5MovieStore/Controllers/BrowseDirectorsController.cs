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
    public class BrowseDirectorsController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();

        // GET: /BrowseDirectors/
        public ActionResult Index()
        {
            var ranges = db.Directors.Include(d => d.Movies).OrderBy(y => y.Name);
            return View(ranges.ToList());
        }

        // GET: /BrowseDirectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };

            /*Eager Load*/
            IEnumerable<Movie> movies = db.Movies
           .Include(i => i.Director)
           .Include(i => i.Genres)
           .Include(i => i.YearRange)
           .Include(i => i.Files)
           .Where(i => i.DirectorId == id).OrderBy(i => i.Title).ToList();

            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies.ToList());
        }
    }
}
