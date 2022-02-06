using DiagnosticCenterManagement.Data.Models;
using DiagnosticCenterManagement.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DiagnosticCenterManagement.Web.Controllers
{
    public class LoginController : Controller
    {
        PatientsService patientsService;
        AdminsService adminsService;

        public LoginController()
        {
            patientsService = new PatientsService(new DcmDbContext());
            adminsService = new AdminsService(new DcmDbContext());

        }
        public ActionResult Login()
        {
            if(adminsService.Get("admin", 1000) ==  null)
                adminsService.Add(new Admin() { UserId = 1000, Username = "admin" });
            
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (DcmDbContext db = new DcmDbContext())
            {
                TempData["id"] = null;
                Patient patientLoggedIn;
                Doctor doctorLoggedIn;
                Admin adminLoggedIn = null;
                patientLoggedIn = patientsService.Get(user.Id, user.AMKA);
                if (patientLoggedIn == null)
                {
                    doctorLoggedIn = db.Doctors.SingleOrDefault(dbUser => dbUser.Username == user.Id && dbUser.DoctorAMKA == user.AMKA);
                    if (doctorLoggedIn == null)
                    {
                        adminLoggedIn = db.Admins.SingleOrDefault(dbUser => dbUser.Username == user.Id && dbUser.UserId == user.AMKA);
                    }
                }

                if (adminLoggedIn != null)
                {
                    TempData["id"] = adminLoggedIn.UserId;
                    return RedirectToAction("Index", "Admins");
                }
                if (patientLoggedIn != null)
                {
                    TempData["PatientAMKA"] = patientLoggedIn.PatientAMKA;
                    return RedirectToAction("Details", "Patients", new { id = patientLoggedIn.PatientAMKA });
                }
                return RedirectToAction("Details", "Doctors");


            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Patient patient)
        {
            if (ModelState.IsValid)
            {
                using (DcmDbContext db = new DcmDbContext())
                {
                    patientsService = new PatientsService(db);
                    patientsService.Add(patient);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return View();
        }
    }
}