using System.Collections.Generic;
using OSS.Models.DomainModels;

namespace OSS.Interfaces.IServices
{
    public interface IDepartmentService
    {
        IEnumerable<Department> LoadAll();
    }
}
