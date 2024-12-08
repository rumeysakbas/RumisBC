using Microsoft.AspNetCore.Mvc;
using RumisBC.Models;

namespace RumisBC.Controllers
{
    public class LoginController : Controller
    {

		private Context context = new Context();
		public IActionResult Index()
        {
            return View();
        }

		public IActionResult Login(string Email, string Password)
        {
			var customer = context.Customers.Where(u => u.Email.Equals(Email) && u.Password.Equals(Password)).ToList();
			var admin = context.Admins.Where(a => a.AdminEmail.Equals(Email) && a.AdminPassword.Equals(Password)).ToList();

			if (admin.Count > 0)
			{
				foreach (var item in admin)
				{
					HttpContext.Session.SetString("AdminId", item.AdminID.ToString());
					HttpContext.Session.SetString("AdminName", item.AdminName.ToString());
					HttpContext.Session.SetString("AdminMail", item.AdminEmail.ToString());
				}
				return RedirectToAction("Dashboard", "Admin");

			}
			else if (customer.Count > 0)
			{
				foreach (var item in customer)
				{
					HttpContext.Session.SetString("UserId", item.CustomerID.ToString());
					HttpContext.Session.SetString("UserName", item.Email.ToString());
				}
				return RedirectToAction("Index", "Home");

			}
			else
			{
				ViewBag.msg = "Geçersiz email ya da şifre !!";
				return View();
			}
		}

        public IActionResult CLogout()
        {
            if (HttpContext.Session.GetString("UserId") is null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                HttpContext.Session.Remove("UserId");
                HttpContext.Session.Remove("UserName");
                return RedirectToAction("Index", "Login");
            }

        }

    }
}
