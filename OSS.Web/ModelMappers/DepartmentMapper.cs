using OSS.Web.Models;

namespace OSS.Web.ModelMappers
{
    public static class DepartmentMapper
    {
         #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Department CreateFrom(this OSS.Models.DomainModels.Department source)
        {
            return new Department
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static OSS.Models.DomainModels.Department CreateFrom(this Department source)
        {
            if (source != null)
            {
                return new OSS.Models.DomainModels.Department()
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new OSS.Models.DomainModels.Department();
        }

        #endregion
    }
}