using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS.Models.RequestModels;

namespace PMS.Web.ViewModels.ServiceCompany
{
    public class ServiceCompanyAjaxViewModel
    {
        /// <summary>
        /// To draw table
        /// </summary>
        private int draw = 1;

        /// <summary>
        /// Total Records in DB
        /// </summary>
        public int recordsTotal;

        /// <summary>
        /// Total Records Filtered
        /// </summary>
        public int recordsFiltered;

        /// <summary>
        /// Data
        /// </summary>
        public IEnumerable<Models.ServiceCompany> data;

        /// <summary>
        /// Search Request
        /// </summary>
        public ServiceCompanySearchRequest ServiceCompanySearchRequest{ get; set; }
    }
}