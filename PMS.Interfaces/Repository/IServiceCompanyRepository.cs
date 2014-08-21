using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.Repository
{
    public interface IServiceCompanyRepository : IBaseRepository<ServiceCompany, int>
    {
        ServiceCompany FindServiceCompanyById(int serviceCompanyId);
        ServiceCompanyResponse GetAllServiceCompanies(ServiceCompanySearchRequest serviceCompanySearchRequest);
    }
}
