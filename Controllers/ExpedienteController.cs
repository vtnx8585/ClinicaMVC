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
    public class ExpedienteController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: Expediente
        public ActionResult Index()
        {
            var expedientes = db.Expedientes.Include(e => e.Paciente);
            return View(expedientes.ToList());
        }

        // GET: Expediente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.Expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // GET: Expediente/Create
        public ActionResult Create()
        {
            ViewBag.ExpedienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre");
            return View();
        }

        // POST: Expediente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpedienteID,PacienteID,FotoPath", Exclude = "FechaCreacion")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                db.Expedientes.Add(expediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpedienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", expediente.ExpedienteID);
            return View(expediente);
        }

        // GET: Expediente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.Expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpedienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", expediente.ExpedienteID);
            return View(expediente);
        }

        // POST: Expediente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpedienteID,PacienteID,FotoPath,FechaCreacion")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpedienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", expediente.ExpedienteID);
            return View(expediente);
        }

        // GET: Expediente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.Expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // POST: Expediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expediente expediente = db.Expedientes.Find(id);
            db.Expedientes.Remove(expediente);
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
