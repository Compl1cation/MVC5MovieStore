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
    public class GenreManagerController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /GenreManager/
        public ActionResult Index()
        {
            SortingInfo info = new SortingInfo();
            info.SortField = "Title";
            info.SortDirection = "descending";
            info.PageSize = 5;
            info.PageCount = Convert.ToInt32(Math.Ceiling((double)(db.Movies.Count() / info.PageSize)));
            info.CurrentPageIndex = 0;

            var genres = db.Genres.OrderBy(g => g.Name).Take(info.PageSize);
            
            ViewBag.SortingInfo = info;

            List<Genre> model = genres.ToList();
 
            return View(genres);

        }

        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [HttpPost]
        public ActionResult Index(SortingInfo info)
        {
            IQueryable<Genre> query = null;
            switch (info.SortField)
            {
                case "Name":
                    query = (info.SortDirection == "ascending" ?
                             db.Genres.OrderBy(c => c.Name) :
                             db.Genres.OrderByDescending(c => c.Name));
                    break;
            }
            query = query.Skip(info.CurrentPageIndex * info.PageSize).Take(info.PageSize);
            ViewBag.SortingInfo = info;
            List<Genre> model = query.ToList();
            return View(model);
        }


        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /GenreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /GenreManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GenreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GenreId,Name,Description")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }
    [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /GenreManager/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: /GenreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GenreId,Name,Description")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }
    [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /GenreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: /GenreManager/Delete/5
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
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
