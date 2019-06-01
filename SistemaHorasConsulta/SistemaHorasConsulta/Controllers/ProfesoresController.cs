using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;

namespace SistemaHorasConsulta.Controllers
{
    public class ProfesoresController : Controller
    {
        private SistemaHorasConsultaEntities db = new SistemaHorasConsultaEntities();

        // GET: Profesores
        public ActionResult Index()
        {
            var profesores = db.Profesores.Include(p => p.Lugare);
            return View(profesores.ToList());
        }

        // GET: Profesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesore profesore = db.Profesores.Find(id);
            if (profesore == null)
            {
                return HttpNotFound();
            }
            return View(profesore);
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            ViewBag.IdLugar = new SelectList(db.Lugares, "IdLugar", "Nombre");
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProfesor,Nombre,PrimerApellido,SegundoApellido,Usuario,Contrasena,CorreoElectronico,Especialidades,IdLugar,Foto")] Profesore profesore)
        {
            if (ModelState.IsValid)
            {
                db.Profesores.Add(profesore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLugar = new SelectList(db.Lugares, "IdLugar", "Nombre", profesore.IdLugar);
            return View(profesore);
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesore profesore = db.Profesores.Find(id);
            if (profesore == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLugar = new SelectList(db.Lugares, "IdLugar", "Nombre", profesore.IdLugar);
            return View(profesore);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProfesor,Nombre,PrimerApellido,SegundoApellido,Usuario,Contrasena,CorreoElectronico,Especialidades,IdLugar,Foto")] Profesore profesore)
        {
            if (ModelState.IsValid)
            {
                profesore.Usuario = null;
                profesore.Contrasena = null;
                profesore.Foto = null;
                db.Entry(profesore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLugar = new SelectList(db.Lugares, "IdLugar", "Nombre", profesore.IdLugar);
            return View(profesore);
        }

        // GET: Profesores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesore profesore = db.Profesores.Find(id);
            if (profesore == null)
            {
                return HttpNotFound();
            }
            return View(profesore);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesore profesore = db.Profesores.Find(id);
            db.Profesores.Remove(profesore);
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
