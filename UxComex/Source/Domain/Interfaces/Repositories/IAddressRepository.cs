using UxComex.Source.Domain.Entities;

namespace UxComex.Source.Domain.Interfaces.Repositories
{
    public interface IAddressRepository : IRepository<AddressEntity>
    {
        Task<IEnumerable<AddressEntity>> GetByClientIdAsync(int clientId);
    }
}
