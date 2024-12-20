using Microsoft.AspNetCore.Mvc;
using RumisBC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RumisBC.Controllers
{
    public class BookingController : Controller
    {
        private readonly Context _context;
        private Context context = new Context();

        public BookingController()
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employers.ToList();
            var bookedSlots = _context.Bookings.ToList();

            var bookingData = employees.SelectMany(employee =>
            {
                var slots = new List<object>();
                var startTime = employee.StartTime;
                var endTime = employee.EndTime;

                while (startTime < endTime)
                {
                    // Eğer bu saat aralığı için bir randevu yoksa listeye ekle
                    if (!bookedSlots.Any(b => b.EmployerID == employee.EmployerID && b.BookingDate == startTime))
                    {
                        slots.Add(new
                        {
                            EmployeeId = employee.EmployerID,
                            EmployeeName = $"{employee.FirstName} {employee.LastName}",
                            Expertise = employee.Expertise,
                            Price = employee.Price,
                            StartTime = startTime,
                            EndTime = startTime.AddHours(1)
                        });
                    }
                    startTime = startTime.AddHours(1);
                }

                return slots;
            }).ToList();

            return View(bookingData);
        }


        [HttpPost]
        public IActionResult BookAppointment(int employeeId, DateTime startTime)
        {
            // Kullanıcı ID'sini Session'dan al
            var userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "Kullanıcı oturumu geçersiz. Lütfen tekrar giriş yapın.";
                return RedirectToAction("Index");
            }

            var employee = _context.Employers.FirstOrDefault(e => e.EmployerID == employeeId);

            if (employee != null)
            {
                var booking = new Booking
                {
                    BookingDate = startTime,
                    CustomerName = userId, // Kullanıcı ID'sini CustomerName olarak kaydediyoruz
                    EmployerID = employeeId
                };

                _context.Bookings.Add(booking);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Randevu başarıyla alındı!";
            }
            else
            {
                TempData["ErrorMessage"] = "Randevu alma işlemi başarısız oldu.";
            }

            return RedirectToAction("Index");
        }


    }
}
