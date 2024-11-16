using System.ComponentModel.DataAnnotations;

namespace LAB4.Models.DTO.Create
{
    public class PolicyCreateDTO
    {
        [Required(ErrorMessage = "The PolicyName field is required.")]
        public string PolicyName { get; set; }
        [Required(ErrorMessage = "The StartDate field is required.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "The EndDate field is required.")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "The PremiumAmount field is required.")]
        public decimal PremiumAmount { get; set; }
        [Required(ErrorMessage = "The CoverageAmount field is required.")]
        public decimal CoverageAmount { get; set; }
        [Required(ErrorMessage = "The ClientId field is required.")]
        public int ClientId { get; set; }
    }
}
