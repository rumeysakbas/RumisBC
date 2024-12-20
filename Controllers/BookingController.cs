using Microsoft.AspNetCore.Mvc;

namespace RumisBC.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
