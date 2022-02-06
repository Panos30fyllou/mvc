using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiagnosticCenterManagement.Data.Models
{
    public class User
    {
        [Key]
        public int AMKA { get; set; }
        [Required]
        public string Id { get; set; }
    }
}
