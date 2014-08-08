using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;
using PMS.Repository.BaseRepository;

namespace PMS.Repository.Repositories
{
    /// <summary>
    /// Category Repository
    /// </summary>
    public sealed class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CategoryRepository(IUnityContainer container)
            : base(container)
        {
        }

        #endregion
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Category> DbSet
        {
            get
            {
                return  db.Categories;
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return DbSet.ToList();
        }
    }
}
