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
    public class tcProfesionController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: tcProfesion
        public ActionResult Index()
        {
            var tcProfesiones = db.tcProfesiones.Include(t => t.Estado).Where(e => e.EstadoID == 1);
            return View(tcProfesiones.ToList());
        }

        // GET: tcProfesion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcProfesion tcProfesion = db.tcProfesiones.Find(id);
            if (tcProfesion == null)
            {
                return HttpNotFound();
            }
            return View(tcProfesion);
        }

        // GET: tcProfesion/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            return View();
        }

        // POST: tcProfesion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tcProfesionID,Nombre,Descripcion,EstadoID")] tcProfesion tcProfesion, bool checkbox)
        {
            if (ModelState.IsValid)
            {
                if (checkbox == true)
                {
                    db.tcProfesiones.Add(tcProfesion);
                    db.SaveChanges();
                    ViewBag.Mensaje = "Profesion guardada";
                    ViewBag.CheckBox = "Activado";
                    ModelState.Clear();
                    ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcProfesion.EstadoID);
                    return View();
                }
                else if (checkbox == false)
                {
                    db.tcProfesiones.Add(tcProfesion);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Profesion guardada";
                    return RedirectToAction("Index");
                }

            }          

            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcProfesion.EstadoID);
            return View(tcProfesion);
        }

        // GET: tcProfesion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcProfesion tcProfesion = db.tcProfesiones.Find(id);
            if (tcProfesion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcProfesion.EstadoID);
            return View(tcProfesion);
        }

        // POST: tcProfesion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tcProfesionID,Nombre,Descripcion,EstadoID")] tcProfesion tcProfesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcProfesion).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Profesion editada";
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcProfesion.EstadoID);
            return View(tcProfesion);
        }

        // GET: tcProfesion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcProfesion tcProfesion = db.tcProfesiones.Find(id);
            if (tcProfesion == null)
            {
                return HttpNotFound();
            }
            return View(tcProfesion);
        }

        // POST: tcProfesion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tcProfesion tcProfesion = db.tcProfesiones.Find(id);
            tcProfesion.EstadoID = 2;            
            db.SaveChanges();
            TempData["Mensaje"] = "Profesion eliminada";
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
