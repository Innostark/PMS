using OSS.Interfaces.IServices;
using OSS.Interfaces.Repository;
using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Implementation.Services
{
    public sealed class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository buildingRepository;
        private bool ValidateBuilding(Building building)
        {
            Building buildingDbVersion = buildingRepository.GetBuildingByName( building.BuildingId);
            return buildingDbVersion != null;
        }
        public BuildingService(IBuildingRepository buildingRepository)
        {
            this.buildingRepository = buildingRepository;
        }
        public BuildingResponse GetAllBuildings()
        {
            return buildingRepository.GetAllBuildings();
        }
        public bool AddBuilding(Building building)
        {
            //if (ValidateBuilding(building))
            //{
                buildingRepository.Add(building);
                buildingRepository.SaveChanges();
                return true;
            //}
        }
        public bool Update(Building product)
        {
            if (ValidateBuilding(product))
            {
                buildingRepository.Update(product);
                buildingRepository.SaveChanges();
                return true;
            }

            return false;
        }
        public void DeleteBuilding(Building building)
        {
            buildingRepository.Delete(building);
            buildingRepository.SaveChanges();
        }

        public Building FindBuilding(int? buildingId)
        {
            if (buildingId != null) return buildingRepository.FindBuildingById((int) buildingId);
            return null;
        }

        public BuildingResponse GetAllBuildings(BuildingSearchRequest buildingSearchRequest)
        {
            return buildingRepository.GetAllBuildings(buildingSearchRequest);
        }
    }
}
