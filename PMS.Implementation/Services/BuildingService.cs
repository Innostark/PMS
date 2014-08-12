using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.ResponseModels;

namespace PMS.Implementation.Services
{
    public sealed class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository buildingRepository;
        public BuildingService(IBuildingRepository buildingRepository)
        {
            this.buildingRepository = buildingRepository;

        }
        public BuildingResponse GetAllBuildings()
        {
            return buildingRepository.GetAllBuildings();
        }
    }
}
