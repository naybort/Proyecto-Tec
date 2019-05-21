using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;

namespace API.Controllers
{
    public class CitaController : ApiController
    {
        // GET: api/Cita
        public IEnumerable<Pr_Citas_Consultar_Result> Get()
        {

            ICita cita = new ICita();
            return cita.getCitas();
        }

        // GET: api/Cita/5
        public ICita Get(int id)
        {
            ICita cita = new ICita();
            return cita.GetCita(id);
        }

        // POST: api/Cita
        public HttpResponseMessage Post([FromBody]ICita cita)
        {
           
    
                ICita temp = new ICita();
                temp.guardarCita(cita);
                var message = Request.CreateResponse(HttpStatusCode.Created, cita);
                
                return message;
       

            
        }

        // PUT: api/Cita/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cita/5
        public void Delete(int id)
        {
            ICita cita = new ICita();
            cita.eliminarCita(id);
        }

    

    
    }
}
