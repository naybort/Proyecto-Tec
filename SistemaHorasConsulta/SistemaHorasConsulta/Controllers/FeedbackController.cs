using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;

namespace SistemaHorasConsulta.Controllers
{
    public class FeedbackController : Controller
    {

        // GET: Feedback
        public ActionResult Details(int id)
        {
            NCita temp = new NCita();
            var feedBack = temp.getFeedback().Where(x=> x.IdCita == id).FirstOrDefault();
        
            
            return View(feedBack);
        }

  
    }
}
