using OSS.Models.RequestModels;

namespace OSS.Web.ViewModels.Buildings
{
    public class ABuildingViewModel
    {
        #region Public

        /// <summary>
        /// Search Request
        /// </summary>
        public BuildingSearchRequest SearchRequest { get; set; }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ABuildingViewModel()
        {
            SearchRequest = new BuildingSearchRequest();
        }

        #endregion
    }
}