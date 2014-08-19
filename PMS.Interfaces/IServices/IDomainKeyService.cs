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
    }
}
