using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Services;

namespace UxComex.Source.Presentation.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(string street, string city, string state, string zipCode, int clientId)
        {
            {
                var address = new AddressEntity
                {
                    City = city,
                    Street = street,
                    State = state,
                    ZipCode = zipCode,
                    ClientId = clientId,
                };

                int id = await _addressService.Create(address);

                return RedirectToAction("Details", "Client", new { id = clientId });
            }

        }
    }
}
