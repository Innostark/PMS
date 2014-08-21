using System.Linq;
using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product, int>
    {
        ProductResponse GetAllProducts(ProductSearchRequest productSearchRequest);
        IQueryable<Product> GetProductsByCategory(int catID);
        Product GetProductByName(string name, int id);
    }
}
