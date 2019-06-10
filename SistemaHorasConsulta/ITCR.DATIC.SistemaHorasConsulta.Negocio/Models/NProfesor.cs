using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;
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

        public List<Profesor> getProfesor() {
            var responseTask = conexion.client.GetAsync("Profesor");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var profesores = serializer.Deserialize<List<ProfesorInformacion>>(readTask.Result);
                Profesor listaTemp = new Profesor();
                var listaSinConcurrencias = listaTemp.getProfesoresSinConcurrencias(profesores);
                return listaSinConcurrencias;
            }
            return new List<Profesor>();
        }
        public List<ProfesorInformacion> getProfesor2()
        {
            var responseTask = conexion.client.GetAsync("Profesor");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var profesor = serializer.Deserialize<List<ProfesorInformacion>>(readTask.Result);
                
                return profesor;
            }
            return new List<ProfesorInformacion>();
        }


        public bool eliminarProfesor(int id)
        {/*
            var responseTask = conexion.client.DeleteAsync("Profesor/", id);
            responseTask.Wait();
            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }
            */
            return false;

        }

        public bool actualizarProfesor(Profesor valor)
        {
            var values = new Dictionary<string, string>
             {
                 
                 {"Nombre",valor.Nombre },
                 {"PrimerApellido", valor.PrimerApellido },
                 {"SegundoApellido",valor.SegundoApellido},
                 {"Usuario",valor.Usuario},
                 {"CorreoElectronico",valor.CorreoElectronico},
                 {"IdLugar",valor.IdLugar.ToString()},
                 //{"Foto",valor.Foto.ToString() }


             };
            var content = new FormUrlEncodedContent(values);
            var responseTask = conexion.client.PutAsync("Profesor/"+ valor.IdProfesor.ToString(), content);
            responseTask.Wait();


            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }
          
            return false;

        }

        public bool crearProfesor(Profesor valor)
        {
              var values = new Dictionary<string, string>
             {
                 {"Nombre",valor.Nombre },
                 {"PrimerApellido", valor.PrimerApellido },
                 {"SegundoApellido",valor.SegundoApellido},
                 {"Usuario",valor.Usuario},
                 {"CorreoElectronico",valor.CorreoElectronico},
                 {"IdLugar",valor.IdLugar.ToString()},
                 //{"Foto",valor.Foto.ToString() }


             };

            var content = new FormUrlEncodedContent(values);
            var responseTask = conexion.client.PostAsync("Profesor/", content);
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
