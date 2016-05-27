using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC5MovieStore.Models
{
    public class Director
    {
        public int DirectorId { get; set; }
        [Required(ErrorMessage="Please enter the director's name.")]
        [RegularExpression(@"^[A-Za-zA-Z''-'\s]*")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Director name must be between 3 and 255 characters")]
        public virtual string Name { get; set; }
        public virtual ICollection<File> Files {get; set;}
        public virtual ICollection<Movie> Movies { get; set; }
    }
}