using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiagnosticCenterManagement.Data.Models
{
    public class Appointment
    {
        [Key]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartSlotTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndSlotTime { get; set; }

        [ForeignKey("Patient")]
        public int PatientAMKA { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorAMKA { get; set; }
        public Doctor Doctor { get; set; }

        public bool IsAvailable{ get; set; }

    }
}
