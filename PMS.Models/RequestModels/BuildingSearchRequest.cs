using PMS.Models.Common;

namespace PMS.Models.RequestModels
{
    public class BuildingSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Product Order By
        /// </summary>
        public BuildingByColumn BuildingOrderBy
        {
            get
            {
                return (BuildingByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
