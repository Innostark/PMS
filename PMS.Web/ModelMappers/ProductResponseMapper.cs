using System.Linq;
using PMS.Models.ResponseModels;

namespace PMS.Web.ModelMappers
{
    /// <summary>
    /// Product Response Mapper
    /// </summary>
    public static class ProductResponseMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.ProductResponse CreateFrom(this ProductResponse source)
        {
            return new Models.ProductResponse
            {
                TotalCount = source.TotalCount,
                Products = source.Products.Select(p => p.CreateFrom())
            };
           
        }

        #endregion

    }
}
