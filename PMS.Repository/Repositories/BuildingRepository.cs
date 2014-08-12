using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.Common;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;
using PMS.Repository.BaseRepository;


namespace PMS.Repository.Repositories
{
    public sealed class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BuildingRepository(IUnityContainer container)
            : base(container)
        {

        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Building> DbSet
        {
            get { return db.Buildings; }
        }

        #endregion

        public BuildingResponse GetAllBuildings()
        {
            return new BuildingResponse
                   {
                       Buildings = DbSet.ToList(),
                       TotalCount = DbSet.ToList().Count
                   };
        }
    }
}