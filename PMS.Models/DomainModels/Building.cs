using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PMS.Models.DomainModels
{
    /// <summary>
    /// Building
    /// </summary>
    public class Building
    {
        #region Persisted Properties
       
        public int BuildingId { get; set; }
        
        
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
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
        public Guid UserId { get; set; }
        #endregion
        //public virtual IdentityUser User { get; set; }

        #region Reference Properties

        /// <summary>
        /// Apartments in this Building
        /// </summary>
        public virtual ICollection<Apartment> Apartments { get; set; } 

        #endregion
    }
}
