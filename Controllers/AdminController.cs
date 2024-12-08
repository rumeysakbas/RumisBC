using Microsoft.AspNetCore.Mvc;

namespace RumisBC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
