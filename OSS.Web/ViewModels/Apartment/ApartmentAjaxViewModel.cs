using System.Collections.Generic;
using OSS.Models.RequestModels;

namespace OSS.Web.ViewModels.Apartment
{
    public class ApartmentAjaxViewModel
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
        public IEnumerable<Models.Apartment> data;

        /// <summary>
        /// Search Request
        /// </summary>
        public ApartmentSearchRequest ApartmentSearchRequest { get; set; }
    }
}