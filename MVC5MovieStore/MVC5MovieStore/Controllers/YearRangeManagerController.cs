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
    public class YearRangeManagerController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /BrowseYearRanges/
        public ActionResult Index()
        {
            SortingInfo info = new SortingInfo();
            info.SortField = "Range";
            info.SortDirection = "descending";


            ViewBag.SortingInfo = info;

            return View(db.YearRanges.OrderBy(y=> y.Range).ToList());
 }

        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [HttpPost]
        public ActionResult Index(SortingInfo info)
        {
            IQueryable<YearRange> query = null;
            switch (info.SortField)
            {
                case "Range":
                    query = (info.SortDirection == "ascending" ?
                             db.YearRanges.OrderBy(c => c.Range) :
                             db.YearRanges.OrderByDescending(c => c.Range));
                    break;
            }

            ViewBag.SortingInfo = info;

            List<YearRange> model = query.ToList();
            return View(model);
        }


        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /BrowseYearRanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearRange yearrange = db.YearRanges.Find(id);
            if (yearrange == null)
            {
                return HttpNotFound();
            }
            return View(yearrange);
        }
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /BrowseYearRanges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BrowseYearRanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearRangeId,Range")] YearRange yearrange)
        {
            if (ModelState.IsValid)
            {
                db.YearRanges.Add(yearrange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yearrange);
        }
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        // GET: /BrowseYearRanges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearRange yearrange = db.YearRanges.Find(id);
            if (yearrange == null)
            {
                return HttpNotFound();
            }
            return View(yearrange);
        }

        // POST: /BrowseYearRanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearRangeId,Range")] YearRange yearrange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearrange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearrange);
        }

        // GET: /BrowseYearRanges/Delete/5
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearRange yearrange = db.YearRanges.Find(id);
            if (yearrange == null)
            {
                return HttpNotFound();
            }
            return View(yearrange);
        }

        // POST: /BrowseYearRanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [AuthLog(Roles = "ContentAdmin, MasterAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearRange yearrange = db.YearRanges.Find(id);
            db.YearRanges.Remove(yearrange);
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
