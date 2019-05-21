using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace API.Models
{
    public class ICita
    {
        ConexionBD bd = new ConexionBD();
     
        public int IdProfesor { get; set; }
        public int IdEstudiante { get; set; }
        public string Fecha { get; set; }

        public DateTime HoraInicio { get; set; }

        public ICita GetCita(int id)
        {
            //var cita = bd.Pr_CitaEspecifica_Consultar(id); 
            ICita temp = new ICita();
            return temp; 
        }

        public void guardarCita(ICita cita)
        {
            var parametroIdProfesor = new SqlParameter("@IdProfesor", cita.IdProfesor);
            var parametroIdEstudiante = new SqlParameter("@IdEstudiante", cita.IdEstudiante);
            var parametroHoraInicio = new SqlParameter("@HoraInicio", "7:00");
            var parametroFecha = new SqlParameter("@Fecha", "12-12-2018");

            var str = "exec Pr_Cita_Insertar @IdProfesor = "+ cita.IdProfesor.ToString() + ", @IdEstudiante = "+
                
                cita.IdEstudiante.ToString() +", @Fecha = '"+cita.Fecha+"', @Horainicio = '"+cita.HoraInicio.ToString("HH:mm") +"'";
            var result =  bd.Database.ExecuteSqlCommand(str);
           
        }

        public List<Pr_Citas_Consultar_Result> getCitas()
        {
            var citas = bd.Database.SqlQuery<Pr_Citas_Consultar_Result>("Pr_Citas_Consultar").ToList();
            return citas;
        }

        public bool eliminarCita(int IdCita) {
            var IdCita1 = new SqlParameter("@IdCita", IdCita);
            bd.Database.ExecuteSqlCommand("Pr_Cita_Eliminar @IdCita", IdCita1);
            return true;
        }


    }
}