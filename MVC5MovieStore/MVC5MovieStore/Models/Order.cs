using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC5MovieStore.ViewModels;
using MVC5MovieStore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;

namespace MVC5MovieStore.Models
{
        public partial class Order
        {
            [ScaffoldColumn(false)]
            public int OrderId { get; set; }
            [ScaffoldColumn(false)]
            public System.DateTime OrderDate { get; set; }
            [ScaffoldColumn(false)]
            public string Username { get; set; }
            [Required(ErrorMessage = "First Name is required")]
            [Display(Name = "First Name")]
            [StringLength(160)]
            [RegularExpression(@"[A-Z][a-zA-Z\-\s]*", ErrorMessage = "Not a valid First Name, please try again.")]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "Last Name is required")]
            [Display(Name = "Last Name")]
            [StringLength(160)]
            [RegularExpression(@"[A-Z][a-zA-Z\-\s]*", ErrorMessage = "Not a valid Last Name, please try again.")]
            public string LastName { get; set; }
            [Required(ErrorMessage = "Address is required")]
            [StringLength(70)]
            [RegularExpression(@"[0-9a-zA-Z\-\'\s]*", ErrorMessage = "Not a valid Adress, please try again.")]
            public string Address { get; set; }
            [Required(ErrorMessage = "City is required")]
            [StringLength(40)]
            [RegularExpression(@"[A-Z][a-zA-Z\-\s]*", ErrorMessage = "Not a valid City, please try again.")]
            public string City { get; set; }
            [Required(ErrorMessage = "State is required")]
            [StringLength(40)]
            [RegularExpression(@"[A-Z][a-zA-Z\-\s]*", ErrorMessage = "Not a valid Phone state, please try again.")]
            public string State { get; set; }
            [Required(ErrorMessage = "Postal Code is required")]
            [StringLength(10)]
            [RegularExpression(@"[A-Za-z0-9\s]*", ErrorMessage="Not a valid postal Code, please try again.")]
            public string PostalCode { get; set; }
            [Required(ErrorMessage = "Country is required")]
            [StringLength(40)]
            [RegularExpression(@"[A-Z][a-zA-Z\-\s]*")]
            public string Country { get; set; }
            [Required(ErrorMessage = "Phone is required")]
            [StringLength(24)]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"[0-9\s\+]*", ErrorMessage = "Not a valid Phone Number, please try again.")]
            public string Phone { get; set; }
            [Required(ErrorMessage = "Email Address is required")]
            [Display(Name = "Email Address")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage = "Email is is not valid.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [ScaffoldColumn(false)]
            public double Total { get; set; }
            public List<OrderDetail> OrderDetails { get; set; }
        }
    }
