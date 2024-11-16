using LAB4.Models;
using LAB4.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LAB4.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ClientExist(int clientId)
        {
            return _context.Clients.Any(c => c.Id == clientId);
        }

        public void CreateClient(Client client)
        {
            _context.Clients.Add(client);
        }

        public void DeleteClient(int clientId)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == clientId);
            _context.Clients.Remove(client);
        }

        public bool Exist()
        {
            return _context.Clients != null;
        }

        public async Task<Client> GetClientById(int clientId)
        {
            return await _context.Clients
            .FindAsync(clientId);
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients
            .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateClient(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
        }
    }
}
