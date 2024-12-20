using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RumisBC.Models;

namespace RumisBC.Controllers
{
    public class MyAppointmentsController : Controller
    {


    public async Task<IActionResult> Index()
    {
        string userId = HttpContext.Session.GetString("UserId");

        if (string.IsNullOrEmpty(userId))
        {
            ViewBag.ErrorMessage = "Kullanıcı oturumu bulunamadı.";
            return RedirectToAction("Error");
        }

        List<AppointmentViewModel> appointments = null;

        using (HttpClient client = new HttpClient())
        {
            string apiUrl = $"https://localhost:7239/api/ApiAppointments/{userId}";
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                try
                {
                    appointments = JsonConvert.DeserializeObject<List<AppointmentViewModel>>(responseText);
                }
                catch (JsonSerializationException)
                {
                    ViewBag.ErrorMessage = "Randevular alınırken bir hata oluştu.";
                    return RedirectToAction("Error");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Randevular alınamadı.";
                return RedirectToAction("Error");
            }
        }

        return View(appointments);
    }

}
}
