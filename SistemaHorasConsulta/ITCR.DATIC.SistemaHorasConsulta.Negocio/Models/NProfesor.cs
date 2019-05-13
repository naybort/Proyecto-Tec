using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class NProfesor
    {
        ConexionAPI conexion = new ConexionAPI();
        public List<int> getCitasXProfesor(int id)
        {
            var responseTask = conexion.client.GetAsync("/Profesor/"+id+"/citas");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var citas = serializer.Deserialize<List<int>>(readTask.Result);
                return citas;
            }
            return new List<int>();
        }

    }
}