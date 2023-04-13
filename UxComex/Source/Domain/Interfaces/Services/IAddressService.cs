using UxComex.Source.Domain.Entities;

namespace UxComex.Source.Domain.Interfaces.Services
{
    public interface IAddressService : IService<AddressEntity>
    {
        Task<IEnumerable<AddressEntity>> GetAllByClientId(int clientId);
    }
}
