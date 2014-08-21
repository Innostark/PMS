using System.Collections.Generic;
using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Interfaces.IServices
{
    public interface IProductService
    {
        ProductResponse LoadAllProducts(ProductSearchRequest productSearchRequest);
        Product FindProduct(int id);
        IEnumerable<Product> FindProductsByCategory(int catId); 
        void DeleteProduct(Product product);
        bool AddProduct(Product product);
        bool Update(Product product);//,Category category

    }
}
