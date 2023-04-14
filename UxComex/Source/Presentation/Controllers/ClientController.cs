using Microsoft.AspNetCore.Mvc;
using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Services;
using UxComex.Source.Presentation.ViewModels;

namespace UxComex.Source.Presentation.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var clients = await _clientService.GetAll();
            return View(clients);
        }

        public IActionResult Details(int id)
        {
            var client = new ClientEntity
            {
                Id = 1,
                Name = "John Doe",
                Telephone = "(11) 1234-5678",
                Cpf = "111.111.111-11",
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdateddAt = DateTime.Now.AddDays(-5)
            };

            var addressList = new List<AddressViewModel>
            {
                new AddressViewModel { Id = 1, Street = "Main Street", City = "New York", State = "NY", ZipCode = "10001", ClientId = client.Id, CreatedAt = DateTime.Now.AddDays(-10), UpdateddAt = DateTime.Now.AddDays(-5) },
                new AddressViewModel { Id = 2, Street = "Broadway", City = "New York", State = "NY", ZipCode = "10002", ClientId = client.Id, CreatedAt = DateTime.Now.AddDays(-9), UpdateddAt = DateTime.Now.AddDays(-4) }
            };


            if (client == null)
            {
                return NotFound();
            }

            var clientViewModel = new ClientViewModel
            {
                Id = client.Id,
                Name = client.Name,
                Telephone = client.Telephone,
                Cpf = client.Cpf,
                CreatedAt = client.CreatedAt,
                UpdateddAt = client.UpdateddAt
            };

            var viewModel = new ClientDetailsViewModel
            {
                Addresses = addressList,
                Client = clientViewModel
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(client);
        }
    }
}