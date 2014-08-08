using System.Linq;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product, int>
    {
        ProductResponse GetAllProducts(ProductSearchRequest productSearchRequest);
        IQueryable<Product> GetProductsByCategory(int catID);
        Product GetProductByName(string name, int id);
    }
}
