using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Repositories;
using UxComex.Source.Domain.Interfaces.Services;

namespace UxComex.Source.Infraestructure.Services
{

    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Task<IEnumerable<AddressEntity>> GetAll()
        {
            return _addressRepository.GetAllAsync();
        }
        public Task<AddressEntity> GetById(int id)
        {
            return _addressRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<AddressEntity>> GetAllByClientId(int clientId)
        {
            return _addressRepository.GetByClientIdAsync(clientId);
        }

        public Task<int> Create(AddressEntity entity)
        {
            return _addressRepository.InsertAsync(entity);
        }

        public Task<int> Update(AddressEntity entity)
        {
            return _addressRepository.UpdateAsync(entity);
        }

        public Task<int> Delete(int id)
        {
            return _addressRepository.DeleteAsync(id);

        }
    }
}

