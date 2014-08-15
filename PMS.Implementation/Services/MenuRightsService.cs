using System.Collections.Generic;
using System.Linq;
using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.MenuModels;

namespace PMS.Implementation.Services
{
    /// <summary>
    /// Menu Rights Service
    /// </summary>
    public sealed class MenuRightsService: IMenuRightsService
    {
        #region Private
        private readonly IMenuRightRepository menuRightRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuRightsService(IMenuRightRepository menuRightRepository)
        {
            this.menuRightRepository = menuRightRepository;

        }
        #endregion

        #region Public
        /// <summary>
        /// Find Menu Items by Role ID
        /// </summary>
        public IEnumerable<MenuRight> FindMenuItemsByRoleId(string roleId)
        {
 	       return menuRightRepository.GetMenuByRole(roleId).ToList();
        }

        #endregion
    }
}
