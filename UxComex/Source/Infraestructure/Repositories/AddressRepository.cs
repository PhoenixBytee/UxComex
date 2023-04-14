using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Repositories;

namespace UxComex.Source.Infraestructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string _connectionString;

        public AddressRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<IEnumerable<AddressEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressEntity>> GetByClientIdAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<AddressEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(AddressEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(AddressEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
