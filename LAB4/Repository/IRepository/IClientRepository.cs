using LAB4.Models;

namespace LAB4.Repository.IRepository
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetClients();
        public Task<Client> GetClientById(int clientId);
        public bool ClientExist(int clientId);
        public void CreateClient(Client client);
        public Task SaveAsync();
        public void DeleteClient(int clientId);
        public void UpdateClient(Client client);
        public bool Exist();
    }
}
