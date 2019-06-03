using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace API.Models
{
    public class IHorario: Pr_HorarioProfesor_Consultar_Result
    {
        ConexionBD bd = new ConexionBD();
        public int IdProfesor { get; set; }
        public int IdHorario { get; set; }
        public bool crearHorario(string dia, Nullable<System.TimeSpan> horaInicio, Nullable<System.TimeSpan> horaFinal)
        {

            var parametroDia = new SqlParameter("@Dia", dia);
            var parematroHoraInicio = new SqlParameter("@HoraInicio", horaInicio);
            var parametroHoraFinal = new SqlParameter("@HoraFinal", horaFinal);

            var horario = bd.Database.ExecuteSqlCommand("exec Pr_Horario_Insertar @Dia, @HoraInicio, @HoraFinal", parametroDia, parematroHoraInicio,parametroHoraFinal);
            return true;
        }

        public List<IHorario> getHorarioProfesor(int id)
        {
            var idProfesor = new SqlParameter("@IdProfesor", id);
            var horario = bd.Database.SqlQuery<Pr_HorarioProfesor_Consultar_Result>("Pr_HorarioProfesor_Consultar @IdProfesor", idProfesor).ToList();
            List<IHorario> arrayHorarios = new List<IHorario>();

            for (int i = 0; i < horario.Count; i++)
            {
                IHorario iHorario = new IHorario();
                iHorario.Dia = horario[i].Dia;
                iHorario.IdHorario = horario[i].IdHorario;
                iHorario.HoraFinal = horario[i].HoraFinal;
                iHorario.HoraInicio = horario[i].HoraInicio;
                iHorario.IdProfesor = horario[i].IdProfesor;
                arrayHorarios.Add(iHorario);

            }
            

            return arrayHorarios;

        }
        public List<Pr_Horarios_Consultar_Result> getHorarios() {
            var horarios = bd.Database.SqlQuery<Pr_Horarios_Consultar_Result>("Pr_Horarios_Consultar").ToList();
            return horarios;
        }
        public Pr_Horarios_Consultar_Result getHorario(int id)
        {
            return getHorarios().Where(x => x.IdHorario == id).FirstOrDefault();
        }

        public bool Asociar(IHorario horario) {
            var str = "exec Pr_HorarioXProfesor_Insertar @IdHorario = " + horario.IdHorario.ToString() + ",  @IdProfesor = " + horario.IdProfesor.ToString() ;
            var result = bd.Database.ExecuteSqlCommand(str);
            
            return true;
        }
        public bool EliminarAsociado(int idHorario, int idProfesor) {
            var str = "exec Pr_HorarioXProfesor_Eliminar @IdHorario = " + idHorario.ToString() + ",  @IdProfesor = " + idProfesor.ToString();
            var result = bd.Database.ExecuteSqlCommand(str);

            return true;
        }






    }
}