namespace LAB4.Models.DTO.Update
{
    public class PolicyUpdateDTO
    {
        public int Id { get; set; }
        public string? PolicyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? PremiumAmount { get; set; }
        public decimal? CoverageAmount { get; set; }
        public int? ClientId { get; set; }
    }
}
