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
    public class DirectorSearchController : Controller
    {

        private MovieStoreDB db = new MovieStoreDB();
        //
        // GET: /DirectorSearch/
        public ActionResult Search(string d)
        {
            var directors = GetDirectors(d);
            return PartialView(directors);

        }

        private List<Director> GetDirectors(string searchString)
        {
        return  db.Directors
        .Where( a=> a.Name.Contains(searchString)).ToList();
        }
	}
}