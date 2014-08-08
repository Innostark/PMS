using System.Collections.Generic;
using PMS.Models.DomainModels;

namespace PMS.Interfaces.Repository
{
    public interface IDepartmentRepository : IBaseRepository<Department, int>
    {
        IEnumerable<Department> GetAll();
    }
}
