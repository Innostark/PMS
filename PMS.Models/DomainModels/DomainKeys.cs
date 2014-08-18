using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Models.DomainModels
{
    public class DomainKeys
    {
        [Key]
        public int KeyId { get; set; }
        public string DomainKey { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid UserId { get; set; }
    }
}
