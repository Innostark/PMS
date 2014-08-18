using System;
using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;

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
    }
}
