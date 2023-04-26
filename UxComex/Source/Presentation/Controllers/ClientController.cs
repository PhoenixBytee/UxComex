using Microsoft.AspNetCore.Mvc;
using System.Reflection;
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

        public async Task<IActionResult> IndexAsync(string column, string search)
        {
            IEnumerable<ClientEntity> clients;

            if (search == null)
            {
                clients = await _clientService.GetAll();
            } else
            {
                clients = await _clientService.GetAllFiltered(column.Trim().ToLower(), search.Trim().ToLower());
            }

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
            if (!ModelState.IsValid){ 
                TempData["error"] = "Não foi possível salvar o cliente!";
                return View(model);
            }

            var client = new ClientEntity
            {
                Name = model.Name,
                Telephone = model.Telephone,
                Cpf = model.Cpf,
                CreatedAt = DateTime.Now
            };

            try
            {
                int id = await _clientService.Create(client);
                TempData["success"] = "Cliente Salvo com sucesso!";
                return RedirectToAction("Details", new { id = id });
            }catch
            {
                TempData["error"] = "Não foi possível salvar o cliente!";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientService.GetById(id);

            var viewModel = new ClientViewModel
            {
                Id = client.Id,
                Cpf = client.Cpf,
                Name = client.Name,
                Telephone= client.Telephone,
                CreatedAt = client.CreatedAt,
                UpdatedAt = client.CreatedAt
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClientViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", viewModel);
            }

            var client = new ClientEntity
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Cpf= viewModel.Cpf,
                Telephone = viewModel.Telephone,
                UpdatedAt= DateTime.Now
            };

            try
            {
                await _clientService.Update(client);
                TempData["success"] = "Cliente editado com sucesso!";
                return RedirectToAction("Index", "Client");
            }
            catch
            {
                TempData["error"] = "Não foi possível editar o cliente!";
                return View("Edit", viewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            try
            {
                await _clientService.Delete(id);
                TempData["success"] = "Cliente deletado com sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Não foi possível deletar o cliente!";
                return NotFound();
            }
        }

    }
}