using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ITCR.DATIC.SistemaHorasConsulta.Negocio;

namespace SistemaHorasConsulta.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Profesores()
        {
            @Session["Encabezado"] = "Seleccionar Temática";

            //IEnumerable<Profesor> profesores = null;
            Session["ID_USUARIO"] = 2016136466;

            return View();
        }
    }
}