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
            var profesores = profesor.getProfesores();
            foreach(var i in profesores){
                if (i.Foto != null)
                {
                    i.stringFoto = Convert.ToBase64String(i.Foto);
                    i.Foto = null;
                }
            }

            return profesores;
        }

        // GET: api/Profesor/5
        public Pr_Profesores_Consultar_Result Get(int id)
        {
            IProfesor profesor = new IProfesor();
            var profesorx = profesor.getProfesor(id);
            profesorx.stringFoto = Convert.ToBase64String(profesorx.Foto);
            profesorx.Foto = null;
            return profesorx;
        }

        // POST: api/Profesor
        public void Post([FromBody]Pr_Profesores_Consultar_Result value)
        {
            IProfesor profesor = new IProfesor();
            if (value.stringFoto != null)
            {
                value.Foto = System.Convert.FromBase64String(value.stringFoto);
                profesor.insertarProfesor(value.Nombre, value.PrimerApellido, value.SegundoApellido, value.Usuario, value.CorreoElectronico
                    , value.IdLugar, value.Foto);
            }
            else {
                profesor.insertarProfesor(value.Nombre, value.PrimerApellido, value.SegundoApellido, value.Usuario, value.CorreoElectronico
                    , value.IdLugar, null);
            }
            

        }

        // PUT: api/Profesor/5
        public void Put(int id, [FromBody]Pr_Profesores_Consultar_Result value)
        {

            IProfesor profesor = new IProfesor();
            if (value.stringFoto != null)
            {
                value.Foto = System.Convert.FromBase64String(value.stringFoto);
                profesor.editarProfesor(id, value.Nombre, value.PrimerApellido, value.SegundoApellido, value.Usuario, value.CorreoElectronico
           , value.IdLugar, value.Foto);
            }
            else
            {
                profesor.editarProfesor(id, value.Nombre, value.PrimerApellido, value.SegundoApellido, value.Usuario, value.CorreoElectronico
            , value.IdLugar, null);
            }
       
        }

        // DELETE: api/Profesor/5
        public void Delete(int id)
        {
            IProfesor profesor = new IProfesor();
            profesor.eliminarProfesor(id);
        }
    }
}
