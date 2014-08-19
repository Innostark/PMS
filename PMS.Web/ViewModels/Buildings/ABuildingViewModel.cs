using PMS.Models.RequestModels;
using PMS.Web.ViewModels.Common;

namespace PMS.Web.ViewModels.Buildings
{
    public class ABuildingViewModel
    {
        #region Public

        /// <summary>
        /// Search Request
        /// </summary>
        public BuildingSearchRequest SearchRequest { get; set; }

        /// <summary>
        /// Message - After Add/Update
        /// </summary>
        public MessageViewModel Message { get; set; }

        /// <summary>
        /// If coming from Add/Edit
        /// </summary>
        public bool IsRedirect { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ABuildingViewModel()
        {
            Message = new MessageViewModel();
            SearchRequest = new BuildingSearchRequest();
        }

        #endregion
    }
}