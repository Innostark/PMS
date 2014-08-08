using System.Collections.Generic;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.IServices
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
