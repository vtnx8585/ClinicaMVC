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
    public class tcUnidadMedidController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: tcUnidadMedid
        public ActionResult Index()
        {
            var tcUnidadMedidas = db.tcUnidadMedidas.Include(t => t.Estado).Where(e => e.EstadoID == 1);
            return View(tcUnidadMedidas.ToList());
        }

        // GET: tcUnidadMedid/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcUnidadMedida tcUnidadMedida = db.tcUnidadMedidas.Find(id);
            if (tcUnidadMedida == null)
            {
                return HttpNotFound();
            }
            return View(tcUnidadMedida);
        }

        // GET: tcUnidadMedid/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            return View();
        }

        // POST: tcUnidadMedid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tcUnidadMedidaID,Nombre,Descripcion,EstadoID")] tcUnidadMedida tcUnidadMedida, bool checkbox)
        {
            if (ModelState.IsValid)
            {
                if (checkbox == true)
                {
                    db.tcUnidadMedidas.Add(tcUnidadMedida);
                    db.SaveChanges();
                    ViewBag.Mensaje = "Unidad de Medida guardada";
                    ViewBag.CheckBox = "Activado";
                    ModelState.Clear();
                    ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcUnidadMedida.EstadoID);
                    return View();
                }
                else if (checkbox == false)
                {
                    db.tcUnidadMedidas.Add(tcUnidadMedida);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Unidad de Medida guardada";
                    return RedirectToAction("Index");
                }

            }

            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcUnidadMedida.EstadoID);
            return View(tcUnidadMedida);
        }

        // GET: tcUnidadMedid/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcUnidadMedida tcUnidadMedida = db.tcUnidadMedidas.Find(id);
            if (tcUnidadMedida == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcUnidadMedida.EstadoID);
            return View(tcUnidadMedida);
        }

        // POST: tcUnidadMedid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tcUnidadMedidaID,Nombre,Descripcion,EstadoID")] tcUnidadMedida tcUnidadMedida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcUnidadMedida).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Unidad de Medida editada";
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcUnidadMedida.EstadoID);
            return View(tcUnidadMedida);
        }

        // GET: tcUnidadMedid/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcUnidadMedida tcUnidadMedida = db.tcUnidadMedidas.Find(id);
            if (tcUnidadMedida == null)
            {
                return HttpNotFound();
            }
            return View(tcUnidadMedida);
        }

        // POST: tcUnidadMedid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tcUnidadMedida tcUnidadMedida = db.tcUnidadMedidas.Find(id);
            tcUnidadMedida.EstadoID = 2;
            db.SaveChanges();
            TempData["Mensaje"] = "Unidad de Medida eliminada";
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
