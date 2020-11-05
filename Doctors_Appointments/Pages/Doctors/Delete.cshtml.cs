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
    public class DeleteModel : PageModel
    {
        private readonly Doctors_Appointments.Data.Doctors_AppointmentsContext _context;

        public DeleteModel(Doctors_Appointments.Data.Doctors_AppointmentsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = await _context.Doctor.FirstOrDefaultAsync(m => m.Id == id);

            if (Doctor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = await _context.Doctor.FindAsync(id);

            if (Doctor != null)
            {
                _context.Doctor.Remove(Doctor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
