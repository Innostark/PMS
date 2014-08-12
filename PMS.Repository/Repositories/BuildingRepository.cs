using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;
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
        public Building GetBuildingByName(string name, int id)
        {
            return DbSet.FirstOrDefault(building => building.Name == name && building.BuildingId == id);
        }

        public Building FindBuildingById(int buildingId)
        {
            return DbSet.FirstOrDefault(building => building.BuildingId == buildingId);
        }
    }
}