using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;

namespace SistemaHorasConsulta.Controllers
{
    public class AdministradorController : Controller
    {
       
        // GET: Administrador
        public ActionResult BaseDatos()
        {
            NProfesor temp = new NProfesor();
            var profes = temp.getProfesor();
            return View(profes);

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
            Session["IdProfeTemp"] = id;
                NTematica tematicaTemp = new NTematica();
            var tematicas = tematicaTemp.getTematicas();
            var horarioProfesor = tematicaTemp.getTematicasPorProfesor(id);
            var c = tematicaTemp.getTematicas();
            
            foreach (var i in c)
            {
                foreach (var x in horarioProfesor)
                {
                    if (i.IdTematica == x.IdTematica)
                    {
                        tematicas.Remove(tematicas.Where(temp => temp.IdTematica == i.IdTematica).FirstOrDefault());
                    }
                }
            }
            return View(tematicas);

        }
        public ActionResult EliminarTematicaProfesor(int id)
        {
            NTematica horario = new NTematica();
            horario.EliminarHorarioProfesor(id, (int)Session["IdProfeTemp"]);
            return RedirectToAction("Details", "Profesores", new { id = (int)Session["IdProfeTemp"] });
        }
        public ActionResult TematicaProfesor(List<String> Datos)
        {
            NTematica tematica = new NTematica();
            tematica.crearTematicaPorProfesor(Datos[0], int.Parse(Datos[1]), (int)Session["IdProfeTemp"]);
            Session["IdTemp"] = int.Parse(Datos[1]);
            var res = new { Success = "True" };
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AgregarEspecialidades(int id) {
            NTematica tematicaTemp = new NTematica();
            var tematicas = tematicaTemp.getTematicas().Where(x => x.IdTematica == id).FirstOrDefault();
            return View(tematicas);
        }
    }
}