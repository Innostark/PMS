using System.Collections.Generic;
using OSS.Interfaces.IServices;
using OSS.Interfaces.Repository;
using OSS.Models.DomainModels;

namespace OSS.Implementation.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository iRepository;

          public DepartmentService(IDepartmentRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<Department> LoadAll()
        {
            return iRepository.GetAll();
        }
    }
}
