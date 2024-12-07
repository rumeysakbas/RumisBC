using Microsoft.AspNetCore.Mvc;

namespace RumisBC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
