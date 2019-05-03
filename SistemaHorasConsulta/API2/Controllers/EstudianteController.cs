using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class EstudianteController : ApiController
    {
        // GET: api/Estudiante
        public IEnumerable<IEstudiante> Get()
        {
            IEstudiante temp = new IEstudiante();
            return temp.getEstudiantes();
        }

        // GET: api/Estudiante/5
        public IEstudiante Get(int id)
        {
            IEstudiante temp = new IEstudiante();

            return temp.getEstudiante(id);
            
        }

        // POST: api/Estudiante
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Estudiante/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Estudiante/5
        public void Delete(int id)
        {
        }
    }
}
