using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doctors_Appointments.Data;
using Doctors_Appointments.Models;

namespace Doctors_Appointments.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly Doctors_Appointments.Data.Doctors_AppointmentsContext _context;

        public EditModel(Doctors_Appointments.Data.Doctors_AppointmentsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.ReasonForAppointment).FirstOrDefaultAsync(m => m.Id == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Name");
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Name");
            ViewData["ReasonForAppointmentId"] = new SelectList(_context.Set<ReasonForAppointment>(), "Id", "Reason");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(Appointment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
