using UxComex.Source.Domain.Entities;

namespace UxComex.Source.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        Task<IEnumerable<ClientEntity>> GetAllFilteredAsync(string column, string search);
    }
}
