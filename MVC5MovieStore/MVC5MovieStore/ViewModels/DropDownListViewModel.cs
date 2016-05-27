using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5MovieStore.ViewModels
{
    public class DropDownListViewModel
    {
        public virtual List<string> Genres { get; set; }
        public virtual List<int> Years {get; set;}
        public virtual List<int> Ratings {get; set;}
    }
}