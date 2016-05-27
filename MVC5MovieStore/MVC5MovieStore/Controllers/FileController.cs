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


namespace MVC5MovieStore.Controllers
{
    public class FileController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
	}
}