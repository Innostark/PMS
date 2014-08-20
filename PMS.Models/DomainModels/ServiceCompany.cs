using System.ComponentModel.DataAnnotations;

namespace PMS.Models.DomainModels
{
    public class ServiceCompany
    {
        [Key]
        public int ServiceCompanyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public string Comment { get; set; }
    }
}
