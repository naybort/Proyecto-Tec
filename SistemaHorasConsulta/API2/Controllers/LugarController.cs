using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class LugarController : ApiController
    {
        // GET: api/Lugar
        public IEnumerable<ILugar> Get()
        {
            ILugar lugar = new ILugar();
            return lugar.getLugares();
        }

        // GET: api/Lugar/5
        public ILugar Get(int id)
        {
            ILugar lugar = new ILugar();


            return lugar.getLugar(id);
        }

        // POST: api/Lugar
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Lugar/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Lugar/5
        public void Delete(int id)
        {
        }
    }
}
