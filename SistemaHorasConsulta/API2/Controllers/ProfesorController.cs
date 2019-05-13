using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class ProfesorController : ApiController
    {
        [Route("api/Profesor/{idProfesor:int}/citas")]
        [ResponseType(typeof(IEnumerable<IProfesor>))]
        public IEnumerable<int> getCitasProfesor(int idProfesor)
        {
            IProfesor profesor = new IProfesor();
            return profesor.getCitasProfesor(idProfesor);
        }

        // GET: api/Profesor
        public IEnumerable<IProfesor> Get()
        {
            IProfesor profesor = new IProfesor();
            return profesor.getProfesores();
        }

        // GET: api/Profesor/5
        public IProfesor Get(int id)
        {
            IProfesor profesor = new IProfesor();
            return profesor.getProfesor(id);
        }

        // POST: api/Profesor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profesor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profesor/5
        public void Delete(int id)
        {
        }
    }
}
