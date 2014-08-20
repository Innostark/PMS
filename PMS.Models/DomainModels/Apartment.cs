﻿namespace PMS.Models.DomainModels
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string ApartmentNo { get; set; }
        public string BuildingNo { get; set; }
        public string NoOfRooms { get; set; }
        public string NoOfRestRoooms { get; set; }
        public string NoOfAlmarah { get; set; }
        public string TotalArea { get; set; }
        public string Comment { get; set; }
        public string MasterBedSize { get; set; }
        public string KitchenSize { get; set; }
        public int NoOfWindows { get; set; }
        public int NoOfDoors { get; set; }
        public int NoOfWashRooms { get; set; }
        public int FloorNumber { get; set; }
        public int NoOfElectricalsInstalled { get; set; }
        public int NoOfDoorLocks { get; set; }
        public bool SecurityCamerasInstalled { get; set; }
        public virtual Building Building { get; set; }
    }
}
