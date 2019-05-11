﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class TematicaController : ApiController
    {


        [Route("api/Tematica/{tematicaId:int}/profesores")]
        [ResponseType(typeof(IEnumerable<IProfesor>))]
        public IEnumerable<IProfesor> GetHorarioProfesor(int tematicaId)
        {
            ITematica tematica = new ITematica();
            
            return tematica.getProfesoresPorTematica(tematicaId);
        }

        // GET: api/Tematica
        public IEnumerable<ITematica> Get()
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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tematica/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tematica/5
        public void Delete(int id)
        {
        }
    }
}
