using System.Collections.Generic;
using FaceSharp.Api.Extensions;
using OSS.Interfaces.IServices;
using OSS.Interfaces.Repository;
using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Implementation.Services
{
    public sealed class DomainKeyService: IDomainKeyService
    {
        private readonly IDomainKeyRepository domainKeyRepository;

        public DomainKeyService(IDomainKeyRepository domainKeyRepository)
        {
            this.domainKeyRepository = domainKeyRepository;
        }

        public bool AddDomainKey(DomainKeys domainKey )
        {
            domainKeyRepository.Add(domainKey);
            domainKeyRepository.SaveChanges();
            return true;
        }

        public DomainKeyResponse GetAllUsersByUserId(UserSearchRequest userSearchRequest)
        {
            var users = domainKeyRepository.GetAllUsersByUserId(userSearchRequest);
            return users;
        }


        public DomainKeys GetDomainKeyByUserId(string userId)
        {
            return domainKeyRepository.GetDomainKeyByUserId(userId);
        }

        public void UpdateDomainKey(DomainKeys domainKeys)
        {
            domainKeyRepository.Update(domainKeys);
            domainKeyRepository.SaveChanges();
        }

        /// <summary>
        /// Update Domain Keys
        /// </summary>
        public void UpdateDomainKeys(IEnumerable<DomainKeys> domainKeys)
        {
            domainKeys.ForEach(d => domainKeyRepository.Update(d));
            domainKeyRepository.SaveChanges();
        }

        /// <summary>
        /// Get Users for Admin
        /// </summary>
        public IEnumerable<DomainKeys> GetAllUserForAdmin(string adminId)
        {
            return domainKeyRepository.GetAllUserForAdmin(adminId);
        }
    }
}
