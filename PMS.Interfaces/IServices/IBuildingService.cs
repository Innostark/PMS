using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.IServices
{
    public interface IBuildingService
    {
        BuildingResponse GetAllBuildings();
        void DeleteBuilding(Building building);
        bool AddBuilding(Building building);
        bool Update(Building building);
        Building FindBuilding(int? buildingId);
        BuildingResponse GetAllBuildings(BuildingSearchRequest buildingSearchRequest);

    }
}
