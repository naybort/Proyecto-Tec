using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2.Models
{
    public class IFeedBack
    {
        ConexionBD bd = new ConexionBD();

        public int IdCita { get; set; }
        public string respuesta1 { get; set; }
        public string respuesta2 { get; set; }
        public string respuesta3 { get; set; }

        public void guardarFeedBack(IFeedBack feedBack)
        {


            var str = "exec Pr_Feedback_Editar @IdCita = " + feedBack.IdCita.ToString() + ", @Respuesta1 = '" +

                feedBack.respuesta1+ "', @Respuesta2 = '" + feedBack.respuesta2 + "', @Respuesta3 = '" + feedBack.respuesta3 + "', @Comentario = ''";
            var result = bd.Database.ExecuteSqlCommand(str);

        }
        public List<IFeedBack> consutlarFeedBack()
        {
            var feedback = bd.Database.SqlQuery<IFeedBack>("Pr_Feedback_Consultar").ToList();
            return feedback;
        }
    }
}