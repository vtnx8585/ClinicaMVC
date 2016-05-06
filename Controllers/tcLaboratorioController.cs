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
    public class tcLaboratorioController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: tcLaboratorio
        public ActionResult Index()
        {
            var tcLaboratorios = db.tcLaboratorios.Include(t => t.Estado).Where(e => e.EstadoID == 1);
            return View(tcLaboratorios.ToList());
        }

        // GET: tcLaboratorio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcLaboratorio tcLaboratorio = db.tcLaboratorios.Find(id);
            if (tcLaboratorio == null)
            {
                return HttpNotFound();
            }
            return View(tcLaboratorio);
        }

        // GET: tcLaboratorio/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            return View();
        }

        // POST: tcLaboratorio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tcLaboratorioID,Nombre,Descripcion,EstadoID")] tcLaboratorio tcLaboratorio, bool checkbox)
        {
            if (ModelState.IsValid)
            {
                if (checkbox == true)
                {
                    db.tcLaboratorios.Add(tcLaboratorio);
                    db.SaveChanges();
                    ViewBag.Mensaje = "Laboratorio guardado";
                    ViewBag.CheckBox = "Activado";
                    ModelState.Clear();
                    ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcLaboratorio.EstadoID);
                    return View();
                }
                else if (checkbox == false)
                {
                    db.tcLaboratorios.Add(tcLaboratorio);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Laboratorio guardado";
                    return RedirectToAction("Index");
                }

            }

            if (ModelState.IsValid)
            {
                db.tcLaboratorios.Add(tcLaboratorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcLaboratorio.EstadoID);
            return View(tcLaboratorio);
        }

        // GET: tcLaboratorio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcLaboratorio tcLaboratorio = db.tcLaboratorios.Find(id);
            if (tcLaboratorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcLaboratorio.EstadoID);
            return View(tcLaboratorio);
        }

        // POST: tcLaboratorio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tcLaboratorioID,Nombre,Descripcion,EstadoID")] tcLaboratorio tcLaboratorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcLaboratorio).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Laboratorio editado";
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcLaboratorio.EstadoID);
            return View(tcLaboratorio);
        }

        // GET: tcLaboratorio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcLaboratorio tcLaboratorio = db.tcLaboratorios.Find(id);
            if (tcLaboratorio == null)
            {
                return HttpNotFound();
            }
            return View(tcLaboratorio);
        }

        // POST: tcLaboratorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tcLaboratorio tcLaboratorio = db.tcLaboratorios.Find(id);
            tcLaboratorio.EstadoID = 2;
            db.SaveChanges();
            TempData["Mensaje"] = "Laboratorio eliminado";
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
