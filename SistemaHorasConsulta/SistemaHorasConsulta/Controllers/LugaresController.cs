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
    public class LugaresController : Controller
    {
        private SistemaHorasConsultaEntities db = new SistemaHorasConsultaEntities();

        // GET: Lugares
        public ActionResult Index()
        {
            return View(db.Lugares.ToList());
        }

        // GET: Lugares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugare lugare = db.Lugares.Find(id);
            if (lugare == null)
            {
                return HttpNotFound();
            }
            return View(lugare);
        }

        // GET: Lugares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lugares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLugar,Nombre")] Lugare lugare)
        {
            if (ModelState.IsValid)
            {
                db.Lugares.Add(lugare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lugare);
        }

        // GET: Lugares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugare lugare = db.Lugares.Find(id);
            if (lugare == null)
            {
                return HttpNotFound();
            }
            return View(lugare);
        }

        // POST: Lugares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLugar,Nombre")] Lugare lugare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lugare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lugare);
        }

        // GET: Lugares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugare lugare = db.Lugares.Find(id);
            if (lugare == null)
            {
                return HttpNotFound();
            }
            return View(lugare);
        }

        // POST: Lugares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lugare lugare = db.Lugares.Find(id);
            db.Lugares.Remove(lugare);
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
