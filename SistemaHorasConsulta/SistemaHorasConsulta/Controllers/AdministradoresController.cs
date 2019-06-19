using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;

namespace SistemaHorasConsulta.Controllers
{
    public class AdministradoresController : Controller
    {
       

        // GET: Administradores
        public ActionResult Index()
        {
            NAdministrador temp = new NAdministrador();
            return View(temp.getAdministradores());
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
        public ActionResult Create([Bind(Include = "Usuario")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                NAdministrador temp = new NAdministrador();
                temp.crearAdministrador(administrador);
         
                return RedirectToAction("Index");
            }

            return View(administrador);
        }

        // GET: Administradores/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NAdministrador temp = new NAdministrador();
            var administrador = temp.getAdministradores().Where(x => x.IdAdministrador == id).FirstOrDefault();
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdministrador,Usuario")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                NAdministrador temp = new NAdministrador();
                temp.actualizarAdministrador(administrador);
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        // GET: Administradores/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NAdministrador temp = new NAdministrador();
            var administrador = temp.getAdministradores().Where(x => x.IdAdministrador == id).FirstOrDefault();
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NAdministrador temp = new NAdministrador();
            temp.eliminarAdministrador(id);
            return RedirectToAction("Index");
        }

   
    }
}
