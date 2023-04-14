using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UxComex.Models;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}