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
    public class tcMedicamentoController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: tcMedicamento
        public ActionResult Index()
        {
            var tcMedicamentos = db.tcMedicamentos.Include(t => t.Estado).Include(t => t.tcUnidadMedida).Where(e => e.EstadoID == 1);
            return View(tcMedicamentos.ToList());
        }

        // GET: tcMedicamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcMedicamento tcMedicamento = db.tcMedicamentos.Find(id);
            if (tcMedicamento == null)
            {
                return HttpNotFound();
            }
            return View(tcMedicamento);
        }

        // GET: tcMedicamento/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            ViewBag.tcUnidadMedidaID = new SelectList(db.tcUnidadMedidas, "tcUnidadMedidaID", "Nombre");
            return View();
        }

        // POST: tcMedicamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tcMedicamentoID,Nombre,Descripcion,Presentacion,Medida,tcUnidadMedidaID,AlertaMinimo,EstadoID")] tcMedicamento tcMedicamento, bool checkbox)
        {
            if (ModelState.IsValid)
            {
                if (checkbox == true)
                {
                    db.tcMedicamentos.Add(tcMedicamento);
                    db.SaveChanges();
                    ViewBag.Mensaje = "Medicamento guardado";
                    ViewBag.CheckBox = "Activado";
                    ModelState.Clear();
                    ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcMedicamento.EstadoID);
                    ViewBag.tcUnidadMedidaID = new SelectList(db.tcUnidadMedidas, "tcUnidadMedidaID", "Nombre", tcMedicamento.tcUnidadMedidaID);
                    return View();
                }
                else if (checkbox == false)
                {
                    db.tcMedicamentos.Add(tcMedicamento);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Medicamento guardado";
                    return RedirectToAction("Index");
                }

            }
            
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcMedicamento.EstadoID);
            ViewBag.tcUnidadMedidaID = new SelectList(db.tcUnidadMedidas, "tcUnidadMedidaID", "Nombre", tcMedicamento.tcUnidadMedidaID);
            return View(tcMedicamento);
        }

        // GET: tcMedicamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcMedicamento tcMedicamento = db.tcMedicamentos.Find(id);
            if (tcMedicamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcMedicamento.EstadoID);
            ViewBag.tcUnidadMedidaID = new SelectList(db.tcUnidadMedidas, "tcUnidadMedidaID", "Nombre", tcMedicamento.tcUnidadMedidaID);
            return View(tcMedicamento);
        }

        // POST: tcMedicamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tcMedicamentoID,Nombre,Descripcion,Presentacion,Medida,tcUnidadMedidaID,AlertaMinimo,EstadoID")] tcMedicamento tcMedicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcMedicamento).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Medicamento editado";
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcMedicamento.EstadoID);
            ViewBag.tcUnidadMedidaID = new SelectList(db.tcUnidadMedidas, "tcUnidadMedidaID", "Nombre", tcMedicamento.tcUnidadMedidaID);
            return View(tcMedicamento);
        }

        // GET: tcMedicamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcMedicamento tcMedicamento = db.tcMedicamentos.Find(id);
            if (tcMedicamento == null)
            {
                return HttpNotFound();
            }
            return View(tcMedicamento);
        }

        // POST: tcMedicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tcMedicamento tcMedicamento = db.tcMedicamentos.Find(id);
            tcMedicamento.EstadoID = 2;            
            db.SaveChanges();
            TempData["Mensaje"] = "Medicamento eliminado";
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
