using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PMS.Web.Models
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        [Required(ErrorMessage = "Appartment Number is required")]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string ApartmentNo { get; set; }
        [Required(ErrorMessage = "Building Number is required")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public int BuildingId { get; set; }
        [Required(ErrorMessage = "No Of Rooms is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string NoOfRooms { get; set; }
        [Required(ErrorMessage = "No Of Rest Roooms is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string NoOfRestRoooms { get; set; }
        [Required(ErrorMessage = "No Of Almarah is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string NoOfAlmarah { get; set; }
        [Required(ErrorMessage = "Total Area is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string TotalArea { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Comment { get; set; }
        [Required(ErrorMessage = "Master Bed Size is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string MasterBedSize { get; set; }
        [Required(ErrorMessage = "Kitchen Size is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string KitchenSize { get; set; }
        [Required(ErrorMessage = "No Of Windows is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int NoOfWindows { get; set; }
        [Required(ErrorMessage = "No Of Doors is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int NoOfDoors { get; set; }
        [Required(ErrorMessage = "No Of WashRooms is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int NoOfWashRooms { get; set; }
        [Required(ErrorMessage = "Floor Number is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int FloorNumber { get; set; }
        [Required(ErrorMessage = "No Of Electricals Installed is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int NoOfElectricalsInstalled { get; set; }
        [Required(ErrorMessage = "No Of Door Locks is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int NoOfDoorLocks { get; set; }
        [Required(ErrorMessage = "Mentioning Security Cameras Installation required")]
        public bool SecurityCamerasInstalled { get; set; }

        public string BuildingName { get; set; }
        public IList<Building> Buildings { get; set; } 
       
    }
}