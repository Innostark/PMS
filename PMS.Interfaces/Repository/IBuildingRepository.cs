using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Models.DomainModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.Repository
{
    public interface IBuildingRepository : IBaseRepository<Building, int>
    {
        BuildingResponse GetAllBuildings();
        Building GetBuildingByName(string name, int id);
        Building FindBuildingById(int buildingId);
    }
}
