using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MVC5MovieStore.Models;
using MVC5MovieStore.CustomFilters;

namespace MVC5MovieStore.Controllers
{
    public class RoleManagerController : Controller
    {

        private  MovieStoreDB db = new MovieStoreDB();
        
        
        /// Get All Roles
        [AuthLog(Roles = "MasterAdmin")]
        public ActionResult Index()
        {
          var roles = db.Roles.OrderBy(r => r.Name).ToList();
          return View(roles);
        }

        [AuthLog(Roles = "MasterAdmin")]
        public ActionResult Edit(string id)
        {
           if (id == null)
           {
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
            IdentityRole role = db.Roles.Find(id);
            if (role==null)
            {
             return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
            return View(role);
        }
        
        [AuthLog(Roles = "MasterAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
        [AuthLog(Roles = "MasterAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: /BrowseDirectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IdentityRole role = db.Roles.Find(id);
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult RoleAddToUser(string UserName, string RoleName)
               {
                   ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                   var account = new AccountController();
                   account.UserManager.AddToRole(user.Id, RoleName);

                   ViewBag.ResultMessage = "Role created successfully !";

                   // prepopulat roles for the view dropdown
                   var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                   ViewBag.Roles = list;

                   return View("RoleManager");
               }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {            
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var account = new AccountController();

                ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);

                // prepopulat roles for the view dropdown
                var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;            
            }

            return View("RoleManager");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var account = new AccountController();
            ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (account.UserManager.IsInRole(user.Id, RoleName))
            {
                account.UserManager.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            // prepopulat roles for the view dropdown
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("RoleManager");
        }
         [AuthLog(Roles = "MasterAdmin")]
        /// Create  a New role
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        [AuthLog(Roles = "MasterAdmin")] 
        /// Create a New Role
        [HttpPost]

        public ActionResult Create(IdentityRole Role)
        {
            db.Roles.Add(Role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}