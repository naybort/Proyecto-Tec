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
        public DateTime Fecha { get; set; }
        public int IdCita { get; set; }
        public DateTime HoraInicio { get; set; }
        public bool Estado { get; set; }
        public ICita GetCita(int id)
        {
            //var cita = bd.Pr_CitaEspecifica_Consultar(id); 
            ICita temp = new ICita();
            return temp; 
        }
   
        public void guardarCita(ICita cita)
        {
            
            
            var str = "exec Pr_Cita_Insertar @IdProfesor = "+ cita.IdProfesor.ToString() + ", @IdEstudiante = "+
                
                cita.IdEstudiante.ToString() +", @Fecha = '"+cita.Fecha.ToShortDateString()+"', @HoraInicio = '"+cita.HoraInicio.ToString("HH:mm") +"', @CorreoEstudiante=''" +
                "";
            var result =  bd.Database.ExecuteSqlCommand(str);
           
        }
        public void citaRealizada(ICita cita) {
            var str = "exec Pr_CitaRealizada_Editar @IdCita = " + cita.IdCita.ToString();
            var result = bd.Database.ExecuteSqlCommand(str);
        }

        public List<Pr_Citas_Consultar_Result> getCitas()
        {
            var citas = bd.Database.SqlQuery<Pr_Citas_Consultar_Result>("Pr_Citas_Consultar").ToList();
            return citas;
        }

        public bool eliminarCita(int IdCita) {
            var str = "exec Pr_Cita_Cancelar @IdCita = " + IdCita.ToString();
            var result = bd.Database.ExecuteSqlCommand(str);
            
            return true;
        }

        public List<Pr_CitasFiltrarFecha_Consultar_Result> getCitasPorFecha(DateTime inicio, DateTime final) {
            var fecha1 = new SqlParameter("@Fecha1", inicio.ToShortDateString());
            var fecha2 = new SqlParameter("@Fecha2", final.ToShortDateString());

            var citas = bd.Database.SqlQuery<Pr_CitasFiltrarFecha_Consultar_Result>("Pr_CitasFiltrarFecha_Consultar @Fecha1, @Fecha2", fecha1,fecha2).ToList();

            return citas;
        }

        public List<Pr_DiasCita_Consultar_Result> diasCita(DateTime dia) {
            var diaCita = new SqlParameter("@Dia", dia);

            var citas = bd.Database.SqlQuery<Pr_DiasCita_Consultar_Result>("Pr_CitasFiltrarFecha_Consultar @Dia", diaCita).ToList();
            return citas;
        }



    }
}