using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Repositories;
using UxComex.Source.Domain.Interfaces.Services;

namespace UxComex.Source.Infraestructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientEntity>> GetAll()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<ClientEntity> GetById(int id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<int> Create(ClientEntity entity)
        {
            return await _clientRepository.InsertAsync(entity);
        }

        public async Task<int> Update(ClientEntity entity)
        {
            return await _clientRepository.UpdateAsync(entity);
        }

        public async Task<int> Delete(int id)
        {
            return await _clientRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ClientEntity>> GetAllFiltered(string column, string search)
        {
            return await _clientRepository.GetAllFilteredAsync(column, search);
        }
    }
}
