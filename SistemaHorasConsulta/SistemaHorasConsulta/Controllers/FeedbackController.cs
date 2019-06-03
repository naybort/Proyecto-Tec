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
    public class FeedbackController : Controller
    {
        private SistemaHorasConsultaEntities db = new SistemaHorasConsultaEntities();

        // GET: Feedback
        public ActionResult Index()
        {
            var feedbackXCitas = db.FeedbackXCitas.Include(f => f.Cita);
            return View(feedbackXCitas.ToList());
        }

        // GET: Feedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackXCita feedbackXCita = db.FeedbackXCitas.Find(id);
            if (feedbackXCita == null)
            {
                return HttpNotFound();
            }
            return View(feedbackXCita);
        }

        // GET: Feedback/Create
        public ActionResult Create()
        {
            ViewBag.IdCita = new SelectList(db.Citas, "IdCita", "Estado");
            return View();
        }

        // POST: Feedback/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCita,Estado,RespuestaPregunta1,RespuestaPregunta2,RespuestaPregunta3,ComentarioAdicional")] FeedbackXCita feedbackXCita)
        {
            if (ModelState.IsValid)
            {
                db.FeedbackXCitas.Add(feedbackXCita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCita = new SelectList(db.Citas, "IdCita", "Estado", feedbackXCita.IdCita);
            return View(feedbackXCita);
        }

        // GET: Feedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackXCita feedbackXCita = db.FeedbackXCitas.Find(id);
            if (feedbackXCita == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCita = new SelectList(db.Citas, "IdCita", "Estado", feedbackXCita.IdCita);
            return View(feedbackXCita);
        }

        // POST: Feedback/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCita,Estado,RespuestaPregunta1,RespuestaPregunta2,RespuestaPregunta3,ComentarioAdicional")] FeedbackXCita feedbackXCita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbackXCita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCita = new SelectList(db.Citas, "IdCita", "Estado", feedbackXCita.IdCita);
            return View(feedbackXCita);
        }

        // GET: Feedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackXCita feedbackXCita = db.FeedbackXCitas.Find(id);
            if (feedbackXCita == null)
            {
                return HttpNotFound();
            }
            return View(feedbackXCita);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedbackXCita feedbackXCita = db.FeedbackXCitas.Find(id);
            db.FeedbackXCitas.Remove(feedbackXCita);
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
