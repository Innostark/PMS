using PagedList;
using OSS.Models.RequestModels;
using OSS.Web.Models;

namespace OSS.Web.ViewModels
{
    public class BuildingListViewModel
    {
        public IPagedList<Building> BuildingList { get; set; }
        public int? TotalNoOfRec { get; set; }
        public BuildingSearchRequest BuildingSearchRequest { get; set; }
        public Product Product { get; set; }
    }
}