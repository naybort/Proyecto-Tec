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
    public class CitasController : Controller
    {
        

        // GET: Citas
        public ActionResult Index()
        {
            NCita cita = new NCita();
            var citas = cita.getCitas();
            return View(citas.Where(x => x.Estado == "Cancelada"));
        }
        public ActionResult CitasRealizadas()
        {
            NCita cita = new NCita();
            var citas = cita.getCitas();
            return View(citas.Where(x => x.Estado == "Realizada"));
        }
        public ActionResult CitasPendientes()
        {
            NCita cita = new NCita();
            var citas = cita.getCitas();
            return View(citas.Where(x => x.Estado == "Pendiente"));
        }

    }
}
