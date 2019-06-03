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
    public class AdministradoresController : Controller
    {
        private SistemaHorasConsultaEntities db = new SistemaHorasConsultaEntities();

        // GET: Administradores
        public ActionResult Index()
        {
            return View(db.Administradores.ToList());
        }

        // GET: Administradores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administradore administradore = db.Administradores.Find(id);
            if (administradore == null)
            {
                return HttpNotFound();
            }
            return View(administradore);
        }

        // GET: Administradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usuario")] Administradore administradore)
        {
            if (ModelState.IsValid)
            {
                db.Administradores.Add(administradore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administradore);
        }

        // GET: Administradores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administradore administradore = db.Administradores.Find(id);
            if (administradore == null)
            {
                return HttpNotFound();
            }
            return View(administradore);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usuario")] Administradore administradore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administradore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administradore);
        }

        // GET: Administradores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administradore administradore = db.Administradores.Find(id);
            if (administradore == null)
            {
                return HttpNotFound();
            }
            return View(administradore);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Administradore administradore = db.Administradores.Find(id);
            db.Administradores.Remove(administradore);
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
