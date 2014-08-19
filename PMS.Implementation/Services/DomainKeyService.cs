using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Implementation.Services
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
    }
}
