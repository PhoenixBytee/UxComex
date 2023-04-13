using System.Net;
using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Repositories;

namespace UxComex.Source.Infraestructure.Repositories
{
    public class IAddressRepository : IRepository<AddressEntity>
    {
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressEntity>> GetAllAsync()
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

        public Task<bool> UpdateAsync(AddressEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
