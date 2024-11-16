namespace LAB4.Models.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
