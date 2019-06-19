using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
using System.Net.Http;

namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class NTematica
    {
        ConexionAPI conexion = new ConexionAPI();
        public List<getTematicas> getTematicas()
        {

            var responseTask = conexion.client.GetAsync("Tematica");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var tematicas = serializer.Deserialize<List<getTematicas>>(readTask.Result);
                return tematicas;
            }

            return new List<getTematicas>();

        }
        
        public List<ProfesoresPorTematica> getProfesorPorTematica(int id)
        {

            var responseTask = conexion.client.GetAsync("Tematica/"+id+"/profesores");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var profesorPorTematica = serializer.Deserialize<List<PorfesorPorTematica>>(readTask.Result);
                var profesoresPorTematica2 = new ProfesoresPorTematica();
                var profesorPorTematicaSinConcurrencia = profesoresPorTematica2.getProfesoresPorTematicas(profesorPorTematica);
                return profesorPorTematicaSinConcurrencia;
            }

            return new List<ProfesoresPorTematica>();

        }
        public List<TematicaPorProfesor> getTematicasPorProfesor(int id)
        {

            var responseTask = conexion.client.GetAsync("Profesor/" + id + "/Tematica");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var tematicaPorProfesor = serializer.Deserialize<List<TematicaPorProfesor>>(readTask.Result);
                return tematicaPorProfesor;
            }

            return new List<TematicaPorProfesor>();

        }

        public bool eliminarTematica(int id)
        {
            
            var responseTask = conexion.client.DeleteAsync("Tematica/"+id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }
            
            return false;

        }

        public bool actualizarTematica(getTematicas valor)
        {

            var values = new Dictionary<string, string>
             {

                 {"NombreTematica",valor.NombreTematica },
                 {"Descripcion", valor.Descripcion }



             };
            var content = new FormUrlEncodedContent(values);
            var responseTask = conexion.client.PutAsync("Tematica/" + valor.IdTematica.ToString(), content);
            responseTask.Wait();


            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }
            
            return false;

        }

        public bool crearTematica(getTematicas valor)
        {

            var values = new Dictionary<string, string>
             {

                 {"NombreTematica",valor.NombreTematica },
                 {"Descripcion", valor.Descripcion }
                 


             };
            var content = new FormUrlEncodedContent(values);
            var responseTask = conexion.client.PostAsync("Tematica/", content);
            responseTask.Wait();


            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }
            
            return false;
        }


        public bool crearTematicaPorProfesor(string especialidades, int idTematica, int idProfesor)
        {


            var values = new Dictionary<string, string>
            {
                {"Especialidades",especialidades },
                {"idTematica",idTematica.ToString() },
                {"IdProfesor",idProfesor.ToString() }

            };

            var content = new FormUrlEncodedContent(values);

            var responseTask = conexion.client.PostAsync("Tematica/Asociar/", content);
            responseTask.Wait();


            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }

            return false;
        }
        public bool EliminarHorarioProfesor(int idTematica, int idProfesor)
        {

            var values = new Dictionary<string, string>
            {
                {"id",idTematica.ToString() },
                {"id2",idProfesor.ToString() }

            };

            var content = new FormUrlEncodedContent(values);
            var responseTask = conexion.client.PostAsync("Tematica/Eliminar/", content);
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