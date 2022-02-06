using DiagnosticCenterManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DiagnosticCenterManagement.Data.Services
{
    public class DcmDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

    }
}
