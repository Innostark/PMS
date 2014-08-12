using System;
using System.Collections.Generic;
using System.Globalization;
using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Implementation.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;

        }

        public ProductResponse LoadAllProducts(ProductSearchRequest productSearchRequest)
        {

            return productRepository.GetAllProducts(productSearchRequest);
        }

        public Product FindProduct(int id)
        {
            return productRepository.Find(id);
        }

        public void DeleteProduct(Product product)
        {
            Product productDbVersion = FindProduct(product.Id);
            if (productDbVersion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Product with Id {0} not found!", product.Id));
            }

            productRepository.Delete(productDbVersion);
            productRepository.SaveChanges();
        }

        public bool AddProduct(Product product)
        {
            if(ValidateProduct(product))
            {
                productRepository.Add(product);
                productRepository.SaveChanges();
                return true;
            }
            return false;
        }

        private bool ValidateProduct(Product product)
        {
            Product productDbVersion = productRepository.GetProductByName(product.Name, product.Id);
            return productDbVersion == null;
        }

        public bool Update(Product product)
        {
            if (ValidateProduct(product))
            {
                productRepository.Update(product);
                productRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Product> FindProductsByCategory(int catId)
        {
            return productRepository.GetProductsByCategory(catId);
        }
    }
}
