using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;

namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class NCita:ICita
    {
        ConexionAPI conexion = new ConexionAPI();

        public bool crearFeedBack(FeedBack feedback)
        {

            var values = new Dictionary<string, string>
            {
                {"IdCita",feedback.IdCita.ToString() },
                {"respuesta1",feedback.respuesta1 },
                {"respuesta2",feedback.respuesta2 },
                {"respuesta3",feedback.respuesta3 }
            };

            var content = new FormUrlEncodedContent(values);

            var responseTask = conexion.client.PostAsync("FeedBack/", content);
            responseTask.Wait();


            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }

            return false;
        }

        public bool crearCita(NCita cita)
        {
            
            var values = new Dictionary<string, string>
            {
                {"IdEstudiante",cita.IdEstudiante.ToString() },
                {"IdProfesor",cita.IdProfesor.ToString() },
                {"HoraInicio",cita.HoraInicio.ToString() },
                {"Fecha",cita.Fecha.ToString() }
            };

            var content = new FormUrlEncodedContent(values);

           // JavaScriptSerializer serializer = new JavaScriptSerializer();
           // var jasonObject = serializer.Serialize(cita);
          //  var stringContent = new StringContent(jasonObject.ToString());
            var responseTask = conexion.client.PostAsync("Cita/", content);
            responseTask.Wait();

            
            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }

            return false;
        }
        public bool citaRealizada(int id)
        {

            var values = new Dictionary<string, string>
            {
                {"IdCita",id.ToString() }
               
            };

            var content = new FormUrlEncodedContent(values);

            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // var jasonObject = serializer.Serialize(cita);
            //  var stringContent = new StringContent(jasonObject.ToString());
            var responseTask = conexion.client.PostAsync("Cita/Realizada", content);
            responseTask.Wait();


            var result = responseTask.Result;
            var a = result.RequestMessage;
            if (result.IsSuccessStatusCode)
            {

                return true;
            }

            return false;
        }
        public List<Citas> getCitas()
        {
            var responseTask = conexion.client.GetAsync("Cita");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var citas = serializer.Deserialize<List<Citas>>(readTask.Result);
                return citas;
            }

            return new List<Citas>();
        }
        public List<FeedBack> getFeedback()
        {
            var responseTask = conexion.client.GetAsync("FeedBack");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var feedBacks = serializer.Deserialize<List<FeedBack>>(readTask.Result);
                return feedBacks;
            }

            return new List<FeedBack>();
        }
        public bool eliminarCita(int IdCita) {
            var responseTask = conexion.client.DeleteAsync("Cita/" + IdCita.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
           
                return true;
            }

            return false;
        }


        public List<Pr_CitasFiltrarFecha_Consultar_Result> getCitasPorHorario(string inicio, string final)
        {
            var responseTask = conexion.client.GetAsync("Cita/fecha/" + inicio + "/" + final);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var citas = serializer.Deserialize<List<Pr_CitasFiltrarFecha_Consultar_Result>>(readTask.Result);
                return citas;
            }

            return new List<Pr_CitasFiltrarFecha_Consultar_Result>();

        }

        public List<Pr_DiasCita_Consultar_Result> getDiasCitas(string dia)
        {
            var responseTask = conexion.client.GetAsync("Cita/" + dia + "/dias");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var citas = serializer.Deserialize<List<Pr_DiasCita_Consultar_Result>>(readTask.Result);
                return citas;
            }

            return new List<Pr_DiasCita_Consultar_Result>();

        }


    }
}