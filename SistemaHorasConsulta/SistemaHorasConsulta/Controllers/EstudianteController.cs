using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Mail;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;
using System.Globalization;

namespace SistemaHorasConsulta.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult SeleccionarTematica()
        {
            NCita citaTemp = new NCita();
            
            var citaParaFeedBack = citaTemp.getCitas().Where(x => x.IdEstudiante == int.Parse(Session["CARNE"].ToString()) && x.EstadoFeedBack == false && x.Estado == "Realizada").FirstOrDefault();
            if (citaParaFeedBack == null) {
                @Session["Encabezado"] = "Seleccionar Temática";
                NTematica tematica = new NTematica();
                var listaTematicas = tematica.getTematicas();

                return View(listaTematicas);
            }
            else {
                return RedirectToAction("completarFeedBack", new { id = citaParaFeedBack.IdCita});
            }

        }
        public ActionResult completarFeedBack(int id) {
            NCita temp = new NCita();
            var cita = temp.getCitas().Where(x => x.IdCita == id).FirstOrDefault();
            return View(cita);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult completarFeedBack([Bind(Include = "IdCita,respuesta1,respuesta2,respuesta3")] FeedBack feedback)
        {
            @Session["Encabezado"] = "Evaluación de Profesor";
            if (ModelState.IsValid)
            {
                NCita temp = new NCita();
                temp.crearFeedBack(feedback);
                return RedirectToAction("SeleccionarTematica");
            }

           
            return View(feedback);
        }
        public ActionResult SeleccionarProfesor(int idTematica)
        {
            @Session["Encabezado"] = "Profesores";
            NTematica profesor = new NTematica();
            var listaProfesores = profesor.getProfesorPorTematica(idTematica);
            return View(listaProfesores);


        }
        public ActionResult Calendario(int idProfesor)
        {
            NProfesor temp = new NProfesor();
            var profe = temp.getProfesor().Where(x => x.IdProfesor == idProfesor).FirstOrDefault();
            @Session["NombreProfe"] =  profe.SegundoApellido +" "+ profe.PrimerApellido +" " + profe.Nombre ;
            @Session["IdProfesor"] = idProfesor;
  
            NHorario horario = new NHorario();
            var listaHorarios = horario.getHorarioProfesor(idProfesor);

            return View(listaHorarios);
        }
     
        public ActionResult  CitasCanceladas()
        {
            @Session["Encabezado"] = "";
            NCita cita = new NCita();
            var citas = cita.getCitas().Where(x => x.IdEstudiante == int.Parse(@Session["CARNE"].ToString()));
            return View(citas.Where(x => x.Estado == "Cancelada"));
        }
        public ActionResult CitasRealizadas()
        {
            @Session["Encabezado"] = "";
            NCita cita = new NCita();
            var citas = cita.getCitas().Where(x => x.IdEstudiante == int.Parse(@Session["CARNE"].ToString()));
            return View(citas.Where(x => x.Estado == "Realizada"));
        }
        public ActionResult CitasPendientes()
        {
            @Session["Encabezado"] = "";
            NCita cita = new NCita();
            var citas = cita.getCitas().Where(x => x.IdEstudiante == int.Parse(@Session["CARNE"].ToString()));
            return View(citas.Where(x => x.Estado == "Pendiente"));
        }

        public JsonResult GetHorarios()
        {
            NHorario horario = new NHorario();
            var listaHorarios = horario.getHorarioProfesor((int)@Session["IdProfesor"]);



            return new JsonResult { Data = listaHorarios, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult GetTematicas(List<string> id)
        {
            var idTemp = int.Parse(id[0]);
            NTematica tematica = new NTematica();
            var listaTematicas = tematica.getTematicasPorProfesor(idTemp);



            return new JsonResult { Data = listaTematicas, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult GetCitasDisponibles(List<string> Datos)
        {
           
            NCita cita = new NCita();
            var citas = cita.getCitas();
            var fechaTemp = Datos[Datos.Count-1];
            DateTime fecha = DateTime.ParseExact(fechaTemp, "d/M/yyyy", CultureInfo.InstalledUICulture);
            Datos.RemoveAt(Datos.Count-1);
            var listaCitas = citas.Where(x => x.IdEstudiante == int.Parse(Session["CARNE"].ToString()) && x.Fecha == fecha);
        
            if (listaCitas != null)
            {
                
                foreach (var i in listaCitas)
                {
                    for(var x = 0; x < Datos.Count-1; x ++)
                    {
                        if (i.HoraInicio == TimeSpan.Parse(Datos[x]))
                        {
                            Datos.RemoveAt(x);
                        }
                    }
                }
            }
        


            return new JsonResult { Data = Datos, JsonRequestBehavior = JsonRequestBehavior.AllowGet };



        }

        public ActionResult ReservarCita(List<String> Datos) {
                var resultadoAjax = true;
                NCita cita = new NCita();
            cita.IdEstudiante = int.Parse(Session["CARNE"].ToString());
                cita.IdProfesor = (int)@Session["IdProfesor"];

              
               
                DateTime fecha = DateTime.ParseExact(Datos[0], "d/M/yyyy", null);
                
                cita.Fecha = fecha;
                DateTime horaInicio = DateTime.Parse(Datos[1]);
                cita.HoraInicio = horaInicio;




            var citaTemp = cita.getCitas();
            var cantidad = citaTemp.Where(x => x.Fecha == fecha && x.IdEstudiante == int.Parse(Session["CARNE"].ToString()) && x.IdProfesor == cita.IdProfesor).Count();
            if (cantidad >= 2)
            {
                ViewBag.error = "Ha exedido el máximo de citas en este día";
                resultadoAjax = false;

            }
            else
            {
                var resultado = cita.crearCita(cita);

                if (resultado)
                {
                  

                    wsEmail.Email ws = new wsEmail.Email();
                    ws.Enviar("mcorear97@gmail.com", "", "Reservación de Cita", "La cita de consulta con el/la docente  " + Session["NombreProfe"] + " para la día " + Datos[0] + " a las " + Datos[1], true, "high", "sistemahc", "2016@ITcr");
                    ws.Enviar("jpcastillo@itcr.ac.cr", "", "Reservación de Cita", "La cita de consulta con  " + Session["NOM_USUARIO"] + ",código de carnet "+Session["CARNE"].ToString()+" para el día " + Datos[0] + " a las " + Datos[1] + " ha sido reservada", true, "high", "sistemahc", "2016@ITcr");
                }
                else
                {
                    ViewBag.Error = "Error al registrar cita.";
                }

            }

            return Json(new { boolRes = resultadoAjax });
        }
        public ActionResult EliminarCita(int IdCita) {

            NCita cita = new NCita();
            var citas = cita.getCitas().Where(x=> x.IdCita == IdCita).FirstOrDefault();
            var respuesta = cita.eliminarCita(IdCita);
            if (respuesta) {
                wsEmail.Email ws = new wsEmail.Email();
                ws.Enviar("mcorear97@gmail.com", "", "Cancelación de Cita", "El estudiante "+ Session["NOM_USUARIO"] + " canceló la cita del día " + citas.Fecha.ToShortDateString() + " a las " + citas.HoraInicio, true, "high", "sistemahc", "2016@ITcr");
            }
            return RedirectToAction("CitasCanceladas");
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Autenticacion", "Home");
        }

    

    }
}
        
    
