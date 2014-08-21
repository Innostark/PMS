using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.IServices
{
    public interface IServiceCompanyService
    {
        void AddServiceCompany(ServiceCompany serviceCompany);
        bool Update(ServiceCompany serviceCompany);
        void DeleteServiceCompany(ServiceCompany serviceCompany);
        ServiceCompany FindServiceCompany(int? serviceCompanyId);
        ServiceCompanyResponse GetAllserviceCompanies(ServiceCompanySearchRequest serviceCompanySearchRequest);
    }
}
