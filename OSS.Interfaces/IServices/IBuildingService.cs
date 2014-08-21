using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Interfaces.IServices
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
