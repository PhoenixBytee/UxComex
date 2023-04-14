using Microsoft.AspNetCore.Mvc;

namespace UxComex.Source.Presentation.Controllers
{
    public class AddressController : Controller
    {
        [HttpPost]
        public IActionResult Create(string street, string city, string state, string zipCode)
        {
            return RedirectToAction("Index", "Client");
        }

    }
}
