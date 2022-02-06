using DiagnosticCenterManagement.Data.Models;
using DiagnosticCenterManagement.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DiagnosticCenterManagement.Data.Services
{
    public class DoctorsService : IEntityService<Doctor, string, int>
    {
        private readonly DcmDbContext db;

        public DoctorsService(DcmDbContext db)
        {
            this.db = db;
        }
        public void Add(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();
        }
        public Doctor Get(string username, int amka)
        {
            return db.Doctors.SingleOrDefault(doctor => doctor.DoctorAMKA == amka && doctor.Username == username);
        }
        public IEnumerable<Doctor> GetAll()
        {
            return db.Doctors;
        }
    }
}
