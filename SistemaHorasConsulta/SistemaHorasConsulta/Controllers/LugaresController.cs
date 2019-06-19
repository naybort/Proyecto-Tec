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
    public class LugaresController : Controller
    {
       

        // GET: Lugares
        public ActionResult Index()
        {
            NLugares lugares = new NLugares();
            return View(lugares.getLugares().ToList());
        }

        // GET: Lugares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NLugares lugares = new NLugares();
            Lugares temp = lugares.getLugares().Where(x => x.IdLugar == id).FirstOrDefault();
         
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
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
        public ActionResult Create([Bind(Include = "Nombre")] Lugares lugar)
        {
            if (ModelState.IsValid)
            {

                NLugares temp = new NLugares();
                temp.crearLugar(lugar);
         
                return RedirectToAction("Index");
            }

            return View(lugar);
        }

        // GET: Lugares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NLugares temp = new NLugares();
            var lugar = temp.getLugares().Where(x => x.IdLugar == id).FirstOrDefault();
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLugar,Nombre")] Lugares lugar)
        {
            if (ModelState.IsValid)
            {
                NLugares temp = new NLugares();
                temp.actualizarLugar(lugar);
                return RedirectToAction("Index");
            }
            return View(lugar);
        }

        // GET: Lugares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NLugares temp = new NLugares();
            var lugar = temp.getLugares().Where(x => x.IdLugar == id).FirstOrDefault();
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NLugares temp = new NLugares();
            temp.eliminarLugar(id);
            return RedirectToAction("Index");
        }

      
    }
}
