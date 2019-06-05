using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;

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
        public ActionResult AsociarHorario(int id) {
            NHorario horarioTemp = new NHorario();
            var horarios = horarioTemp.getHorarios();
            var horarioProfesor = horarioTemp.getHorarioProfesor(id);
            var c = horarioTemp.getHorarios();
            List<AHorario> listaHorario = new List<AHorario>();
            foreach (var i in c) {
                foreach (var x in horarioProfesor) {
                    if (i.IdHorario == x.IdHorario) {
                        horarios.Remove(horarios.Where(temp => temp.IdHorario == i.IdHorario).FirstOrDefault());
                    }
                }
            }
            return View(horarios);


        }
        public ActionResult HorarioProfesor(int id) {
            NHorario horario = new NHorario();
            horario.crearHorarioProfesor(id, (int)Session["IdProfeTemp"]);
            return RedirectToAction("AsociarHorario", new { id = (int)Session["IdProfeTemp"] }); 
        }
        public ActionResult EliminarHorarioProfesor(int id) {
            NHorario horario = new NHorario();
            horario.EliminarHorarioProfesor(id, (int)Session["IdProfeTemp"]);
            return RedirectToAction("Details","Profesores", new { id = (int)Session["IdProfeTemp"] });
        }

        public ActionResult AsociarTematica(int id)
        {
            NTematica tematicaTemp = new NTematica();
            var tematicas = tematicaTemp.getTematicas();
      
            return View(tematicas);

        }
        public ActionResult TematicaProfesor(int id)
        {
            
            return RedirectToAction("AsociarHorario", new { id = (int)Session["IdProfeTemp"] });
        }

        public ActionResult AgregarEspecialidades(int id) {
            NTematica tematicaTemp = new NTematica();
            var tematicas = tematicaTemp.getTematicas().Where(x => x.IdTematica == id).FirstOrDefault();
            return View(tematicas);
        }
    }
}