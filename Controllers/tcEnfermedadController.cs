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
    public class tcEnfermedadController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: tcEnfermedad
        public ActionResult Index()
        {
            var tcEnfermedades = db.tcEnfermedades.Include(t => t.Estado).Where(e => e.EstadoID == 1);
            return View(tcEnfermedades.ToList());
        }

        // GET: tcEnfermedad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcEnfermedad tcEnfermedad = db.tcEnfermedades.Find(id);
            if (tcEnfermedad == null)
            {
                return HttpNotFound();
            }
            return View(tcEnfermedad);
        }

        // GET: tcEnfermedad/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");            
            return View();
        }

        // POST: tcEnfermedad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tcEnfermedadID,Nombre,Descripcion,EstadoID")] tcEnfermedad tcEnfermedad,bool checkbox)
        {
            if (ModelState.IsValid)
            {
                if (checkbox == true)
                {
                    db.tcEnfermedades.Add(tcEnfermedad);
                    db.SaveChanges();
                    ViewBag.Mensaje = "Enfermedad guardada";
                    ViewBag.CheckBox = "Activado";
                    ModelState.Clear();
                    ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcEnfermedad.EstadoID);
                    return View();
                }
                else if (checkbox == false)
                {
                    db.tcEnfermedades.Add(tcEnfermedad);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Enfermedad guardada";
                    return RedirectToAction("Index");
                }

            }

            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcEnfermedad.EstadoID);
            return View(tcEnfermedad);
        }

        // GET: tcEnfermedad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcEnfermedad tcEnfermedad = db.tcEnfermedades.Find(id);
            if (tcEnfermedad == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcEnfermedad.EstadoID);
            return View(tcEnfermedad);
        }

        // POST: tcEnfermedad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tcEnfermedadID,Nombre,Descripcion,EstadoID")] tcEnfermedad tcEnfermedad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcEnfermedad).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Enfermedad editada";
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcEnfermedad.EstadoID);
            return View(tcEnfermedad);
        }

        // GET: tcEnfermedad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcEnfermedad tcEnfermedad = db.tcEnfermedades.Find(id);
            if (tcEnfermedad == null)
            {
                return HttpNotFound();
            }
            return View(tcEnfermedad);
        }

        // POST: tcEnfermedad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tcEnfermedad tcEnfermedad = db.tcEnfermedades.Find(id);
            tcEnfermedad.EstadoID = 2;            
            db.SaveChanges();
            TempData["Mensaje"] = "Enfermedad eliminada";
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
