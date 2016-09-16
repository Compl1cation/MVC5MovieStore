using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FurnitureFactory.Models;

namespace FurnitureFactory.Controllers
{
    public class BrowseFurnituresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BrowseFurnitures
        public ActionResult Index()
        {
            var furniture = db.Furniture.ToList();
            return View(furniture);
        }

        // GET: BrowseFurnitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furniture.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

    }
}
