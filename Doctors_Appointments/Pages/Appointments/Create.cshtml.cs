using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Doctors_Appointments.Data;
using Doctors_Appointments.Models;

namespace Doctors_Appointments.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly Doctors_Appointments.Data.Doctors_AppointmentsContext _context;

        public CreateModel(Doctors_Appointments.Data.Doctors_AppointmentsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Name");
        ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Name");
        ViewData["ReasonForAppointmentId"] = new SelectList(_context.Set<ReasonForAppointment>(), "Id", "Reason");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
