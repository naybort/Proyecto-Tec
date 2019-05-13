using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class NCita:ICita
    {
        ConexionAPI conexion = new ConexionAPI();

        public bool crearCita(NCita cita)
        {
            var values = new Dictionary<string, string>
            {
                {"IdEstudiante",cita.IdEstudiante.ToString() },
                {"IdHorario" ,cita.IdHorario.ToString()},
                {"IdLugar", cita.IdLugar.ToString() },
                {"IdProfesor",cita.IdProfesor.ToString() },
                {"HoraInicio",cita.HoraInicio.ToString() }
            };

            var content = new FormUrlEncodedContent(values);

           // JavaScriptSerializer serializer = new JavaScriptSerializer();
           // var jasonObject = serializer.Serialize(cita);
          //  var stringContent = new StringContent(jasonObject.ToString());
            var responseTask = conexion.client.PostAsync("Cita/", content);
            responseTask.Wait();

            
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}