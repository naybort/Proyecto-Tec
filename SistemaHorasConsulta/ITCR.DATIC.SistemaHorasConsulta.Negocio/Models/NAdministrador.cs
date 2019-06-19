using ITCR.DATIC.SistemHorasConsulta.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;

namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class NAdministrador
    {
        ConexionAPI conexion = new ConexionAPI();


        public List<Administrador> getAdministradores()
        {
            var responseTask = conexion.client.GetAsync("Administrador");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var admins = serializer.Deserialize<List<Administrador>>(readTask.Result);
    
                return admins;
            }
            return new List<Administrador>();
        }


        public bool eliminarAdministrador(int id)
        {
            var responseTask = conexion.client.DeleteAsync("Administrador/" + id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }

            return false;

        }

        public bool actualizarAdministrador(Administrador valor)
        {
            var values = new Dictionary<string, string>
             {

                 {"Usuario",valor.Usuario }


             };
            var content = new FormUrlEncodedContent(values);
            var responseTask = conexion.client.PutAsync("Administrador/" + valor.IdAdministrador.ToString(), content);
            responseTask.Wait();


            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }

            return false;

        }

        public bool crearAdministrador(Administrador valor)
        {
            var values = new Dictionary<string, string>
             {
                 {"Usuario",valor.Usuario }


             };

            var content = new FormUrlEncodedContent(values);
            var responseTask = conexion.client.PostAsync("Administrador/", content);
            responseTask.Wait();


            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }

            return false;
        }

    }

}
