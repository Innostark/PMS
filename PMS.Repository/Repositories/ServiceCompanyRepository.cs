using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.Common;
using PMS.Models.DomainModels;
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
    }
}
