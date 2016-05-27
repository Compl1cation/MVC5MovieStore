using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC5MovieStore.Models
{
    public class Movie
    {
        public int MovieId { get; set; } //PK
        [Display (Name="Director")]
        public virtual int DirectorId { get; set; } //Foreign key
        
        [Display(Name="Year Range")]
        public virtual int YearRangeId { get; set; } //Foreign key

        [RegularExpression(@"[A-Za-z0-9''-'\s\.\,\-\:\']*")]
        [Required(ErrorMessage="Please enter the movie's title.")]
        [StringLength(255, ErrorMessage = "Movie Title cannot be longer than 255 characters.")]
        public virtual string Title { get; set; }

        [Required(ErrorMessage = "Please enter the movie's description.")]
        [RegularExpression(@"[A-Za-z0-9''-'\s\.\,\-\:\']*")]
        [StringLength(2000, ErrorMessage = "Movie description cannot be longer than 1000 characters.")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 200.01, ErrorMessage = "Price must be between 0.01 and 200")]
        public virtual double Price { get; set; }
        
        [Required(ErrorMessage = "Year is required")]
        [Range(typeof(int), "1900", "2100", ErrorMessage = "Year must be a numerical value between 1900 and 2100")]
        public virtual int Year { get; set; }
        
        [Required(ErrorMessage = "Initial Rating is required")]
        [Range(typeof(int), "1", "10", ErrorMessage = "Rating must be between 1 and 10")]
        public virtual int Rating { get; set; }

        public virtual Director Director { get; set; }
        public virtual YearRange YearRange { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}