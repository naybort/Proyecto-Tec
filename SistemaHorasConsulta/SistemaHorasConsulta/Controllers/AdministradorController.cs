using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using ITCR.DATIC.SistemaHorasConsulta.Negocio;

namespace SistemaHorasConsulta.Controllers
{
    public class AdministradorController : Controller
    {
        private SistemaHorasConsultaEntities db = new SistemaHorasConsultaEntities();
        // GET: Administrador
        public ActionResult BaseDatos()
        {
            
            return View(db.Profesores.Include("Horarios").ToList());
        }
    }
}