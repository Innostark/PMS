using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using OSS.Models.IdentityModels;

namespace OSS.Models.DomainModels
{
    public class DomainKeys
    {
        [Key]
        public int KeyId { get; set; }
        public string DomainKey { get; set; }
        public DateTime ExpiryDate { get; set; }
        //User Being Created
        public string UserId { get; set; }
        //User Creation Date
        public DateTime CreatedDate { get; set; }
        //record Created By
        public string CreatedBy { get; set; }
        //Record Updated Date
        public DateTime? UpdatedDate { get; set; }
        //Record Updated by
        public string UpdatedBy { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
