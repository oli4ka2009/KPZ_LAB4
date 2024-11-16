namespace LAB4.Models.DTO
{
    public class PolicyDTO
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PremiumAmount { get; set; }
        public decimal CoverageAmount { get; set; }
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
    }
}
