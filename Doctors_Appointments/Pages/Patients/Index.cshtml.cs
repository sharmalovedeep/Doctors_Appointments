using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Doctors_Appointments.Data;
using Doctors_Appointments.Models;

namespace Doctors_Appointments.Pages.patients
{
    public class IndexModel : PageModel
    {
        private readonly Doctors_Appointments.Data.Doctors_AppointmentsContext _context;

        public IndexModel(Doctors_Appointments.Data.Doctors_AppointmentsContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task OnGetAsync(string SearchString)
        {
            var patients = from m in _context.Patient
                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                patients = patients.Where(s => s.Name.Contains(SearchString));
            }

            Patient = await patients.ToListAsync();
        }
    }
}
