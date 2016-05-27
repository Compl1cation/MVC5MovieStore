using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC5MovieStore.Models
{
    public class Genre
    {
        public virtual int GenreId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Genre Name must be between 3 - 20 characters in length")]
        public virtual string Name { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9A-Z''-'\s\.\,\-\:\']*")]
        [StringLength(1500, ErrorMessage = "Description must be under 1500 characters in length")]
        public virtual string Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}