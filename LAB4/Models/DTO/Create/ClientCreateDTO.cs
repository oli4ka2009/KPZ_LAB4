using System.ComponentModel.DataAnnotations;

namespace LAB4.Models.DTO.Create
{
    public class ClientCreateDTO
    {
        [Required(ErrorMessage = "The FirstName field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The LastName field is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The DayOfBirth field is required.")]
        public DateTime DayOfBirth { get; set; }
        [Required(ErrorMessage = "The PhoneNumber field is required.")]
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
