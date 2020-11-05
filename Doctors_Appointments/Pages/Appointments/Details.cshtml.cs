using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Doctors_Appointments.Data;
using Doctors_Appointments.Models;

namespace Doctors_Appointments.Pages.Appointments
{
    public class DetailsModel : PageModel
    {
        private readonly Doctors_Appointments.Data.Doctors_AppointmentsContext _context;

        public DetailsModel(Doctors_Appointments.Data.Doctors_AppointmentsContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
