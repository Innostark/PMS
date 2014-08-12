using PMS.Models.ResponseModels;

namespace PMS.Interfaces.IServices
{
    public interface IBuildingService
    {
        BuildingResponse GetAllBuildings();
    }
}
