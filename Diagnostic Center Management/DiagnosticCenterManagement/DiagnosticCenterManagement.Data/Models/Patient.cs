using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiagnosticCenterManagement.Data.Models
{
    public class Patient
    {
        [Key]
        public int PatientAMKA { get; set; }
        [Required]
        [MaxLength(45)]
        public string UserId { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        [Required]
        [MaxLength(45)]
        public string Surname { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
