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
    public class IndexModel : PageModel
    {
        private readonly Doctors_Appointments.Data.Doctors_AppointmentsContext _context;

        public IndexModel(Doctors_Appointments.Data.Doctors_AppointmentsContext context)
        {
            _context = context;
        }

        public List<Appointment> Appointment { get;set; }
        public async Task OnGetAsync()
        {

            Appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.ReasonForAppointment).ToListAsync();
            
      


        }
    }
}
