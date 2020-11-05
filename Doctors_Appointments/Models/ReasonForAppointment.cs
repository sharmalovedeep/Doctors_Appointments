using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctors_Appointments.Models
{
    //Patients reason for appointment
    public class ReasonForAppointment
    {
        //Primary Key
        public int Id { get; set; }
       
        //Holds the reason for appointment
        public string Reason { get; set; }

        //Holds the Price of the appointment
        [DataType(DataType.Currency)]
        public decimal Charge { get; set; }
    }
}
