using System.Collections.Generic;
using PMS.Models.RequestModels;

namespace PMS.Web.ViewModels.Apartment
{
    public class ApartmentViewModel
    {
        //Show List On ClientSide
        public IEnumerable<Models.Apartment> ApartmentsList { get; set; }

        //Take Data For Edit
        public Models.Apartment Apartment { get; set; }
        /// <summary>
        /// Search Request
        /// </summary>
        public ApartmentSearchRequest SearchRequest { get; set; }
    }
}