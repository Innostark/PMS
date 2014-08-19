using System;

namespace PMS.Web.Models
{
    public class Users
    {
        public int KeyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DomainKey { get; set; }
        public String ExpiryDate { get; set; }
        //User Being Created
        public string UserId { get; set; }
        //User Creation Date
        public String CreatedDate { get; set; }
        //record Created By
        public string CreatedBy { get; set; }
        //Record Updated Date
        public String UpdatedDate { get; set; }
        //Record Updated by
        public string UpdatedBy { get; set; }
        //Role Name
        public string RoleName { get; set; }
    }
}