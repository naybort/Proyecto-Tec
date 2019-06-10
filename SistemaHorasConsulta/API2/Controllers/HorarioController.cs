using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;

namespace API.Controllers
{
    public class HorarioController : ApiController
    {

        [Route("api/Horario/profesor/{profesorId:int}")]
        [ResponseType(typeof(IEnumerable<IHorario>))]
        public IEnumerable<IHorario> GetHorarioProfesor(int profesorId)
        {
            IHorario horario = new IHorario();

            return horario.getHorarioProfesor(profesorId);
        }

        [Route("api/Horario/Asociar/")]
        public void crearHorarioAsociar([FromBody]IHorario horario)
        {
            IHorario temp = new IHorario();
            temp.Asociar(horario);

        }
       
        [Route("api/Horario/Eliminar/{idHorario:int}/{idProfesor:int}")]
        [HttpDelete]
        [ResponseType(typeof(HttpResponseMessage))]
        public HttpResponseMessage EliminarHorarioAsociar(int idHorario, int idProfesor)
        {
            IHorario temp = new IHorario();
           
            temp.EliminarAsociado(idHorario, idProfesor);
            return new HttpResponseMessage();
        }
        // GET: api/Horario
        public IEnumerable<Pr_Horarios_Consultar_Result> Get()
        {
            IHorario horarios = new IHorario();
            return horarios.getHorarios();
          
        }

        // GET: api/Horario/5
        public Pr_Horarios_Consultar_Result Get(int id)
        {
            IHorario horarios = new IHorario();
            return horarios.getHorario(id);
        }

        // POST: api/Horario
        public void Post([FromBody]Pr_Horarios_Consultar_Result value)
        {
            IHorario horarios = new IHorario();
            horarios.crearHorario(value.Dia, value.HoraFinal, value.HoraFinal);
        }

        // PUT: api/Horario/5
        public void Put(int id, [FromBody]Pr_Horarios_Consultar_Result value)
        {
            IHorario horarios = new IHorario();
            horarios.editarHorario(value.IdHorario.ToString(), value.Dia, value.HoraFinal.ToString(), value.HoraFinal.ToString());
        }



        // DELETE: api/Horario/5
        public void Delete(int id)
        {
            IHorario horarios = new IHorario();
             horarios.eliminarHorario(id);
        }

    }
}
