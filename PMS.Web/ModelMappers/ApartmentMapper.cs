using PMS.Models.DomainModels;

namespace PMS.Web.ModelMappers
{
    public static class ApartmentMapper
    {
        public static Apartment CreateFrom(this Models.Apartment modelApartment)
        {
            return new Apartment
                   {
                       ApartmentId = modelApartment.ApartmentId,
                       ApartmentNo = modelApartment.ApartmentNo,
                       BuildingNo = modelApartment.BuildingNo,
                       Comment = modelApartment.Comment,
                       FloorNumber = modelApartment.FloorNumber,
                       KitchenSize = modelApartment.KitchenSize,
                       MasterBedSize = modelApartment.MasterBedSize,
                       NoOfAlmarah = modelApartment.NoOfAlmarah,
                       NoOfRooms = modelApartment.NoOfRooms,
                       NoOfRestRoooms = modelApartment.NoOfRestRoooms,
                       TotalArea = modelApartment.TotalArea,
                       NoOfWindows = modelApartment.NoOfWindows,
                       NoOfDoors = modelApartment.NoOfDoors,
                       NoOfWashRooms = modelApartment.NoOfWashRooms,
                       NoOfElectricalsInstalled = modelApartment.NoOfElectricalsInstalled,
                       NoOfDoorLocks = modelApartment.NoOfDoorLocks,
                       SecurityCamerasInstalled = modelApartment.SecurityCamerasInstalled
                   };
        }

        public static Models.Apartment CreateFrom(this Apartment modelApartment)
        {
            return new Models.Apartment
                   {
                       ApartmentId = modelApartment.ApartmentId,
                       ApartmentNo = modelApartment.ApartmentNo,
                       BuildingNo = modelApartment.BuildingNo,
                       Comment = modelApartment.Comment,
                       FloorNumber = modelApartment.FloorNumber,
                       KitchenSize = modelApartment.KitchenSize,
                       MasterBedSize = modelApartment.MasterBedSize,
                       NoOfAlmarah = modelApartment.NoOfAlmarah,
                       NoOfRooms = modelApartment.NoOfRooms,
                       NoOfRestRoooms = modelApartment.NoOfRestRoooms,
                       TotalArea = modelApartment.TotalArea,
                       NoOfWindows = modelApartment.NoOfWindows,
                       NoOfDoors = modelApartment.NoOfDoors,
                       NoOfWashRooms = modelApartment.NoOfWashRooms,
                       NoOfElectricalsInstalled = modelApartment.NoOfElectricalsInstalled,
                       NoOfDoorLocks = modelApartment.NoOfDoorLocks,
                       SecurityCamerasInstalled = modelApartment.SecurityCamerasInstalled
                   };
        }
    }
}