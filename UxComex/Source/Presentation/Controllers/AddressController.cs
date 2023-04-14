using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using UxComex.Source.Domain.Entities;
using UxComex.Source.Domain.Interfaces.Services;
using UxComex.Source.Infraestructure.Services;
using UxComex.Source.Presentation.ViewModels;

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var address = await _addressService.GetById(id);

            var viewModel = new AddressViewModel
            {
                Id = id,
                City = address.City,
                Street = address.Street,
                State = address.State,
                ClientId=address.ClientId,
                ZipCode = address.ZipCode,
                CreatedAt = address.CreatedAt,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddressViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Client", new { id = viewModel.ClientId });
            }

            var address = new AddressEntity
            {
                Id = viewModel.Id,
                City = viewModel.City,
                Street = viewModel.Street,
                State = viewModel.State,
                ZipCode = viewModel.ZipCode,
                ClientId = viewModel.ClientId,
                UpdatedAt = DateTime.Now
            };

            await _addressService.Update(address);

            return RedirectToAction("Details", "Client", new { id = viewModel.ClientId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = await _addressService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            await _addressService.Delete(id);

            return RedirectToAction("Details", "Client", new { id = client.Id });
        }
    }
}
