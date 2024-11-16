using LAB4.Models;
using LAB4.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LAB4.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ApplicationDbContext _context;

        public PolicyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool PolicyExist(int policyId)
        {
            return _context.Policies.Any(c => c.Id == policyId);
        }

        public void CreatePolicy(Policy policy)
        {
            _context.Policies.Add(policy);
        }

        public void DeletePolicy(int policyId)
        {
            var policy = _context.Policies.FirstOrDefault(c => c.Id == policyId);
            _context.Policies.Remove(policy);
        }

        public bool Exist()
        {
            return _context.Policies != null;
        }

        public async Task<Policy> GetPolicyById(int policyId)
        {
            return await _context.Policies
            .Include(o => o.Client)
            .FirstOrDefaultAsync(o => o.Id == policyId);
        }

        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            return await _context.Policies.Include(o => o.Client)
            .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdatePolicy(Policy policy)
        {
            _context.Entry(policy).State = EntityState.Modified;
        }
    }
}
