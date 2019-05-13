using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class NHorario
    {
        ConexionAPI conexion = new ConexionAPI();

        public List<HorarioProfesor> getHorarioProfesor(int id)
        {
       

            var responseTask = conexion.client.GetAsync("Horario/profesor/"+id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var horarios = serializer.Deserialize<List<HorarioProfesor>>(readTask.Result);
                return horarios;
            }

            return new List<HorarioProfesor>();



        }


    }
}