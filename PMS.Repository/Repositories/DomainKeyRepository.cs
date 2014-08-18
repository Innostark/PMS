using System.Data.Entity;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;
using PMS.Repository.BaseRepository;

namespace PMS.Repository.Repositories
{
    public sealed class DomainKeyRepository : BaseRepository<DomainKeys>, IDomainKeyRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public DomainKeyRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DomainKeys> DbSet
        {
            get { return db.DomainKeys; }
        }
        #endregion
    }
}
