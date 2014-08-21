using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Interfaces.IServices
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
