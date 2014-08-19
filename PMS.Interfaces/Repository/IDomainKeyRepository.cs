using System.Collections.Generic;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.Repository
{
    public interface IDomainKeyRepository : IBaseRepository<DomainKeys, int>
    {
        DomainKeyResponse GetAllUsersByUserId(UserSearchRequest userSearchRequest);
        DomainKeys GetDomainKeyByUserId(string userId);
    }
}
