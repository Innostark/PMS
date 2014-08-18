using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using PMS.Models.IdentityModels;

namespace PMS.Models.DomainModels
{
    public class DomainKeys
    {
        [Key]
        public int KeyId { get; set; }
        public string DomainKey { get; set; }
        public DateTime ExpiryDate { get; set; }
        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
