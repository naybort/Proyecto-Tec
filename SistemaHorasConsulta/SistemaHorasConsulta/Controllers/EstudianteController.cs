using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Modelos;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Models;

namespace SistemaHorasConsulta.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult SeleccionarTematica()
        {
            @Session["Encabezado"] = "Seleccionar Temática";
            IEnumerable<Tematica> tematicas = null;
            Session["ID_USUARIO"] = 2016136466;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50013/api/Tematica");
        
                    var responseTask = client.GetAsync("tematica");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Tematica>>();
                        readTask.Wait();

                        tematicas = readTask.Result;
                    }
                    else 
                    {

                        tematicas = Enumerable.Empty<Tematica>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
           
            

            return View(tematicas);
        }
        public ActionResult SeleccionarProfesor(int? idTematica)
        {
            @Session["Encabezado"] = "Profesores";
            IEnumerable<IProfesor> profesores = null;

            using (var client = new HttpClient())
            {
                string strUrl = "http://localhost:50013/api/Tematica/" + Convert.ToString(idTematica) + "/profesores";
                client.BaseAddress = new Uri(strUrl);

                var responseTask = client.GetAsync(strUrl);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<IProfesor>>();
                    readTask.Wait();

                    profesores = readTask.Result;
                }
                else
                {

                    profesores = Enumerable.Empty<IProfesor>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }



            return View(profesores);
   

        }
        public ActionResult Calendario(int? idProfesor)
        {
            @Session["IdProfesor"]= idProfesor;
            IEnumerable<IHorario> profesores = null;

            using (var client = new HttpClient())
            {
                string strUrl = "http://localhost:50013/api/Horario/profesor/" + Convert.ToString(idProfesor);
                client.BaseAddress = new Uri(strUrl);

                var responseTask = client.GetAsync(strUrl);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<IHorario>>();
                    readTask.Wait();

                    profesores = readTask.Result;
                }
                else
                {

                    profesores = Enumerable.Empty<IHorario>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }



            return View(profesores);
        }
        public ActionResult Agenda() {
            @Session["Encabezado"] = "Agenda";
            IEnumerable<IEstudiante> citas= null;

            using (var client = new HttpClient())
            {
                string strUrl = "http://localhost:50013/api/Estudiante/" + Session["ID_USUARIO"];
                client.BaseAddress = new Uri(strUrl);

                var responseTask = client.GetAsync(strUrl);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<IEstudiante>>();
                    readTask.Wait();

                    citas = readTask.Result;
                }
                else
                {

                    citas = Enumerable.Empty<IEstudiante>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }



            return View(citas);
            
        }

        public JsonResult GetHorarios()
        {
            IEnumerable<IHorario> profesores = null;
            using (var client = new HttpClient())
            {
                string strUrl = "http://localhost:50013/api/Horario/profesor/" + Convert.ToString(Session["IdProfesor"]);
                client.BaseAddress = new Uri(strUrl);

                var responseTask = client.GetAsync(strUrl);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<IHorario>>();
                    readTask.Wait();

                    profesores = readTask.Result;
                }
                else
                {

                    profesores = Enumerable.Empty<IHorario>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }



            return new JsonResult { Data = profesores, JsonRequestBehavior = JsonRequestBehavior.AllowGet };



        }

    }
}
        
    
