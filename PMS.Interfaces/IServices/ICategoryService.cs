using System.Collections.Generic;
using PMS.Models.DomainModels;

namespace PMS.Interfaces.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> LoadAllCategories();
    }
}
