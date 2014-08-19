using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.IServices
{
    public interface IDomainKeyService
    {
        bool AddDomainKey(DomainKeys domainKey);
        DomainKeyResponse GetAllUsersByUserId(UserSearchRequest userSearchRequest);
    }
}
