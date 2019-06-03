using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
using System.Net.Http;

namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class NHorario:IHorario
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
        public List<AHorario> getHorarios()
        {


            var responseTask = conexion.client.GetAsync("Horario");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var horarios = serializer.Deserialize<List<AHorario>>(readTask.Result);
                return horarios;
            }

            return new List<AHorario>();



        }

        public bool crearHorarioProfesor(int idHorario, int idProfesor) {


            var values = new Dictionary<string, string>
            {
                {"idHorario",idHorario.ToString() },
                {"idProfesor",idProfesor.ToString() }
              
            };

            var content = new FormUrlEncodedContent(values);

            var responseTask = conexion.client.PostAsync("Horario/Asociar/", content);
            responseTask.Wait();
           

            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }

            return false;
        }
        public bool EliminarHorarioProfesor(int idHorario, int idProfesor)
        {
            var responseTask = conexion.client.DeleteAsync("Horario/Eliminar/" + idHorario.ToString() + "/" + idProfesor.ToString());
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