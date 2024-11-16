using LAB4.Models;

namespace LAB4.Repository.IRepository
{
    public interface IPolicyRepository
    {
        public Task<IEnumerable<Policy>> GetPolicies();
        public Task<Policy> GetPolicyById(int policyId);
        public bool PolicyExist(int policyId);
        public void CreatePolicy(Policy policy);
        public Task SaveAsync();
        public void DeletePolicy(int policyId);
        public void UpdatePolicy(Policy policy);
        public bool Exist();
    }
}
