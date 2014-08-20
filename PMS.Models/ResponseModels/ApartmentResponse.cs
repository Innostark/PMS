using System.Collections.Generic;
using PMS.Models.DomainModels;

namespace PMS.Models.ResponseModels
{
    public sealed class ApartmentResponse
    {
    /// <summary>
        /// Constructor
        /// </summary>
        public ApartmentResponse()
        {
            Apartments = new List<Apartment>();
        }

        /// <summary>
        /// Products
        /// </summary>
        public IEnumerable<Apartment> Apartments { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
