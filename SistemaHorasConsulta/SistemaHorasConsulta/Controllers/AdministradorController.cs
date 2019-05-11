using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using API.Models;
using Modelos;

namespace SistemaHorasConsulta.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Profesores()
        {
            @Session["Encabezado"] = "Seleccionar Temática";
            IEnumerable<Profesor> profesores = null;
            Session["ID_USUARIO"] = 2016136466;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50013/api/Profesor");

                var responseTask = client.GetAsync("profesor");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Profesor>>();
                    readTask.Wait();

                    profesores = readTask.Result;
                }
                else
                {

                    profesores = Enumerable.Empty<Profesor>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }



            return View(profesores);
        }
    }
}