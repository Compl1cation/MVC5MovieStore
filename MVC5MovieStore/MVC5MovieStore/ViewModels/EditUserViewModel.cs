using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;


namespace MVC5MovieStore.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}