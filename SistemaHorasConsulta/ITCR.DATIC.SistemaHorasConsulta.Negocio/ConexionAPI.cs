using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ITCR.DATIC.SistemHorasConsulta.Negocio
{
    public class ConexionAPI
    {
        public HttpClient client = new HttpClient();
        string url = "http://localhost:50013/api/";

        public ConexionAPI(){
            client.BaseAddress = new Uri(url);
        }
       
    }
}