namespace WebClient.Models.Resident
{
    public class GetResidentsViewModel
    {
        public int PersonId { get; set; }
        public int HouseId { get; set; }
        public bool IsHirer { get; set; }
        public string CarPlate { get; set; }
    }
}
