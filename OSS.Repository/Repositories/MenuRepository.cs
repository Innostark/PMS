using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using OSS.Interfaces.Repository;
using OSS.Models.MenuModels;
using OSS.Repository.BaseRepository;
namespace OSS.Repository.Repositories
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
