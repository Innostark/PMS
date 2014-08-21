using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.Common;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;
using PMS.Repository.BaseRepository;

namespace PMS.Repository.Repositories
{
    public sealed class ServiceCompanyRepository : BaseRepository<ServiceCompany>, IServiceCompanyRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceCompanyRepository(IUnityContainer container)
            : base(container)
        {

        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ServiceCompany> DbSet
        {
            get { return db.ServiceCompanies; }
        }

        #endregion
        #region Private
        private readonly Dictionary<ServiceCompanyByColumn, Func<ServiceCompany, object>> buildingClause =
             new Dictionary<ServiceCompanyByColumn, Func<ServiceCompany, object>>
                    {
                        { ServiceCompanyByColumn.Name, c => c.Name },
                        { ServiceCompanyByColumn.PhoneNumber, c => c.PhoneNumber},
                        { ServiceCompanyByColumn.Email, c => c.Email },
                        { ServiceCompanyByColumn.Address, c => c.Address},
                        { ServiceCompanyByColumn.AccountNumber, c => c.AccountNumber},
                        { ServiceCompanyByColumn.Comment, c => c.Comment}
                    };
        #endregion

        #region public
        public ServiceCompany FindServiceCompanyById(int serviceCompanyId)
        {
            return DbSet.FirstOrDefault(serviceCompany => serviceCompany.ServiceCompanyId== serviceCompanyId);
        }
        public ServiceCompanyResponse GetAllServiceCompanies(ServiceCompanySearchRequest serviceCompanySearchRequest)
        {
            int fromRow = (serviceCompanySearchRequest.PageNo - 1) * serviceCompanySearchRequest.PageSize;
            int toRow = serviceCompanySearchRequest.PageSize;
            Expression<Func<ServiceCompany, bool>> query =
                s => (s.UserId.Equals(serviceCompanySearchRequest.UserId)) &&
                    (string.IsNullOrEmpty(serviceCompanySearchRequest.PhoneNumber) || s.PhoneNumber.Contains(serviceCompanySearchRequest.PhoneNumber)) &&
                    (string.IsNullOrEmpty(serviceCompanySearchRequest.SearchString) || s.Name.Contains(serviceCompanySearchRequest.SearchString));
            IEnumerable<ServiceCompany> serviceCompanies = serviceCompanySearchRequest.IsAsc ? DbSet.Where(query).OrderBy(buildingClause[serviceCompanySearchRequest.ServiceCompanyOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                           : DbSet.Where(query).OrderByDescending(buildingClause[serviceCompanySearchRequest.ServiceCompanyOrderBy]).Skip(fromRow).Take(toRow).ToList();
            return new ServiceCompanyResponse { ServiceCompanies = serviceCompanies, TotalCount = DbSet.Count(query) };
        }
        #endregion
    }
}
