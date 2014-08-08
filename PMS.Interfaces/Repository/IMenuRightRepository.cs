using System.Linq;
using PMS.Models.MenuModels;

namespace PMS.Interfaces.Repository
{
    public interface IMenuRightRepository
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
