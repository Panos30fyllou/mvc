using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiagnosticCenterManagement.Data.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorAMKA { get; set; }
        [Required]
        [MaxLength(45)]
        public string Username { get; set; }
        [MaxLength(45)]
        public string Name { get; set; }
        [MaxLength(45)]
        public string Surname { get; set; }
        [MaxLength(45)]
        public string Specialty { get; set; }

        [ForeignKey("Admin")]
        public int UserId { get; set; }
        public Admin Admin{ get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
