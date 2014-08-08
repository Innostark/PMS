using System.Collections.Generic;
using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;

namespace PMS.Implementation.Services
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
