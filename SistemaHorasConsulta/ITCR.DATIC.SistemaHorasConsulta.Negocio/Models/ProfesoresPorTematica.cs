using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ITCR.DATIC.SistemaHorasConsulta.Negocio.Models;
using ITCR.DATIC.SistemHorasConsulta.Negocio;
namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class ProfesoresPorTematica
    {
        public List<Horario> horarios = new List<Horario>();

        public int IdProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreLugar { get; set; }
        public string Especialidades { get; set; }
        public string stringFoto { get; set; }
        public string Usuario { get; set; }

        public List<ProfesoresPorTematica> getProfesoresPorTematicas(List<PorfesorPorTematica> lista)
        {
            List<PorfesorPorTematica> listaTemporal = lista;
            List<ProfesoresPorTematica> listaSinConcurrencias = new List<ProfesoresPorTematica>();

            while (lista.Count != 0)
            {
                foreach (var elemento in listaTemporal.ToList())
                {
                    List<PorfesorPorTematica> concurrencias = new List<PorfesorPorTematica>();
                    concurrencias = listaTemporal.FindAll(x => x.IdProfesor == elemento.IdProfesor);

                    ProfesoresPorTematica profesorTematica = new ProfesoresPorTematica();
                    profesorTematica.IdProfesor = elemento.IdProfesor;
                    profesorTematica.NombreProfesor = elemento.Nombre;
                    profesorTematica.PrimerApellido = elemento.PrimerApellido;
                    profesorTematica.SegundoApellido = elemento.SegundoApellido;
                    profesorTematica.NombreLugar = elemento.NombreLugar;
                    profesorTematica.Especialidades = elemento.Especialidades;
                    profesorTematica.stringFoto = elemento.stringFoto;
                    profesorTematica.Usuario = elemento.Usuario;
                    foreach (var value in concurrencias)
                    {
                        
                        Horario horarioProfesor = new Horario();
                        horarioProfesor.Dia = value.Dia;
                        horarioProfesor.HoraInicio = value.HoraInicio;
                        horarioProfesor.HoraFinal = value.HoraFinal;
                        profesorTematica.horarios.Add(horarioProfesor);
                    }
                    if (!listaSinConcurrencias.Exists(x => x.IdProfesor == profesorTematica.IdProfesor)){
                        listaSinConcurrencias.Add(profesorTematica);
                    }
                    
                    
                    listaTemporal.RemoveAll(x => x.IdProfesor == elemento.IdProfesor);
                }

            }
            return listaSinConcurrencias;


        }
    }
}
