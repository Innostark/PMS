using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Web.Models
{
    public class ServiceCompany
    {
        public int ServiceCompanyId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Telephone Number Required")]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Account Number is Required")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string AccountNumber { get; set; }
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Comment { get; set; }

    }
}