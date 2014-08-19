using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.MenuModels;
using PMS.Repository.BaseRepository;
namespace PMS.Repository.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuRepository(IUnityContainer container)
            :base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Menu> DbSet
        {
            get { return db.Menus; }
        }
        #endregion

        #region Public


        #endregion
    }
}
