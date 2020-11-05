using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctors_Appointments.Models
{
    //Doctors details
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsFullTime { get; set; }
    }
}
