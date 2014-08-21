using System.Collections.Generic;
using PMS.Models.DomainModels;

namespace PMS.Models.ResponseModels
{
     public sealed class ServiceCompanyResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceCompanyResponse()
        {
            ServiceCompanies = new List<ServiceCompany>();
        }

        /// <summary>
        /// Products
        /// </summary>
        public IEnumerable<ServiceCompany> ServiceCompanies { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
