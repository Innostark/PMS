using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Models.Common;

namespace PMS.Models.RequestModels
{
    public class ApartmentSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Apartment Number
        /// </summary>
        public string ApartmentNumber { get; set; }
        /// <summary>
        /// User Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Product Order By
        /// </summary>
        public ApartmentsByColumn ApartmentOrderBy
        {
            get
            {
                return (ApartmentsByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
