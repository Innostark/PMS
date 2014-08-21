using System.Collections.Generic;
using OSS.Models.DomainModels;

namespace OSS.Interfaces.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
        IEnumerable<Category> GetAllCategories();
    }
}
