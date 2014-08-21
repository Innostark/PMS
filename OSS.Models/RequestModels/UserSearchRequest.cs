using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSS.Models.Common;

namespace OSS.Models.RequestModels
{
    public class UserSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Product Order By
        /// </summary>
        public UserByColumn BuildingOrderBy
        {
            get
            {
                return (UserByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
