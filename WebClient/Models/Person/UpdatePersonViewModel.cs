namespace WebClient.Models.Person
{
    public class UpdatePersonViewModel
    {
        public int Id { get; set; }
        public long CitizenId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
