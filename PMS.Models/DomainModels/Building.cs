using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PMS.Models.DomainModels
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? BuiltDate { get; set; }
        public int NoOfFloors { get; set; }
        public int? NoOfElevators { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        //public virtual IdentityUser User { get; set; }
    }
}
