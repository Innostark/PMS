using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSS.Models.DomainModels;

namespace OSS.Models.ResponseModels
{
    public sealed class BuildingResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BuildingResponse()
        {
            Buildings = new List<Building>();
        }

        /// <summary>
        /// Products
        /// </summary>
        public IEnumerable<Building> Buildings { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
