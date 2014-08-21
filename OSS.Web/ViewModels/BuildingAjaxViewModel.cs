using System.Collections.Generic;
using OSS.Models.RequestModels;
using OSS.Web.Models;

namespace OSS.Web.ViewModels
{
    public class BuildingAjaxViewModel
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
        public IEnumerable<Building> data;

        /// <summary>
        /// Search Request
        /// </summary>
        public BuildingSearchRequest BuildingSearchRequest { get; set; }

    }
}