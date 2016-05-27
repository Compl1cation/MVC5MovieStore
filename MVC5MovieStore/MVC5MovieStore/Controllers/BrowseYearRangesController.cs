using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5MovieStore.Models;
using MVC5MovieStore.CustomFilters;

namespace MVC5MovieStore.Controllers
{
    public class BrowseYearRangesController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();

        // GET: /Default1/
        public ActionResult Index()
        {

            var ranges = db.YearRanges.Include(m => m.Movies).OrderBy(y => y.Range);
            return View(ranges.ToList());
        }

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
            .Where(i => i.YearRangeId == id).OrderBy( i => i.Title).ToList();


            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies.ToList());
        }

    }
}
