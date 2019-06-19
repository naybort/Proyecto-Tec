using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;
namespace SistemaHorasConsulta.Controllers
{
    public class TematicasController : Controller
    {
        

        // GET: Tematicas
        public ActionResult Index()
        {
            NTematica temp = new NTematica();
            return View(temp.getTematicas());
        }

        // GET: Tematicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NTematica temp = new NTematica();
            var tematica = temp.getTematicas().Where(x => x.IdTematica == id).FirstOrDefault();
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
        public ActionResult Create([Bind(Include = "NombreTematica,Descripcion")] getTematicas tematica)
        {
            if (ModelState.IsValid)
            {
                NTematica temp = new NTematica();
                temp.crearTematica(tematica);
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
            NTematica temp = new NTematica();
            var tematica = temp.getTematicas().Where(x => x.IdTematica == id).FirstOrDefault();
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
        public ActionResult Edit([Bind(Include = "IdTematica,NombreTematica,Descripcion")] getTematicas tematica)
        {
            if (ModelState.IsValid)
            {
                NTematica temp = new NTematica();
                temp.actualizarTematica(tematica);
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
            NTematica temp = new NTematica();
            var tematica = temp.getTematicas().Where(x => x.IdTematica == id).FirstOrDefault();
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
            NTematica temp = new NTematica();
            temp.eliminarTematica(id);
            return RedirectToAction("Index");
        }

    
    }
}
