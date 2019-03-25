using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Consultas.Models;

namespace Sistema_Consultas.Controllers
{
    public class StudentController : Controller
    {
        SC_Entities db = new SC_Entities();
        public ActionResult Thematics(string thematic_name)
        {
            var thematics = db.Thematics.Where(t => t.name.Contains(thematic_name) || thematic_name == null);
            return View(thematics.ToList());
        }

        public ActionResult Login()
        {

            return View();
        }
    }
}