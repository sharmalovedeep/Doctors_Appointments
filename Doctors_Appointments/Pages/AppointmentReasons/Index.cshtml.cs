using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Doctors_Appointments.Data;
using Doctors_Appointments.Models;

namespace Doctors_Appointments.Pages.AppointmentReasons
{
    public class IndexModel : PageModel
    {
        private readonly Doctors_Appointments.Data.Doctors_AppointmentsContext _context;

        public IndexModel(Doctors_Appointments.Data.Doctors_AppointmentsContext context)
        {
            _context = context;
        }

        public IList<ReasonForAppointment> ReasonForAppointment { get;set; }

        public async Task OnGetAsync()
        {
            ReasonForAppointment = await(from ReasonForAppointment in _context.ReasonForAppointment select ReasonForAppointment).ToListAsync();
        }
    }
}
