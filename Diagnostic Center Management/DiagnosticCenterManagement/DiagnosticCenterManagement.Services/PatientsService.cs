using DiagnosticCenterManagement.Data.Models;
using DiagnosticCenterManagement.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DiagnosticCenterManagement.Data.Services
{
    public class PatientsService : IEntityService<Patient, string, int>
    {
        private readonly DcmDbContext db;

        public PatientsService(DcmDbContext db)
        {
            this.db = db;
        }
        public void Add(Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
        }
        public Patient Get(string username, int amka)
        {
            return db.Patients.SingleOrDefault(patient => patient.PatientAMKA == amka && patient.UserId == username);
        }
        public IEnumerable<Patient> GetAll()
        {
            return db.Patients.ToList();
        }
    }
}
