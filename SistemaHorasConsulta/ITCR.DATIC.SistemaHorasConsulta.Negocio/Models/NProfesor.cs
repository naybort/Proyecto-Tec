using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
using API2.Models;
using Newtonsoft.Json;

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
        {
            var responseTask = conexion.client.DeleteAsync("Profesor/"+ id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }
            
            return false;

        }

        public bool actualizarProfesor(Profesor valor)
        {
            if (valor.Foto != null)
            {
                byte[] imageBytes = valor.Foto;


                string base64String = Convert.ToBase64String(imageBytes);
                var options = new
                {
                    Nombre = valor.Nombre,
                    PrimerApellido = valor.PrimerApellido,
                    SegundoApellido = valor.SegundoApellido,
                    Usuario = valor.Usuario,
                    CorreoElectronico = valor.CorreoElectronico,
                    IdLugar = valor.IdLugar,
                    stringFoto = base64String,

                };
                var stringPayload = JsonConvert.SerializeObject(options);


                var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                var imageBinaryContent = new ByteArrayContent(imageBytes);
                var name = new StringContent(valor.Nombre);
                var apellido1 = new StringContent(valor.PrimerApellido);
                var apellido2 = new StringContent(valor.SegundoApellido);
                var usuarios = new StringContent(valor.Usuario);
                var correo = new StringContent(valor.CorreoElectronico);
                var idLugar = new StringContent(valor.IdLugar.ToString());

                var multiPartContent = new MultipartFormDataContent();

                var client = new HttpClient();






                multiPartContent.Add(name, "Nombre");
                multiPartContent.Add(apellido1, "PrimerApellido");
                multiPartContent.Add(apellido2, "SegundoApellido");
                multiPartContent.Add(usuarios, "Usuario");
                multiPartContent.Add(correo, "CorreoElectronico");
                multiPartContent.Add(idLugar, "IdLugar");
                multiPartContent.Add(imageBinaryContent, "Foto");

                // var content = new FormUrlEncodedContent(values); // pruebelo de nuevo porfa solo una vez mas jeje

                multiPartContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                multiPartContent.Headers.ContentType.CharSet = "UTF-8";
                var responseTask = conexion.client.PutAsync("Profesor/" + valor.IdProfesor.ToString(), content);
                responseTask.Wait();



                var result = responseTask.Result;
                var a = result.RequestMessage;
                if (result.IsSuccessStatusCode)
                {

                    return true;
                }

                return false;
            }
            else
            {
                string base64String = null;
                var options = new
                {
                    Nombre = valor.Nombre,
                    PrimerApellido = valor.PrimerApellido,
                    SegundoApellido = valor.SegundoApellido,
                    Usuario = valor.Usuario,
                    CorreoElectronico = valor.CorreoElectronico,
                    IdLugar = valor.IdLugar,
                    stringFoto = base64String,

                };
                var stringPayload = JsonConvert.SerializeObject(options);


                var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");


                var name = new StringContent(valor.Nombre);
                var apellido1 = new StringContent(valor.PrimerApellido);
                var apellido2 = new StringContent(valor.SegundoApellido);
                var usuarios = new StringContent(valor.Usuario);
                var correo = new StringContent(valor.CorreoElectronico);
                var idLugar = new StringContent(valor.IdLugar.ToString());

                var multiPartContent = new MultipartFormDataContent();

                var client = new HttpClient();






                multiPartContent.Add(name, "Nombre");
                multiPartContent.Add(apellido1, "PrimerApellido");
                multiPartContent.Add(apellido2, "SegundoApellido");
                multiPartContent.Add(usuarios, "Usuario");
                multiPartContent.Add(correo, "CorreoElectronico");
                multiPartContent.Add(idLugar, "IdLugar");
          

                multiPartContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                multiPartContent.Headers.ContentType.CharSet = "UTF-8";
                var responseTask = conexion.client.PutAsync("Profesor/" + valor.IdProfesor.ToString(), content);
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

        public bool crearProfesor(Profesor valor)
        {
            if (valor.Foto != null)
            {
                byte[] imageBytes = valor.Foto;


                string base64String = Convert.ToBase64String(imageBytes);
                var options = new
                {
                    Nombre = valor.Nombre,
                    PrimerApellido = valor.PrimerApellido,
                    SegundoApellido = valor.SegundoApellido,
                    Usuario = valor.Usuario,
                    CorreoElectronico = valor.CorreoElectronico,
                    IdLugar = valor.IdLugar,
                    stringFoto = base64String,

                };
                var stringPayload = JsonConvert.SerializeObject(options);


                var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                var imageBinaryContent = new ByteArrayContent(imageBytes);
                var name = new StringContent(valor.Nombre);
                var apellido1 = new StringContent(valor.PrimerApellido);
                var apellido2 = new StringContent(valor.SegundoApellido);
                var usuarios = new StringContent(valor.Usuario);
                var correo = new StringContent(valor.CorreoElectronico);
                var idLugar = new StringContent(valor.IdLugar.ToString());

                var multiPartContent = new MultipartFormDataContent();

                var client = new HttpClient();






                multiPartContent.Add(name, "Nombre");
                multiPartContent.Add(apellido1, "PrimerApellido");
                multiPartContent.Add(apellido2, "SegundoApellido");
                multiPartContent.Add(usuarios, "Usuario");
                multiPartContent.Add(correo, "CorreoElectronico");
                multiPartContent.Add(idLugar, "IdLugar");
                multiPartContent.Add(imageBinaryContent, "Foto");

          

                multiPartContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                multiPartContent.Headers.ContentType.CharSet = "UTF-8";
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
            else {
                string base64String = null;
                var options = new
                {
                    Nombre = valor.Nombre,
                    PrimerApellido = valor.PrimerApellido,
                    SegundoApellido = valor.SegundoApellido,
                    Usuario = valor.Usuario,
                    CorreoElectronico = valor.CorreoElectronico,
                    IdLugar = valor.IdLugar,
                    stringFoto = base64String,

                };
                var stringPayload = JsonConvert.SerializeObject(options);


                var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                
                var name = new StringContent(valor.Nombre);
                var apellido1 = new StringContent(valor.PrimerApellido);
                var apellido2 = new StringContent(valor.SegundoApellido);
                var usuarios = new StringContent(valor.Usuario);
                var correo = new StringContent(valor.CorreoElectronico);
                var idLugar = new StringContent(valor.IdLugar.ToString());

                var multiPartContent = new MultipartFormDataContent();

                var client = new HttpClient();






                multiPartContent.Add(name, "Nombre");
                multiPartContent.Add(apellido1, "PrimerApellido");
                multiPartContent.Add(apellido2, "SegundoApellido");
                multiPartContent.Add(usuarios, "Usuario");
                multiPartContent.Add(correo, "CorreoElectronico");
                multiPartContent.Add(idLugar, "IdLugar");
  

                multiPartContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                multiPartContent.Headers.ContentType.CharSet = "UTF-8";
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


}
