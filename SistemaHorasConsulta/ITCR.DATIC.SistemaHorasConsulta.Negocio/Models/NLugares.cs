using API.Models;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}