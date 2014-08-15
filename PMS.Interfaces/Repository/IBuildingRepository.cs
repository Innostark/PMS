using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.Repository
{
    public interface IBuildingRepository : IBaseRepository<Building, int>
    {
        BuildingResponse GetAllBuildings();
        Building GetBuildingByName(int id);
        Building FindBuildingById(int buildingId);
        BuildingResponse GetAllBuildings(BuildingSearchRequest buildingSearchRequest);
    }
}
