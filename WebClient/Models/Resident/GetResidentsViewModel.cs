namespace WebClient.Models.Resident
{
    public class GetResidentsViewModel
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string House { get; set; }
        public bool IsHirer { get; set; }
        public string CarPlate { get; set; }
    }
}
