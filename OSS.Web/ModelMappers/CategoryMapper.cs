﻿using OSS.Web.Models;

namespace OSS.Web.ModelMappers
{
    public static class CategoryMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Category CreateFrom(this OSS.Models.DomainModels.Category source)
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
        public static OSS.Models.DomainModels.Category CreateFrom(this Category source)
        {
            if (source != null)
            {
                return new OSS.Models.DomainModels.Category
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new OSS.Models.DomainModels.Category();
        }

        #endregion
    }
}