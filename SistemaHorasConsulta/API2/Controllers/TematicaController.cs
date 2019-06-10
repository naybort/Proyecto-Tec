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
    public class TematicaController : ApiController
    {


        [Route("api/Tematica/{tematicaId:int}/profesores")]
        [ResponseType(typeof(IEnumerable<IProfesor>))]
        public IEnumerable<Pr_ProfesoresXTematica_Consultar_Result> GetHorarioProfesor(int tematicaId)
        {
            ITematica tematica = new ITematica();
            
            return tematica.getProfesoresPorTematica(tematicaId);
        }

        [Route("api/Profesor/{profesorId:int}/Tematica")]
 
        public IEnumerable<Pr_TematicasXProfesor_Consultar_Result> GetTematicaProfesor(int profesorId)
        {
            ITematica tematica = new ITematica();

            return tematica.getTematicaPorProfesor(profesorId);
        }

        [Route("api/Tematica/Asociar/")]
        public void crearTematicaAsociar([FromBody]ITematica tematica)
        {
            ITematica temp = new ITematica();
            temp.Asociar(tematica);

        }
        // GET: api/Tematica
        public IEnumerable<Pr_Tematicas_Consultar_Result> Get()
        {
            ITematica tematica = new ITematica();
            return tematica.getTematicas();
        }

        // GET: api/Tematica/5
        public ITematica Get(int id)
        {
            ITematica tematica = new ITematica();
            return tematica.getTematica(id);
        }

        // POST: api/Tematica
        public void Post([FromBody]Pr_TematicasXProfesor_Consultar_Result value)
        {
            ITematica tematica = new ITematica();
            //tematica.crearTematica(value.Nombre,value)
        }

        // PUT: api/Tematica/5
        public void Put(int id, [FromBody]Pr_TematicasXProfesor_Consultar_Result value)
        {
            ITematica tematica = new ITematica();
            //tematica.editarTematica()
        }

        // DELETE: api/Tematica/5
        public void Delete(int id)
        {
            ITematica tematica = new ITematica();
            tematica.eliminarTematica(id);
        }
    }
}
