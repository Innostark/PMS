using System.Linq;
using OSS.Models.MenuModels;

namespace OSS.Interfaces.Repository
{
    public interface IMenuRightRepository : IBaseRepository<MenuRight, int>
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
