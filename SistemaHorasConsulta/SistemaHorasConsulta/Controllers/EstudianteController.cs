using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Modelos;
using System.Net.Http.Headers;
using System.Threading.Tasks;
namespace SistemaHorasConsulta.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult SeleccionarTematica()
        {
            
                IEnumerable<Tematica> tematicas = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50013/api/Tematica");
                    //HTTP GET
                    var responseTask = client.GetAsync("tematica");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Tematica>>();
                        readTask.Wait();

                        tematicas = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        tematicas = Enumerable.Empty<Tematica>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
           
            

            return View(tematicas);
        }
        public ActionResult SeleccionarProfesor()
        {
            return View();
        }
        public ActionResult Calendario()
        {
            return View();
        }
    }
}
        
    
