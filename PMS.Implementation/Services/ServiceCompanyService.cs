using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

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
        private bool ValidateServiceCompany(ServiceCompany serviceCompany)
        {
            ServiceCompany serviceCompanyDbVersion = serviceCompanyRepository.FindServiceCompanyById(serviceCompany.ServiceCompanyId);
            return serviceCompanyDbVersion != null;
        }
        public bool Update(ServiceCompany serviceCompany)
        {
            if (ValidateServiceCompany(serviceCompany))
            {
                serviceCompanyRepository.Update(serviceCompany);
                serviceCompanyRepository.SaveChanges();
                return true;
            }

            return false;
        }
        public void DeleteServiceCompany(ServiceCompany serviceCompany)
        {
            serviceCompanyRepository.Delete(serviceCompany);
            serviceCompanyRepository.SaveChanges();
        }
        public ServiceCompany FindServiceCompany(int? serviceCompanyId)
        {
            if (serviceCompanyId != null) return serviceCompanyRepository.FindServiceCompanyById((int)serviceCompanyId);
            return null;
        }
        public ServiceCompanyResponse GetAllserviceCompanies(ServiceCompanySearchRequest serviceCompanySearchRequest)
        {
            return serviceCompanyRepository.GetAllServiceCompanies(serviceCompanySearchRequest);
        }
    }
}
