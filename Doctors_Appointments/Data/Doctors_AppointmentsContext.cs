using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Doctors_Appointments.Models;

namespace Doctors_Appointments.Data
{
    public class Doctors_AppointmentsContext : DbContext
    {
        public Doctors_AppointmentsContext (DbContextOptions<Doctors_AppointmentsContext> options)
            : base(options)
        {
        }

        public DbSet<Doctors_Appointments.Models.Doctor> Doctor { get; set; }

        public DbSet<Doctors_Appointments.Models.Patient> Patient { get; set; }

        public DbSet<Doctors_Appointments.Models.ReasonForAppointment> ReasonForAppointment { get; set; }

        public DbSet<Doctors_Appointments.Models.Appointment> Appointment { get; set; }
    }
}
