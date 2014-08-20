using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Models.Common;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;
using PMS.Repository.BaseRepository;
namespace PMS.Repository.Repositories
{
    public sealed class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
         #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ApartmentRepository(IUnityContainer container)
            : base(container)
        {

        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Apartment> DbSet
        {
            get { return db.Apartments; }
        }

        #endregion
        #region Private
        /// <summary>
        /// Order by Column Names Dictionary statements - for Product
        /// </summary>
        private readonly Dictionary<ApartmentsByColumn, Func<Apartment, object>> apartmentClause =
              new Dictionary<ApartmentsByColumn, Func<Apartment, object>>
                    {
                        { ApartmentsByColumn.AppartmentNo, c => c.ApartmentNo},
                        { ApartmentsByColumn.BuildingNo, c => c.BuildingNo},
                        { ApartmentsByColumn.NoOfRooms, c => c.NoOfRooms },
                        { ApartmentsByColumn.NoOfRestRoooms, c => c.NoOfRestRoooms},
                        { ApartmentsByColumn.NoOfAlmarah, c => c.NoOfAlmarah},
                        { ApartmentsByColumn.TotalArea, c => c.TotalArea},
                        { ApartmentsByColumn.Comment, c => c.Comment},
                        { ApartmentsByColumn.MasterBedSize, c => c.MasterBedSize},
                        { ApartmentsByColumn.KitchenSize, c => c.KitchenSize},
                        { ApartmentsByColumn.NoOfWindows, c => c.NoOfWindows},
                        { ApartmentsByColumn.NoOfDoors, c => c.NoOfDoors},
                        { ApartmentsByColumn.NoOfWashRooms, c => c.NoOfWashRooms},
                        { ApartmentsByColumn.FloorNumber, c => c.FloorNumber},
                        { ApartmentsByColumn.NoOfElectricalsInstalled, c => c.NoOfElectricalsInstalled},
                        { ApartmentsByColumn.NoOfDoorLocks, c => c.NoOfDoorLocks},
                        { ApartmentsByColumn.SecurityCamerasInstalled, c => c.SecurityCamerasInstalled}
                    };
        #endregion
    }
}
