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
        public int IdLugar { get; set; }
        public int IdHorario { get; set; }
        public int IdProfesor { get; set; }
        public int IdEstudiante { get; set; }

        public System.TimeSpan HoraInicio { get; set; }

        public ICita GetCita(int id)
        {
           var cita = bd.Pr_CitaEspecifica_Consultar(id); 
            ICita temp = new ICita();
            return temp; 
        }

        public List<ICita> getCitas()
        {
            return null;
        }

        public void guardarCita(ICita cita)
        {
            var parametroLugar = new SqlParameter("@IdLugar", cita.IdLugar);
            var parematroIdHorario = new SqlParameter("@IdHorario", cita.IdHorario);
            var parametroIdProfesor = new SqlParameter("@IdProfesor", cita.IdProfesor);
            var parametroIdEstudiante = new SqlParameter("@IdEstudiante", cita.IdEstudiante);
            var parametroHoraInicio = new SqlParameter("@HoraInicio", cita.HoraInicio);
          
            var result =  bd.Database.SqlQuery<int>("Pr_Cita_Insertar @IdLugar, @IdHorario, @IdProfesor, @IdEstudiante, @HoraInicio",
                parametroLugar, parematroIdHorario, parametroIdProfesor, parametroIdEstudiante, parametroHoraInicio).ToList();
           
        }


    }
}