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
                iHorario.HoraFinal = horario[i].HoraFinal;
                iHorario.HoraInicio = horario[i].HoraInicio;
                iHorario.IdProfesor = horario[i].IdProfesor;
                arrayHorarios.Add(iHorario);

            }
            

            return arrayHorarios;

        }
        public IHorario getHorario(int id)
        {
            /* Horario horario = bd.Horarios.FirstOrDefault(x => x.idHorario == id);
             IHorario tempHorario = new IHorario();

             if(horario != null)
             {
                 tempHorario.idHorario = horario.idHorario;
                 tempHorario.HoraInicio = horario.HoraInicio;
                 tempHorario.HoraFinal = horario.HoraFinal;
                 tempHorario.Fecha = horario.Fecha;
                 tempHorario.Dia = horario.Dia;
             }

             return tempHorario;
         }

         public List<IHorario> getHorarios()
         {
             var temo = bd.Horarios.Select(x => x).ToList();
             List<IHorario> arrayHorarios = new List<IHorario>();

             for (int i = 0; i < temo.Count; i++)
             {
                 IHorario horario = new IHorario();
                 horario.idHorario = temo[i].idHorario;
                 horario.HoraInicio = temo[i].HoraInicio;
                 horario.HoraFinal = temo[i].HoraFinal;
                 horario.Fecha = temo[i].Fecha;
                 horario.Dia = temo[i].Dia;


                 arrayHorarios.Add(horario);
             }
             return arrayHorarios;
             */
            return null;
        }




         
            

    }
}