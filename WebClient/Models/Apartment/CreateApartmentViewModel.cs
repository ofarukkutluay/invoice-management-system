using System.ComponentModel;

namespace WebClient.Models.Apartment
{
    public class CreateApartmentViewModel
    {
        public string Name { get; set; }
        
        [DisplayName("Total Floors")]
        public int TotalFloors { get; set; }
    }
}
