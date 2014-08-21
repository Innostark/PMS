using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSS.Models.Common;

namespace OSS.Models.RequestModels
{
    public class ServiceCompanySearchRequest : GetPagedListRequest
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
        /// Service Company Order By
        /// </summary>
        public ServiceCompanyByColumn ServiceCompanyOrderBy
        {
            get
            {
                return (ServiceCompanyByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
