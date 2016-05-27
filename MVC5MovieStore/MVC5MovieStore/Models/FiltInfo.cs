using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5MovieStore.Models
{
    public class FiltInfo : SortingInfo
    {
        public string Genre { get; set; }
        public int Rating { get; set; }
        public int Year { get; set; }
    }
}