using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Doctors_Appointments.Data;
using Doctors_Appointments.Models;

namespace Doctors_Appointments.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly Doctors_Appointments.Data.Doctors_AppointmentsContext _context;

        public IndexModel(Doctors_Appointments.Data.Doctors_AppointmentsContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync(string SearchString)
        {
            var doctors = from m in _context.Doctor
                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                doctors = doctors.Where(s => s.Name.Contains(SearchString));
            }

            Doctor = await doctors.ToListAsync();
        }
    }
}
