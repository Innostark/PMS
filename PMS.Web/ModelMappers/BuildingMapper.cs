using PMS.Models.DomainModels;

namespace PMS.Web.ModelMappers
{
    public static class BuildingMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.Building CreateFrom(this Building source)
        {
            return new Models.Building
            {
                BuildingId = source.BuildingId,
                Name = source.Name,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                Address = source.Address,
                BuiltDate = source.BuiltDate,
                NoOfFloors = source.NoOfFloors,
                NoOfElevators = source.NoOfElevators,
                Comment = source.Comment,
                CreatedBy = source.CreatedBy,
                UpdatedBy = source.UpdatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedDate = source.UpdatedDate
            };

        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static Building CreateFrom(this Models.Building source)
        {
            return new Building
            {
                BuildingId = source.BuildingId,
                Name = source.Name,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                Address = source.Address,
                BuiltDate = source.BuiltDate,
                NoOfFloors = source.NoOfFloors,
                NoOfElevators = source.NoOfElevators,
                Comment = source.Comment,
                CreatedBy = source.CreatedBy,
                UpdatedBy = source.UpdatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedDate = source.UpdatedDate
            };

        }

        #endregion
    }
}