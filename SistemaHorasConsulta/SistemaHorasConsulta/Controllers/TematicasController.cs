using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using PagedList;
namespace SistemaHorasConsulta.Controllers
{
    public class TematicasController : Controller
    {
        private SistemaHorasConsultaEntities db = new SistemaHorasConsultaEntities();

        // GET: Tematicas
        public ActionResult Index()
        {
            return View(db.Tematicas.ToList());
        }

        // GET: Tematicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tematica tematica = db.Tematicas.Find(id);
            if (tematica == null)
            {
                return HttpNotFound();
            }
            return View(tematica);
        }

        // GET: Tematicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tematicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTematica,NombreTematica,Descripcion")] Tematica tematica)
        {
            if (ModelState.IsValid)
            {
                db.Tematicas.Add(tematica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tematica);
        }

        // GET: Tematicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tematica tematica = db.Tematicas.Find(id);
            if (tematica == null)
            {
                return HttpNotFound();
            }
            return View(tematica);
        }

        // POST: Tematicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTematica,NombreTematica,Descripcion")] Tematica tematica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tematica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tematica);
        }

        // GET: Tematicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tematica tematica = db.Tematicas.Find(id);
            if (tematica == null)
            {
                return HttpNotFound();
            }
            return View(tematica);
        }

        // POST: Tematicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tematica tematica = db.Tematicas.Find(id);
            db.Tematicas.Remove(tematica);
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
