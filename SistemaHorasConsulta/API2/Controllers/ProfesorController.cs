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
        public IEnumerable<Pr_Profesores_Consultar_Result> Get()
        {
            IProfesor profesor = new IProfesor();
            
            return profesor.getProfesores();
        }

        // GET: api/Profesor/5
        public Pr_Profesores_Consultar_Result Get(int id)
        {
            IProfesor profesor = new IProfesor();
            return profesor.getProfesor(id);
        }

        // POST: api/Profesor
        public void Post([FromBody]Pr_Profesores_Consultar_Result value)
        {
            IProfesor profesor = new IProfesor();
            profesor.insertarProfesor(value.Nombre, value.PrimerApellido, value.SegundoApellido, value.Usuario, value.CorreoElectronico
                , value.IdLugar);

        }

        // PUT: api/Profesor/5
        public void Put(int id, [FromBody]Pr_Profesores_Consultar_Result value)
        {

            IProfesor profesor = new IProfesor();
            profesor.editarProfesor(value.IdProfesor, value.Nombre, value.PrimerApellido, value.SegundoApellido, value.Nombre, value.Nombre, value.CorreoElectronico
                , Int32.Parse(value.Nombre), value.Foto);
        }

        // DELETE: api/Profesor/5
        public void Delete(int id)
        {
            IProfesor profesor = new IProfesor();
            profesor.eliminarProfesor(id);
        }
    }
}
