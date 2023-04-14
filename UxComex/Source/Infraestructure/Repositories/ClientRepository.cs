using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Repositories;

namespace UxComex.Source.Infraestructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClientEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(ClientEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ClientEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
