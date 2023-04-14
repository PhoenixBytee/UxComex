using Microsoft.AspNetCore.Mvc;
using UxComex.Source.Domain.Entities;
using UxComex.Source.Presentation.ViewModels;

namespace UxComex.Source.Presentation.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var clients = new List<ClientViewModel>
            {
                new ClientViewModel { Id = 1, Name = "João da Silva", Telephone = "(11) 99999-9999", Cpf = "111.111.111-11", CreatedAt = DateTime.Now, UpdateddAt = DateTime.Now },
                new ClientViewModel { Id = 2, Name = "Maria Santos", Telephone = "(11) 88888-8888", Cpf = "222.222.222-22", CreatedAt = DateTime.Now, UpdateddAt = DateTime.Now },
                new ClientViewModel { Id = 3, Name = "Pedro Souza", Telephone = "(11) 77777-7777", Cpf = "333.333.333-33", CreatedAt = DateTime.Now, UpdateddAt = DateTime.Now },
            };

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