using DiagnosticCenterManagement.Data.Models;
using DiagnosticCenterManagement.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DiagnosticCenterManagement.Data.Services
{
    public class AdminsService : IEntityService<Admin, string, int>
    {
        private readonly DcmDbContext db;

        public AdminsService(DcmDbContext db)
        {
            this.db = db;
        }
        public void Add(Admin admin)
        {
            db.Admins.Add(admin);
            db.SaveChanges();
        }
        public Admin Get(string username, int amka)
        {
            return db.Admins.SingleOrDefault(admin => admin.UserId == amka && admin.Username == username);
        }
        public IEnumerable<Admin> GetAll()
        {
            return db.Admins;
        }
    }
}
