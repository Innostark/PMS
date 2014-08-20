using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;

namespace PMS.Implementation.Services
{
    public class ServiceCompanyService : IServiceCompanyService
    {
        private readonly IServiceCompanyRepository serviceCompanyRepository;

        public ServiceCompanyService(IServiceCompanyRepository serviceCompanyRepository)
        {
            this.serviceCompanyRepository = serviceCompanyRepository;
        }

        public void AddServiceCompany(ServiceCompany serviceCompany)
        {
            serviceCompanyRepository.Add(serviceCompany);
            serviceCompanyRepository.SaveChanges();
        }
    }
}
