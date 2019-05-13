using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
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

        public List<PorfesorPorTematica> getProfesorPorTematica(int id)
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
                return profesorPorTematica;
            }

            return new List<PorfesorPorTematica>();

        }

    }
}