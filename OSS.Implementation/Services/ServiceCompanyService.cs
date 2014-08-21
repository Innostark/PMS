using OSS.Interfaces.IServices;
using OSS.Interfaces.Repository;
using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Implementation.Services
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
