using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctors_Appointments.Models
{
    //Client details
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber), Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
    }
}
