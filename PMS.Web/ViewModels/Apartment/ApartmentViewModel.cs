using System.Collections.Generic;

namespace PMS.Web.ViewModels.Apartment
{
    public class ApartmentViewModel
    {
        //Show List On ClientSide
        public IEnumerable<Models.Apartment> ApartmentsList { get; set; }

        //Take Data For Edit
        public Models.Apartment Apartment { get; set; }
    }
}