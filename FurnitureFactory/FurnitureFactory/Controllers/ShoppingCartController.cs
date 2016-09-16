using FurnitureFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureFactory.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int? id)
        {
            var prod = db.Furniture.Where(i => i.Id == id).SingleOrDefault();


            return View();
        }
    }
}