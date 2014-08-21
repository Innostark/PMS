using OSS.Models.DomainModels;

namespace OSS.Web.ModelMappers
{
    public static class ProductMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.Product CreateFrom(this Product source)
        {
             return new Models.Product
            {
                Id = source.Id,
                Name = source.Name,
                CategoryId = source.CategoryId,
                Description = source.Description,
                Price = source.Price,
                Category=source.Category.CreateFrom()
            };
           
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static Product CreateFrom(this Models.Product source)
        {
             return new Product
            {
                Id = source.Id,
                Name = source.Name,
                CategoryId = source.CategoryId,
                Description = source.Description,
                Price = source.Price
            };
           
        }

        #endregion

    }
}
