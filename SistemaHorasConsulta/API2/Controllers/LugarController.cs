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
    public class LugarController : ApiController
    {
       

        // GET: api/Lugar/5
       

        public IEnumerable<Pr_Lugares_Consultar_Result> Get()
        {
            ILugar lugar = new ILugar();
            return lugar.getLugares();
        }

        // GET: api/Lugar/5
        public Pr_Lugares_Consultar_Result Get(int id)
        {
            ILugar lugar = new ILugar();


            return lugar.getLugar(id);
        }


        // POST: api/Lugar
        public void Post([FromBody]string value)
        {
            ILugar lugar = new ILugar();
            lugar.lugarInsertar(value);
        }

        // PUT: api/Lugar/5
        public void Put(int id, [FromBody]Pr_Lugares_Consultar_Result value)
        {
            ILugar lugar = new ILugar();
            lugar.editarLugar(value.IdLugar, value.Nombre);

        }

        // DELETE: api/Lugar/5
        public void Delete(int id)
        {
            ILugar lugar = new ILugar();
            lugar.eliminarLugar(id);
        }
    }
}
