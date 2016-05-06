using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaMVC.Models;

namespace ClinicaMVC.Controllers
{
    public class PacienteController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: Paciente
        public ActionResult Index()
        {
            var pacientes = db.Pacientes.Include(p => p.Estado).Include(p => p.Expediente);
            return View(pacientes.ToList());
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            ViewBag.PacienteID = new SelectList(db.Expedientes, "ExpedienteID", "FotoPath");
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PacienteID,Nombre,Apellido,FechaNacimiento,TelefonoCasa,TelefonoCel1,TelefonoCel2,TelefonoEmergencia,TipoSangre,Estatura,FechaCreacion,Direccion,NIT,Genero,Profesion,EstadoID")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", paciente.EstadoID);
            ViewBag.PacienteID = new SelectList(db.Expedientes, "ExpedienteID", "FotoPath", paciente.PacienteID);
            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", paciente.EstadoID);
            ViewBag.PacienteID = new SelectList(db.Expedientes, "ExpedienteID", "FotoPath", paciente.PacienteID);
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacienteID,Nombre,Apellido,FechaNacimiento,TelefonoCasa,TelefonoCel1,TelefonoCel2,TelefonoEmergencia,TipoSangre,Estatura,FechaCreacion,Direccion,NIT,Genero,Profesion,EstadoID")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", paciente.EstadoID);
            ViewBag.PacienteID = new SelectList(db.Expedientes, "ExpedienteID", "FotoPath", paciente.PacienteID);
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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
