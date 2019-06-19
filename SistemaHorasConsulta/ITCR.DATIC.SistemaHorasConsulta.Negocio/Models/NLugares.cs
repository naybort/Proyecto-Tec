using API.Models;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;

namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class NLugares:ILugar
    {
        ConexionAPI conexion = new ConexionAPI();
        public List<Lugares> getLugares()
        {
            var responseTask = conexion.client.GetAsync("Lugar");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var lugares = serializer.Deserialize<List<Lugares>>(readTask.Result);
                
                return lugares;
            }
            return new List<Lugares>();
        }

        public bool crearLugar(Lugares lugar)

        {
            var values = new Dictionary<string, string>
             {
                 {"Nombre",lugar.Nombre },
             };

            var content = new FormUrlEncodedContent(values);
            var responseTask = conexion.client.PostAsync("Lugar/", content);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var lugares = serializer.Deserialize<List<Lugares>>(readTask.Result);

                return true;
            }
            return false;
        }

        public bool actualizarLugar(Lugares valor)
        {
            var values = new Dictionary<string, string>
             {

                 {"Nombre",valor.Nombre },

             };
            var content = new FormUrlEncodedContent(values);
            var responseTask = conexion.client.PutAsync("Lugar/" + valor.IdLugar.ToString(), content);
            responseTask.Wait();


            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }

            return false;

        }
        public bool eliminarLugar(int id)
        {
            var responseTask = conexion.client.DeleteAsync("Lugar/" + id.ToString());
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