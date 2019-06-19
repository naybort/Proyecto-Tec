using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaHorasConsulta.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Index()
        {
            Session["IdProfesor"] = 12;
            NCita cita = new NCita();
            var citas = cita.getCitas();
            return View(citas.Where(x => x.Estado == "Cancelada" && x.IdProfesor == (int)Session["IdProfesor"]));
        }
        public ActionResult CitasRealizadas()
        {
            Session["IdProfesor"] = 12;
            NCita cita = new NCita();
            var citas = cita.getCitas();
            return View(citas.Where(x => x.Estado == "Realizada" && x.IdProfesor == (int)Session["IdProfesor"]));
        }
        public ActionResult CitasPendientes()
        {
            Session["IdProfesor"] = 12;
            NCita cita = new NCita();
            var citas = cita.getCitas();
            return View(citas.Where(x => x.Estado == "Pendiente" && x.IdProfesor == (int)Session["IdProfesor"]));
        }
        public ActionResult citaRealizada(int id)
        {
            NCita temp = new NCita();
            
            temp.citaRealizada(id);
            return RedirectToAction("CitasRealizadas");
            

        }
        public ActionResult EliminarCita(int IdCita)
        {

            NCita cita = new NCita();
            var citas = cita.getCitas().Where(x => x.IdCita == IdCita).FirstOrDefault();
            var respuesta = cita.eliminarCita(IdCita);
            if (respuesta)
            {
                wsEmail.Email ws = new wsEmail.Email();
                ws.Enviar(citas.CorreoEstudiante, "", "Cancelación de Cita de Consulta", "Por este medio se le informa que la cita de consulta para el día "+ citas.Fecha.ToShortDateString()+ " a las " + citas.HoraInicio +" ha sido cancelada por el/la docente" + Session["NOM_USUARIO"], true, "high", "sistemahc", "2016@ITcr");
            }
            return RedirectToAction("Index");
        }
    }
}