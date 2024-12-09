using RumisBC.Models;

namespace RumisBC.Controllers
{using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

    public class RegisterController : Controller
    {

        private Context context = new Context();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", customer);
            }

            context.Customers.Add(customer);
            context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}