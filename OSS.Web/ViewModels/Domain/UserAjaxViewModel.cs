using System.Collections.Generic;
using OSS.Models.RequestModels;
using OSS.Web.Models;

namespace OSS.Web.ViewModels.Domain
{
    public class UserAjaxViewModel
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
        public IEnumerable<Users> data;

        /// <summary>
        /// Search Request
        /// </summary>
        public UserSearchRequest UserSearchRequest { get; set; }
    }
}