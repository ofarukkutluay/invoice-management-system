namespace WebClient.Models.Resident
{
    public class UpdateResidentViewModel
    {
        public int PersonId { get; set; }
        public int HouseId { get; set; }
        public bool IsHirer { get; set; }
        public string CarPlate { get; set; }
    }
}
