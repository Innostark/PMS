using System.Collections.Generic;
using PMS.Models.RequestModels;

namespace PMS.Web.ViewModels.ServiceCompany
{
    public class ServiceCompanyViewModel
    {
        public IEnumerable<Models.ServiceCompany> ServiceCompaniesList { get; set; }

        //Take Data For Edit
        public Models.ServiceCompany ServiceCompany { get; set; }

        /// <summary>
        /// Search Request
        /// </summary>
        public ServiceCompanySearchRequest SearchRequest { get; set; }
    }
}