using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using OSS.Interfaces.Repository;
using OSS.Models.DomainModels;
using OSS.Repository.BaseRepository;

namespace OSS.Repository.Repositories
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
