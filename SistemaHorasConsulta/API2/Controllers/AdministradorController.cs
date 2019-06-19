using API2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API2.Controllers
{
    public class AdministradorController : ApiController
    {
        // GET: api/Administrador
        public IEnumerable<IAdministrador> Get()
        {
            IAdministrador temp = new IAdministrador();
            return temp.getAdministradores();
        }

        // GET: api/Administrador/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Administrador
        public void Post([FromBody]IAdministrador value)
        {
            IAdministrador temp = new IAdministrador();
            temp.insertarAdministrador(value.Usuario);
        }

        // PUT: api/Administrador/5
        public void Put(int id, [FromBody]IAdministrador value)
        {
            IAdministrador temp = new IAdministrador();
            temp.editarAdministrador(id, value.Usuario);
        }

        // DELETE: api/Administrador/5
        public void Delete(int id)
        {
            IAdministrador temp = new IAdministrador();
            temp.eliminarAdministrador(id);
        }
    }
}
