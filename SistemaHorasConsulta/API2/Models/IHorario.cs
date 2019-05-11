using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos;

namespace API.Models
{
    public class IHorario:Horario
    {
        ConexionBD bd = new ConexionBD();

        public IHorario getHorario(int id)
        {
            Horario horario = bd.Horarios.FirstOrDefault(x => x.idHorario == id);
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
        }


    }
}