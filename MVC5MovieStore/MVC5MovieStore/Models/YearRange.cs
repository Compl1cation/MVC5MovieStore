using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC5MovieStore.Models
{
    public class YearRange
    {
        public int YearRangeId { get; set; }
        [RegularExpression(@"[0-9''-'\s\-]*", ErrorMessage="Please use only numbers and the - sign in the suggested format")]
        [Required(ErrorMessage="Year range is required.")]
        [StringLength(20, ErrorMessage = "Enter Range under 20 characters long")]
        public virtual string Range { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}