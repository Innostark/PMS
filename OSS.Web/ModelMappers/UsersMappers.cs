using OSS.Models.DomainModels;
using OSS.Models.IdentityModels;
using OSS.Models.IdentityModels.ViewModels;

namespace OSS.Web.ModelMappers
{
    public static class UsersMappers
    {
        public static Models.Users CreateFrom(this DomainKeys domainKeys, string roleName, string loggedInUserCompanyName)
        {
            return new Models.Users
                   {
                       Name = domainKeys.User.FirstName + " "+ domainKeys.User.LastName,
                       Email = domainKeys.User.Email,
                       KeyId = domainKeys.KeyId,
                       CreatedBy = domainKeys.CreatedBy,
                       CreatedDate = domainKeys.CreatedDate.ToString("MMMM dd yyyy"),
                       DomainKey = domainKeys.DomainKey,
                       ExpiryDate = domainKeys.ExpiryDate.ToString("MMMM dd yyyy"),
                       UpdatedBy = domainKeys.UpdatedBy,
                       UpdatedDate = domainKeys.UpdatedDate != null ? domainKeys.UpdatedDate.Value.ToString("MMMM dd yyyy") : string.Empty,
                       UserId = domainKeys.UserId,
                       RoleName = roleName == "SuperAdmin"? "Admin": "User",
                       CompanyName = roleName.ToLower() == "admin"?loggedInUserCompanyName: domainKeys.User.CompanyName,
                       IsPrimary = domainKeys.User.IsPrimary
                   };
        }

        public static RegisterViewModel CreateFrom(this ApplicationUser user, DomainKeys domainKeys)
        {
            return new RegisterViewModel
                   {
                       UserId = user.Id,
                       DomainKey = domainKeys.DomainKey,
                       Email = user.Email,
                       ExpiryDate = domainKeys.ExpiryDate.ToString("d"),
                       FirstName = user.FirstName,
                       LastName = user.LastName,
                       CompanyName = user.CompanyName,
                       IsPrimary = user.IsPrimary
                   };
        }

    }
}