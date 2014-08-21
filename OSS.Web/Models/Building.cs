using System;
using System.ComponentModel.DataAnnotations;

namespace OSS.Web.Models
{
    public class Building
    {
        public int BuildingId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }
        [Required(ErrorMessage="Telephone Number Required")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Built Date is Required")]
        public String BuiltDate { get; set; }
        [Required(ErrorMessage = "No of Floors is required")]
        public int NoOfFloors { get; set; }
        [Required(ErrorMessage = "No of Elevators is required")]
        public int? NoOfElevators { get; set; }
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}