using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVC5MovieStore.Models;
using MVC5MovieStore.ViewModels;

namespace MVC5MovieStore.Controllers
{
    public class BrowseMoviesController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();


        // GET: /Default1/
    public ActionResult Index()
     {   
       var genres = new SelectList(db.Genres.Select(g => g.Name).Distinct().ToList());
       ViewBag.Genre = genres;

       var years = new SelectList(db.Movies.Select(m => m.Year).Distinct().ToList());
       ViewBag.Year = years;

       var ratings = new SelectList(db.Movies.Select(m => m.Rating).Distinct().ToList());
       ViewBag.Rating = ratings;

       FiltInfo filt = new FiltInfo();

       filt.SortField = "Title";
       filt.SortDirection = "descending";
       filt.PageSize = 5;
       var movCnt = db.Movies.Count();
       filt.PageCount = (int)Math.Ceiling((movCnt / (double)filt.PageSize));
       filt.CurrentPageIndex = 0;

       var movies = db.Movies
       .Include(m => m.Director)
       .Include(m => m.YearRange)
       .Include(m => m.Genres)
       .Include(m => m.Files).OrderBy(m => m.Title).Take(filt.PageSize);
           
       ViewBag.SortingInfo = filt;

            return View(movies.ToList());
     }

  [HttpPost]
  public ActionResult Index([Bind(Include ="Year, Rating, Genre")]FiltInfo filt)
      {
        var genremovie = new GenreMovieViewModel();
        genremovie.Movies = null;
        
        if (filt.Year == 0 && filt.Rating == 0 && filt.Genre != null)
         {
           genremovie.Genres = db.Genres.Include(g => g.Movies).Where(g => g.Name == filt.Genre).OrderBy(g => g.Name);
           genremovie.Movies = genremovie.Genres.Where(g => g.Name == filt.Genre).Single().Movies;
         }
        else if (filt.Genre == null && (filt.Rating !=0 || filt.Year !=0))
          {
          genremovie.Movies = db.Movies.Include(m => m.Genres.Select(g => g.Movies)).Where(m => m.Year == filt.Year || m.Rating == filt.Rating).ToList();
          }
        else
           {
            genremovie.Movies = db.Movies
           .Include(i => i.Director)
           .Include(i => i.Genres)
           .Include(i => i.YearRange)
           .Include(i => i.Files)
           .OrderBy(i => i.Title).ToList();
           }
       //repopulate ViewBag
        var genres = new SelectList(db.Genres.Select(g => g.Name).Distinct().ToList());
        ViewBag.Genre = genres;
        var years = new SelectList(db.Movies.Select(m => m.Year).Distinct().ToList());
        ViewBag.Year = years;
        var ratings = new SelectList(db.Movies.Select(m => m.Rating).Distinct().ToList());
        ViewBag.Rating = ratings;



        ViewBag.SortingInfo = filt;
        IEnumerable<Movie> model = genremovie.Movies;
            model = model.Skip(filt.CurrentPageIndex * filt.PageSize).Take(filt.PageSize).ToList();
            ViewBag.SortingInfo = filt;

            return View(model);
    }
        [Route("BrowseMovies/Details/{id}")]

        public ActionResult Details(int? id)
     {
      if (id == null)
       {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
            /*Eager Load*/
       Movie movie = db.Movies
       .Include(i => i.Director)
       .Include(i => i.Genres)
       .Include(i => i.YearRange)
       .Include(i => i.Files)
       .Where(i => i.MovieId == id)
       .SingleOrDefault();


            if (movie == null)
            {
                return HttpNotFound();
            }
           return View(movie);
        }
 
 public ActionResult About()
 {
     ViewBag.Message = "Hello from about";
     return View();
 }

        public ActionResult MovieSearch(string q)
        {
            var movies = GetMovies(q);
            return PartialView("_MovieSearch", movies);
        }

        private IEnumerable<Movie> GetMovies(string searchString)
        {
            IEnumerable<Movie> movs = db.Movies
                .Include(m => m.Director)
                .Include(m => m.Genres)
            .Where(a => a.Title.Contains(searchString) ||
            a.Director.Name.Contains(searchString) ||
            a.Year.ToString().Contains(searchString)
            ).Take(5).ToList();
            return (movs);
        }

    }
}
