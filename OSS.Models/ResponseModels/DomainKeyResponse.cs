using System.Collections.Generic;
using OSS.Models.DomainModels;

namespace OSS.Models.ResponseModels
{
    public sealed class DomainKeyResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DomainKeyResponse()
        {
            Users = new List<DomainKeys>();
        }
        /// <summary>
        /// Products
        /// </summary>
        public IEnumerable<DomainKeys> Users { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
