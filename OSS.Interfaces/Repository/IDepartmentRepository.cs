using System.Collections.Generic;
using OSS.Models.DomainModels;

namespace OSS.Interfaces.Repository
{
    public interface IDepartmentRepository : IBaseRepository<Department, int>
    {
        IEnumerable<Department> GetAll();
    }
}
