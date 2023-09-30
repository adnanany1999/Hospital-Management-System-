using System;
using Hospital2.Data;
using Hospital2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Hospital2.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Fetch the user based on email and mobile
                var user = await _context.Users
                                         .Where(u => u.Email == model.Email && u.PhoneNumber == model.Mobile)
                                         .FirstOrDefaultAsync();

                if (user != null)
                {
                    // In a real-world scenario, you'd hash the password.
                    // This is just a simplified example.
                    user.PasswordHash = model.NewPassword;  // This is not secure. Use ASP.NET Core Identity's built-in password hasher.
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    // Usually, you'd send an email confirmation, or redirect to a confirmation page.
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No user found with the provided email and mobile.");
                }
            }

            return View(model);
        }
    

  public async Task<IActionResult> Index()
        {
            return View(await _context.Appointments.ToListAsync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to a listing page or any other action after successful creation
            }
            return View(appointment);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AID,Section,Name,Gender,Mobile,Email,Date")] Appointment appointment)
        {
            if (id != appointment.AID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.AID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AID == id);
        }
		public IActionResult Contact()
		{
			return View();
		}
        public IActionResult Appointment()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> SubmitFeedback(Feedback feedback)
		{
			if (ModelState.IsValid)
			{
				_context.Feedbacks.Add(feedback);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index", "Home"); // Redirecting to the Home controller's Index action. Adjust as needed.
			}
			return View("Contact", feedback);
		}
	}

}


