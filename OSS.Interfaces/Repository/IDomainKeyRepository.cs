using System.Collections.Generic;
using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Interfaces.Repository
{
    public interface IDomainKeyRepository : IBaseRepository<DomainKeys, int>
    {
        DomainKeyResponse GetAllUsersByUserId(UserSearchRequest userSearchRequest);
        DomainKeys GetDomainKeyByUserId(string userId);

        /// <summary>
        /// Get Users for Admin
        /// </summary>
        IEnumerable<DomainKeys> GetAllUserForAdmin(string adminId);
    }
}
