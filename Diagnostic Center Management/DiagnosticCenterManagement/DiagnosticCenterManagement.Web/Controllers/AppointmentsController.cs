using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiagnosticCenterManagement.Data.Models;
using DiagnosticCenterManagement.Data.Services;

namespace DiagnosticCenterManagement.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private DcmDbContext db = new DcmDbContext();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.Specialty = new SelectList(db.Doctors, "DoctorAMKA", "Specialty");
            ViewBag.DoctorAMKA = new SelectList(db.Doctors, "DoctorAMKA", "Username");
            ViewBag.PatientAMKA = new SelectList(db.Patients, "PatientAMKA", "UserId");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,StartSlotTime,EndSlotTime,DoctorAMKA")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.DoctorAMKA = db.Doctors.FirstOrDefault().DoctorAMKA;
                appointment.PatientAMKA = Int32.Parse(TempData["PatientAMKA"].ToString());
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorAMKA = new SelectList(db.Doctors, "DoctorAMKA", "Username", appointment.DoctorAMKA);
            ViewBag.PatientAMKA = new SelectList(db.Patients, "PatientAMKA", "UserId", appointment.PatientAMKA);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorAMKA = new SelectList(db.Doctors, "DoctorAMKA", "Username", appointment.DoctorAMKA);
            ViewBag.PatientAMKA = new SelectList(db.Patients, "PatientAMKA", "UserId", appointment.PatientAMKA);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,StartSlotTime,EndSlotTime,PatientAMKA,DoctorAMKA,IsAvailable")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorAMKA = new SelectList(db.Doctors, "DoctorAMKA", "Username", appointment.DoctorAMKA);
            ViewBag.PatientAMKA = new SelectList(db.Patients, "PatientAMKA", "UserId", appointment.PatientAMKA);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
