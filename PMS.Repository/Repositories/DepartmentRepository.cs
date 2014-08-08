using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;
using PMS.Repository.BaseRepository;

namespace PMS.Repository.Repositories
{
    public sealed class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DepartmentRepository(IUnityContainer container)
            : base(container)
        {
        }

        #endregion
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Department> DbSet
        {
            get
            {
                return  db.Departments;
            }
        }

        public IEnumerable<Department> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
