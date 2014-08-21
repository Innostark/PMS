using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Interfaces.Repository
{
    public interface IBuildingRepository : IBaseRepository<Building, int>
    {
        BuildingResponse GetAllBuildings();
        Building GetBuildingByName(int id);
        Building FindBuildingById(int buildingId);
        BuildingResponse GetAllBuildings(BuildingSearchRequest buildingSearchRequest);
    }
}
