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
    public class HorarioController : ApiController
    {

        [Route("api/Horario/profesor/{profesorId:int}")]
        [ResponseType(typeof(IEnumerable<IHorario>))]
        public IEnumerable<IHorario> GetHorarioProfesor(int profesorId)
        {
            IProfesor profesor = new IProfesor();
            profesor = profesor.getProfesor(profesorId);
            return profesor.listaHorarios;
        }

        // GET: api/Horario
        public IEnumerable<IHorario> Get()
        {
            IHorario horarios = new IHorario();
            return horarios.getHorarios();
        }

        // GET: api/Horario/5
        public IHorario Get(int id)
        {
            IHorario horarios = new IHorario();
            return horarios.getHorario(id);
        }

        // POST: api/Horario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Horario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Horario/5
        public void Delete(int id)
        {
        }
    }
}
