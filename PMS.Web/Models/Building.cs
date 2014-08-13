using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Web.Models
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [DisplayFormat( DataFormatString = "{0:MMM-dd-yyyy}")]
        public DateTime? BuiltDate { get; set; }
        public int NoOfFloors { get; set; }
        public int? NoOfElevators { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}