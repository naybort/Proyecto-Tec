using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaHorasConsulta.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult SeleccionarTematica()
        {
            return View();
        }
    }
}