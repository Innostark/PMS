using System.Linq;
using System.Web;
using PMS.Implementation.Identity;
using PMS.Models.DomainModels;

namespace PMS.Web.ModelMappers
{
    public static class UsersMappers
    {
        public static Models.Users CreateFrom(this DomainKeys domainKeys, string roleName)
        {
            return new Models.Users
                   {
                       Name = domainKeys.User.FirstName + " "+ domainKeys.User.LastName,
                       Email = domainKeys.User.Email,
                       KeyId = domainKeys.KeyId,
                       CreatedBy = domainKeys.CreatedBy,
                       CreatedDate =  domainKeys.CreatedDate.ToString("d") ,
                       DomainKey = domainKeys.DomainKey,
                       ExpiryDate = domainKeys.ExpiryDate.ToString("d"),
                       UpdatedBy = domainKeys.UpdatedBy,
                       UpdatedDate = domainKeys.UpdatedDate!= null ? domainKeys.UpdatedDate.Value.ToString("d") : string.Empty,
                       UserId = domainKeys.UserId,
                       //RoleName = (domainKeys.User.Roles.ToList().FirstOrDefault(x => x.UserId == domainKeys.UserId).).Name
                       RoleName = roleName == "SuperAdmin"? "Admin": "LandLord"
                   };
        }

    }
}