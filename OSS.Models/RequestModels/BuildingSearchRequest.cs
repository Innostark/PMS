using System;
using OSS.Models.Common;

namespace OSS.Models.RequestModels
{
    public class BuildingSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// User Id
        /// </summary>
        public Guid UserId { get; set; }

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
