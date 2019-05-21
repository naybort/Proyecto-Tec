﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Mail;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;


namespace SistemaHorasConsulta.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult SeleccionarTematica()
        {
            @Session["Encabezado"] = "Seleccionar Temática";
            NTematica tematica = new NTematica();
            var listaTematicas = tematica.getTematicas();

            return View(listaTematicas);
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
            @Session["IdProfesor"]= idProfesor;
            @Session["IdEstudiante"] = 2016136466;
            NHorario horario = new NHorario();
            var listaHorarios = horario.getHorarioProfesor(idProfesor);

            return View(listaHorarios);
        }
        public ActionResult Agenda() {
            @Session["Encabezado"] = "Agenda";
            NCita cita = new NCita();
            var citas = cita.getCitas();
            var listaCitas = citas.Where(x => x.IdEstudiante == (int)@Session["IdEstudiante"]);
            return View(listaCitas);
            
        }

        public JsonResult GetHorarios()
        {
            NHorario horario = new NHorario();
            var listaHorarios = horario.getHorarioProfesor((int)@Session["IdProfesor"]);



            return new JsonResult { Data = listaHorarios, JsonRequestBehavior = JsonRequestBehavior.AllowGet };



        }
        public JsonResult GetHoras(List<String> Datos)
        {

            DateTime date = new DateTime(int.Parse(Datos[2]), int.Parse(Datos[0]), int.Parse(Datos[1]));
     
            NHorario horario = new NHorario();
            var listaHorarios = horario.getHorarioProfesor((int)@Session["IdProfesor"]);
            
            return new JsonResult { Data = listaHorarios, JsonRequestBehavior = JsonRequestBehavior.AllowGet };



        }

        public ActionResult ReservarCita(List<String> Datos) {
            
                NCita cita = new NCita();
                cita.IdEstudiante = (int)@Session["IdEstudiante"];
                cita.IdProfesor = (int)@Session["IdProfesor"];
                string fecha = Datos[0];
                cita.Fecha = fecha;
                DateTime horaInicio = DateTime.Parse(Datos[1]);
                cita.HoraInicio = horaInicio;


     
   

                var resultado = cita.crearCita(cita);

                if (resultado)
                {
                    MailMessage correo = new MailMessage();
                    correo.From = new MailAddress("sistemahc@itcr.ac.cr");
                    correo.To.Add("mcorear97@gmail.com");
                    correo.Subject = "Cita reservada";
                    correo.Body = "Se reservó una cita con el estudiante " + Session["NOM_USUARIO"] + " para la fecha " + Datos[0] + " a las " + Datos[1];

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    string cuentaCorreo = "sistemahc@itcr.ac.cr";
                    string contrasenaCorreo = "2016@ITcr";
                    smtp.Credentials = new System.Net.NetworkCredential(cuentaCorreo, contrasenaCorreo);
                    smtp.Send(correo);
                }
                else {
                    ViewBag.Error = "Error al registrar cita.";
                }
               
     

            return View();
        }
        public ActionResult EliminarCita(int IdCita) {
            NCita cita = new NCita();
            var respuesta = cita.eliminarCita(IdCita);
            return RedirectToAction("Agenda");
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Autenticacion", "Home");
        }

    }
}
        
    
