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
    public class tcGeneroController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: tcGenero
        public ActionResult Index()
        {
            var tcGeneros = db.tcGeneros.Include(t => t.Estado).Where(e => e.EstadoID == 1);
            return View(tcGeneros.ToList());
        }

        // GET: tcGenero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcGenero tcGenero = db.tcGeneros.Find(id);
            if (tcGenero == null)
            {
                return HttpNotFound();
            }
            return View(tcGenero);
        }

        // GET: tcGenero/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            return View();
        }

        // POST: tcGenero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tcGeneroID,Nombre,EstadoID")] tcGenero tcGenero,bool checkbox)
        {
            if (ModelState.IsValid)
            {
                if (checkbox == true)
                {
                    db.tcGeneros.Add(tcGenero);
                    db.SaveChanges();
                    ViewBag.Mensaje = "Genero guardado";
                    ViewBag.CheckBox = "Activado";
                    ModelState.Clear();
                    ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcGenero.EstadoID);
                    return View();
                }
                else if (checkbox == false)
                {
                    db.tcGeneros.Add(tcGenero);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Genero guardado";
                    return RedirectToAction("Index");
                }

            }

            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcGenero.EstadoID);
            return View(tcGenero);
        }

        // GET: tcGenero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcGenero tcGenero = db.tcGeneros.Find(id);
            if (tcGenero == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcGenero.EstadoID);
            return View(tcGenero);
        }

        // POST: tcGenero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tcGeneroID,Nombre,EstadoID")] tcGenero tcGenero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcGenero).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Genero editado";
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcGenero.EstadoID);
            return View(tcGenero);
        }

        // GET: tcGenero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcGenero tcGenero = db.tcGeneros.Find(id);
            if (tcGenero == null)
            {
                return HttpNotFound();
            }
            return View(tcGenero);
        }

        // POST: tcGenero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tcGenero tcGenero = db.tcGeneros.Find(id);
            tcGenero.EstadoID = 2;
            db.SaveChanges();
            TempData["Mensaje"] = "Genero eliminada";            
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
