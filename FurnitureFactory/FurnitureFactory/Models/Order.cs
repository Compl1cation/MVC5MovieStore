using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FurnitureFactory.Models
{
    public class Order
    {   [Key]
        public virtual int Id { get; set; }
        public DateTime Date { get; set; }

        [RegularExpression(@"\d *[.] ?\d +")]
        [Min(0.00)]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Please add the product's BarDocde")]
        [RegularExpression(@"[0-9A-Za-z]{1,50}")]
        public string RecieptNumber { get; set; }
        public virtual int ClientId { get; set; }
        public virtual ApplicationUser Client { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}