using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Interfaces.Repository
{
    public interface IServiceCompanyRepository : IBaseRepository<ServiceCompany, int>
    {
        ServiceCompany FindServiceCompanyById(int serviceCompanyId);
        ServiceCompanyResponse GetAllServiceCompanies(ServiceCompanySearchRequest serviceCompanySearchRequest);
    }
}
