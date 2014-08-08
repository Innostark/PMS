using System.Collections;
using System.Web.Mvc;
using PagedList;
using PMS.Models.RequestModels;
using PMS.Web.Models;

namespace PMS.Web.ViewModels.Products
{
    public class ProductViewModel
    {

        public IPagedList<Product> ProductList { get; set; }
        public IEnumerable Categories { get; set; }
        public SelectList Products { get; set; } //you can assume its a list of sub-categories
        public int? TotalPrice { get; set; }
        public int? TotalNoOfRec { get; set; }
        public ProductSearchRequest ProductSearchRequest { get; set; }
        public Product Product { get; set; }


    }
}
