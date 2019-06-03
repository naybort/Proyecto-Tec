using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;
namespace SistemaHorasConsulta.Controllers
{
    public class ProfesoresController : Controller
    {
        private SistemaHorasConsultaEntities db = new SistemaHorasConsultaEntities();

        // GET: Profesores
        public ActionResult Index()
        {
            NProfesor lista = new NProfesor();

            return View(lista.getProfesor().ToList());
        }

        // GET: Profesores/Details/5
        public ActionResult Details(int id)
        {

            NProfesor profesores = new NProfesor();
            var profesor = profesores.getProfesor().ToList().Where(x => x.IdProfesor == id).FirstOrDefault();
            Session["IdProfeTemp"] = profesor.IdProfesor;
            Session["NombreProfeTemp"] = profesor.NombreProfesor + " " + profesor.PrimerApellido + " " + profesor.SegundoApellido;
            return View(profesor);
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
