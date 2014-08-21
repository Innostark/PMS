using System.Collections.Generic;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.IServices
{
    public interface IDomainKeyService
    {
        bool AddDomainKey(DomainKeys domainKey);
        DomainKeyResponse GetAllUsersByUserId(UserSearchRequest userSearchRequest);
        DomainKeys GetDomainKeyByUserId(string userId);
        void UpdateDomainKey(DomainKeys domainKeys);

        /// <summary>
        /// Update Domain Keys - Batch
        /// </summary>
        void UpdateDomainKeys(IEnumerable<DomainKeys> domainKeys);

        /// <summary>
        /// Get Users for Admin
        /// </summary>
        IEnumerable<DomainKeys> GetAllUserForAdmin(string adminId);
    }
}
