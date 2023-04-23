using UxComex.Source.Domain.Entities;

namespace UxComex.Source.Domain.Interfaces.Services
{
    public interface IClientService : IService<ClientEntity>
    {
        Task<IEnumerable<ClientEntity>> GetAllFiltered(string column, string search);
    }
}
