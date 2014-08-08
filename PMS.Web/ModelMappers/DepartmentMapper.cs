using PMS.Web.Models;

namespace PMS.Web.ModelMappers
{
    public static class DepartmentMapper
    {
         #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Department CreateFrom(this PMS.Models.DomainModels.Department source)
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
        public static PMS.Models.DomainModels.Department CreateFrom(this Department source)
        {
            if (source != null)
            {
                return new PMS.Models.DomainModels.Department()
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new PMS.Models.DomainModels.Department();
        }

        #endregion
    }
}