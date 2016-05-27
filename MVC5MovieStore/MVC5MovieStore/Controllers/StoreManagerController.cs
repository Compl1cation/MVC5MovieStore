using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5MovieStore.ViewModels;
using MVC5MovieStore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVC5MovieStore.CustomFilters;

namespace MVC5MovieStore.Controllers
{

    public class StoreManagerController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();

        // GET: /StoreManager/
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        public ActionResult Index()
        {
   
            SortingInfo info = new SortingInfo();
            info.SortField = "Title";
            info.SortDirection = "descending";
            info.PageSize = 20;
            info.PageCount = Convert.ToInt32(Math.Ceiling((double)(db.Movies.Count()/ info.PageSize)));
            info.CurrentPageIndex = 0;

            var movies = db.Movies.Include(m => m.Director).Include(m => m.YearRange).OrderBy(m => m.Title).Take(info.PageSize);

            ViewBag.SortingInfo = info;

            List<Movie> model = movies.ToList();
            return View(movies);
        }

 [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
 [HttpPost]
 public ActionResult Index(SortingInfo info)
  { 
      IQueryable<Movie> query = null;
      switch(info.SortField)
      {
         case "Title":
            query = (info.SortDirection == "ascending" ?
                     db.Movies.OrderBy(c => c.Title) :
                     db.Movies.OrderByDescending(c => c.Title));
            break;
         case "Director":
            query = (info.SortDirection == "ascending" ?
                     db.Movies.OrderBy(c => c.Director.Name) :
                     db.Movies.OrderByDescending(c => c.Director.Name));
            break;
         case "Year":
            query = (info.SortDirection == "ascending" ?
                     db.Movies.OrderBy(c => c.Year) :
                     db.Movies.OrderByDescending(c => c.Year));
            break;
         case "YearRange":
            query = (info.SortDirection == "ascending" ?
                     db.Movies.OrderBy(c => c.YearRange.Range) :
                     db.Movies.OrderByDescending(c => c.YearRange.Range));
            break;
        case "Price":
            query = (info.SortDirection == "ascending" ?
                     db.Movies.OrderBy(c => c.Price) :
                     db.Movies.OrderByDescending(c => c.Price));
            break;
         case "Rating":
            query = (info.SortDirection == "ascending" ?
                     db.Movies.OrderBy(c => c.Rating) :
                     db.Movies.OrderByDescending(c => c.Rating));
            break;
      }
      query = query.Skip(info.CurrentPageIndex * info.PageSize).Take(info.PageSize);
      ViewBag.SortingInfo = info;

      List<Movie> model = query.ToList();
      return View(model);
}
 
        // GET: /StoreManager/Details/id
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]  
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };
        
            /*Eager Load*/
            Movie movie = db.Movies
           .Include(i => i.Director)
           .Include(i => i.Genres)
           .Include(i => i.YearRange)
           .Include(i => i.Files)
           .Where(i => i.MovieId == id)
           .Single();

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: /StoreManager/Create
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        public ActionResult Create()
        {

            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "Name");
            ViewBag.YearRangeId = new SelectList(db.YearRanges, "YearRangeId", "Range");
            return View();
        }

        // POST: /StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,DirectorId,YearRangeId,Title,Price,Year,Rating, Description")] Movie movie, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var poster = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Poster,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        poster.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    movie.Files = new List<File> { poster };
                }
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "Name", movie.DirectorId);
            ViewBag.YearRangeId = new SelectList(db.YearRanges, "YearRangeId", "Range", movie.YearRangeId);
        
        return View(movie);
        }

        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
       Movie movie = db.Movies
           .Include(i => i.Director)
           .Include(i => i.Genres)
           .Include(i => i.YearRange)
           .Include(i => i.Files)
           .Where(i=> i.MovieId == id)
           .Single();

            PopulateAssignGenreData(movie);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "Name", movie.DirectorId);
            ViewBag.YearRangeId = new SelectList(db.YearRanges, "YearRangeId", "Range", movie.YearRangeId);
            return View(movie);
        }

        private void PopulateAssignGenreData(Movie movie)
        {
            var allGenres = db.Genres;
            var movieGenres = new HashSet<int>(movie.Genres.Select(g => g.GenreId));
            var viewModel = new List<AssignGenreData>();
            foreach (var genre in allGenres)
            {
                viewModel.Add(new AssignGenreData
                {
                    GenreId = genre.GenreId,
                    Name = genre.Name,
                    Assigned = movieGenres.Contains(genre.GenreId)
                });
            }
            ViewBag.Genres = viewModel;
        }

        // POST: /StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
[AuthLog(Roles = "ContentAdmin, MasterAdmin")]
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit (int? id, string[] selectedGenres, HttpPostedFileBase upload)
   {
    if (id == null)
    {
         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
var movieToUpdate = db.Movies
.Include(i => i.Director)
.Include(i => i.Genres)
.Include(i => i.YearRange)
.Where(i=> i.MovieId == id)
.Single();

if (TryUpdateModel (movieToUpdate, "",
	new string [] {"DirectorId", "Title","Genre", "Price","Rating","Year","YearRangeId" }))
{
    try
	    {
            if (upload != null && upload.ContentLength > 0)
            {
                if (movieToUpdate.Files.Any(f => f.FileType == FileType.Poster))
                {
                    db.Files.Remove(movieToUpdate.Files.First(f => f.FileType == FileType.Poster));
                }
                var poster = new File
                {
                    FileName = System.IO.Path.GetFileName(upload.FileName),
                    FileType = FileType.Poster,
                    ContentType = upload.ContentType
                };
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    poster.Content = reader.ReadBytes(upload.ContentLength);
                }
                movieToUpdate.Files = new List<File> { poster };
            }

	        UpdateMovieGenres(selectedGenres, movieToUpdate);
	        db.SaveChanges();
	        return RedirectToAction ("Index");
	    }
    catch (DataException /* dex */ )
	{
	//Log the error (uncomment dex variable name and add a line here to write a log.
	ModelState.AddModelError("","Unable to save changes. Try again.");
	    }
	}

	PopulateAssignGenreData(movieToUpdate);
	return View(movieToUpdate);
}

private void UpdateMovieGenres (string[] selectedGenres, Movie movieToUpdate)
{
	if (selectedGenres == null)
	{
	   movieToUpdate.Genres = new List <Genre>();
	   return;
	}
     var selectedGenresHS = new HashSet <string>(selectedGenres);
     var movieGenres = new HashSet <int>
	(movieToUpdate.Genres.Select( c=> c.GenreId));
	foreach (var genre in db.Genres)
	{
	   if (selectedGenresHS.Contains(genre.GenreId.ToString()))
	      {
		if (! movieGenres.Contains(genre.GenreId))
		{
		       movieToUpdate.Genres.Add(genre);
		}
	      }
	else
	{
	     if (movieGenres.Contains(genre.GenreId))
	{
	   movieToUpdate.Genres.Remove(genre);
	}
	}
}
}
        [AuthLog(Roles = "Admin")]
        // GET: /StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
