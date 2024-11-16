using System.ComponentModel.DataAnnotations;

namespace LAB4.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DayOfBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ICollection<Policy> Policies { get; set; }
    }
}
