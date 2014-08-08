using PMS.Web.Models;

namespace PMS.Web.ModelMappers
{
    public static class CategoryMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Category CreateFrom(this PMS.Models.DomainModels.Category source)
        {
            return new Category
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static PMS.Models.DomainModels.Category CreateFrom(this Category source)
        {
            if (source != null)
            {
                return new PMS.Models.DomainModels.Category
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new PMS.Models.DomainModels.Category();
        }

        #endregion
    }
}
