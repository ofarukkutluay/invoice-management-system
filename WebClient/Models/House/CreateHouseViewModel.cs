using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebClient.Models.Apartment;
using WebClient.Models.FlatType;

namespace WebClient.Models.House
{
    public class CreateHouseViewModel
    {
        public int ApartmentId { get; set; }
        public int FloorLocation { get; set; }
        public int DoorNumber { get; set; }
        public int FlatTypeId { get; set; }
        public IEnumerable<SelectListItem> Apartments { get; set; }
        public IEnumerable<SelectListItem> FlatTypes { get; set; }

    }
}
