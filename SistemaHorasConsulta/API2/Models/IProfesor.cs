using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace API.Models
{
    public class IProfesor:Profesor
    {
        ConexionBD bd = new ConexionBD();
        public List<IHorario> listaHorarios = new List<IHorario>();
        public List<ITematica> listaTematicas = new List<ITematica>();

        public List<int> getCitasProfesor(int id)
        {
            var idProfesor = new SqlParameter("@IdProfesor", id);
            var citas = bd.Database.SqlQuery<int>("Pr_CitasXProfesor_Obtener @IdProfesor", idProfesor).ToList();
            return citas;
        }

        public IProfesor getProfesor(int id)
        {
           // Profesor temo = bd.Profesors.Include("Horarios").FirstOrDefault(x => x.IdProfesor == id);
            IProfesor profesor = new IProfesor();
           /* 

            if(temo != null)
            {
                profesor.IdProfesor = temo.IdProfesor;
                profesor.Nombre = temo.Nombre;
                profesor.PrimerApellido = temo.PrimerApellido;
                profesor.SegundoApellido = temo.SegundoApellido;
                profesor.CorreoElectronico = temo.CorreoElectronico;

                
                var list = temo.Horarios.ToList();
                for (int i = 0; i < temo.Horarios.Count; i++)
                {
                    IHorario horario = new IHorario();
                    horario.Dia = list[i].Dia;
                    horario.Fecha = list[i].Fecha;
                    horario.HoraFinal= list[i].HoraFinal;
                    horario.HoraInicio = list[i].HoraInicio;
                    horario.idHorario = list[i].idHorario;
                    profesor.listaHorarios.Add(horario);
                }

                var tematicaXprofesor = bd.ProfesorXTematicas.Where(x => x.IdProfesor == temo.IdProfesor).ToList();
                foreach (var tematica in tematicaXprofesor)
                {
                    ITematica tempTematica = new ITematica();
                    profesor.listaTematicas.Add(tempTematica.getTematica(tematica.IdTematica));

                }


            }
            */
            return profesor;
        }

        public List<IProfesor> getProfesores()
        {
           // var temo = bd.Profesors.Include("Horarios").Select(x => x).ToList();
            List<IProfesor> arrayProfesores = new List<IProfesor>();
            /*
            for (int i = 0; i < temo.Count; i++)
            {
                IProfesor profesor = new IProfesor();
                profesor.CorreoElectronico = temo[i].CorreoElectronico;
                profesor.IdProfesor = temo[i].IdProfesor;
                profesor.Nombre = temo[i].Nombre;
                profesor.PrimerApellido = temo[i].PrimerApellido;
                profesor.SegundoApellido = temo[i].SegundoApellido;

                var list = temo[i].Horarios.ToList();
                for (int j = 0; j < temo[i].Horarios.Count; j++)
                {
                    IHorario horario = new IHorario();
                    horario.Dia = list[j].Dia;
                    horario.Fecha = list[j].Fecha;
                    horario.HoraFinal = list[j].HoraFinal;
                    horario.HoraInicio = list[j].HoraInicio;
                    horario.idHorario = list[j].idHorario;
                    profesor.listaHorarios.Add(horario);
                }

                var tematicaXprofesor = bd.ProfesorXTematicas.Where(x => x.IdProfesor == temo[i].IdProfesor).ToList();
                foreach (var tematica in tematicaXprofesor)
                {
                    ITematica tempTematica = new ITematica();
                    profesor.listaTematicas.Add(tempTematica.getTematica(tematica.IdTematica));

                }


                arrayProfesores.Add(profesor);

            }*/
            return arrayProfesores;
        }

       

    }
}