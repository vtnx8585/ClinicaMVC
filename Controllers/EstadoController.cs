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
    public class EstadoController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: Estado
        public ActionResult Index()
        {
            return View(db.Estados.ToList());
        }

        // GET: Estado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estados.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // GET: Estado/Create        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoID,Nombre,Descripcion", Exclude ="FechaCreacion")] Estado estado, bool checkbox)
        {          
            if (ModelState.IsValid)
            {
                if (checkbox == true)
                {
                    db.Estados.Add(estado);
                    db.SaveChanges();
                    ViewBag.Mensaje = "Estado guardado";
                    ViewBag.CheckBox = "Activado";
                    ModelState.Clear();                    
                    return View();
                }
                else if (checkbox == false) {
                    db.Estados.Add(estado);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Estado guardado";
                    return RedirectToAction("Index");
                }
                
            }

            return View(estado);
        }

        // GET: Estado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estados.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: Estado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoID,Nombre,Descripcion", Exclude = "FechaCreacion")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Estado editado";
                return RedirectToAction("Index");
            }

            return View(estado);
        }

        // GET: Estado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estados.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: Estado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado estado = db.Estados.Find(id);
            db.Estados.Remove(estado);
            db.SaveChanges();
            TempData["Mensaje"] = "Estado eliminado";
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
