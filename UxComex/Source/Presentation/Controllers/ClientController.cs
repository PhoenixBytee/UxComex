using Microsoft.AspNetCore.Mvc;
using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Services;
using UxComex.Source.Presentation.ViewModels;

namespace UxComex.Source.Presentation.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IAddressService _addressService;

        public ClientController(IClientService clientService, IAddressService addressService)
        {
            _clientService = clientService;
            _addressService = addressService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var clients = await _clientService.GetAll();

            List<ClientViewModel> addressViewModels = clients.Select(c => new ClientViewModel
            {
                Id = c.Id,
                Cpf = c.Cpf,
                Name = c.Name,
                Telephone = c.Telephone,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            }).ToList();

            return View(clients);
        }

        public async Task<IActionResult> Details(int id)
        {
            ClientEntity clientEntity = await _clientService.GetById(id);
            IEnumerable<AddressEntity> addressList = await _addressService.GetAllByClientId(id);

            if (clientEntity == null) return NotFound();

            List<AddressViewModel> addressViewModels = addressList.Select(a => new AddressViewModel
            {
                Id = a.Id,
                Street = a.Street,
                City = a.City,
                State = a.State,
                ZipCode = a.ZipCode,
                ClientId = a.ClientId,
                CreatedAt = a.CreatedAt,
            }).ToList();

            var clientViewModel = new ClientViewModel()
            {
                Id = clientEntity.Id,
                Name = clientEntity.Name,
                Telephone = clientEntity.Telephone,
                Cpf = clientEntity.Cpf,
            };


            var viewModel = new ClientDetailsViewModel
            {
                Addresses = addressViewModels,
                Client = clientViewModel
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = new ClientEntity
            {
                Name = model.Name,
                Telephone = model.Telephone,
                Cpf = model.Cpf,
                CreatedAt = DateTime.Now
            };

            int id = await _clientService.Create(client);

            return RedirectToAction("Details", new { id = id });
        }
    }
}