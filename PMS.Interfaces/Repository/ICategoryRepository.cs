using System.Collections.Generic;
using PMS.Models.DomainModels;

namespace PMS.Interfaces.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
        IEnumerable<Category> GetAllCategories();
    }
}
