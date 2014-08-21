using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Models.Common;

namespace PMS.Models.RequestModels
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
