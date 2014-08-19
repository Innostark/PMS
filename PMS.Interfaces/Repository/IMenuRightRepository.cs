using System.Linq;
using PMS.Models.MenuModels;

namespace PMS.Interfaces.Repository
{
    public interface IMenuRightRepository : IBaseRepository<MenuRight, int>
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
