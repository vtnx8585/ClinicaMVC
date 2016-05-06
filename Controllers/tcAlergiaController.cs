using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaMVC.Models;
using System.Data.SqlClient;

namespace ClinicaMVC.Controllers
{
    public class tcAlergiaController : Controller
    {
        private ClinicaMedicaDataLayer db = new ClinicaMedicaDataLayer();

        // GET: tcAlergia
        public ActionResult Index()
        {
            //****EJEMPLO DE: Executing Raw SQL Queries Using Entity Framework, CON PARAMETROS PARA EVITAR SQL INJECTION******
            //****Cuando se utiliza esta metodologia el query debe regresar con los nombres de la columna igual a que esta en el modelo*****

            //List<SqlParameter> parameterList = new List<SqlParameter>();
            //parameterList.Add(new SqlParameter("@IdEstado", 2));
            //parameterList.Add(new SqlParameter("@EstadoNombre", "peditis4"));
            //SqlParameter[] parameters = parameterList.ToArray();
            //string sql = "Select id_alergia as tcAlergiaID, ale_nombre as Nombre, ale_descripcion as Descripcion, ale_fecha_creacion as FechaCreacion,id_estado as EstadoID from ClinicaMedica.dbo.tc_alergia where id_estado = @IdEstado and ale_nombre = @EstadoNombre";
            //var tcAlergias = db.tcAlergias.SqlQuery(sql, parameters);

            //*********************************************************
                        
            var tcAlergias = db.tcAlergias.Include(t => t.Estado).Where(e => e.EstadoID == 1);
            return View(tcAlergias.ToList());
        }

        // GET: tcAlergia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcAlergia tcAlergia = db.tcAlergias.Find(id);
            if (tcAlergia == null)
            {
                return HttpNotFound();
            }
            return View(tcAlergia);
        }

        // GET: tcAlergia/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            return View();
        }

        // POST: tcAlergia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tcAlergiaID,Nombre,Descripcion,EstadoID")] tcAlergia tcAlergia, bool checkbox)
        {
            if (ModelState.IsValid)
            {
                if (checkbox == true)
                {
                    db.tcAlergias.Add(tcAlergia);
                    db.SaveChanges();
                    ViewBag.Mensaje = "Alergia guardada";
                    ViewBag.CheckBox = "Activado";
                    ModelState.Clear();
                    ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcAlergia.EstadoID);
                    return View();
                }
                else if (checkbox == false)
                {
                    db.tcAlergias.Add(tcAlergia);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Alergia guardada";
                    return RedirectToAction("Index");
                }

            }
        
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcAlergia.EstadoID);
            return View(tcAlergia);
        }

        // GET: tcAlergia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcAlergia tcAlergia = db.tcAlergias.Find(id);
            if (tcAlergia == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcAlergia.EstadoID);
            return View(tcAlergia);
        }

        // POST: tcAlergia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tcAlergiaID,Nombre,Descripcion,EstadoID")] tcAlergia tcAlergia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcAlergia).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Alergia editada";
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tcAlergia.EstadoID);
            return View(tcAlergia);
        }

        // GET: tcAlergia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcAlergia tcAlergia = db.tcAlergias.Find(id);
            if (tcAlergia == null)
            {
                return HttpNotFound();
            }
            return View(tcAlergia);
        }

        // POST: tcAlergia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tcAlergia tcAlergia = db.tcAlergias.Find(id);
            tcAlergia.EstadoID = 2;
            //db.tcAlergias.Remove(tcAlergia);
            db.SaveChanges();
            TempData["Mensaje"] = "Alergia eliminada";
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
