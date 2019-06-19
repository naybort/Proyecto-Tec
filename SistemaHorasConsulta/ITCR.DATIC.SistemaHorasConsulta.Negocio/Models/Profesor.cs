using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCR.DATIC.SistemaHorasConsulta.Negocio.Models
{
    public class Profesor
    {
        public List<Horario> horarios = new List<Horario>();
       

        public int? IdProfesor { get; set; }
        public string Nombre { get; set; }
        public byte[] Foto { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreLugar { get; set; }
        public string Usuario { get; set; }
        public int IdLugar { get; set; }
        public string CorreoElectronico { get; set; }
        public string stringFoto { get; set; }

        public List<Profesor> getProfesoresSinConcurrencias(List<ProfesorInformacion> lista)
        {
            List<ProfesorInformacion> listaTemporal = lista;
            List<Profesor> listaSinConcurrencias = new List<Profesor>();

            while (lista.Count != 0)
            {
                foreach (var elemento in listaTemporal.ToList())
                {
                    List<ProfesorInformacion> concurrencias = new List<ProfesorInformacion>();
                    concurrencias = listaTemporal.FindAll(x => x.IdProfesor == elemento.IdProfesor);

                    Profesor profesorTemp = new Profesor();
                    profesorTemp.IdProfesor = elemento.IdProfesor;
                    profesorTemp.Nombre = elemento.Nombre;
                    profesorTemp.PrimerApellido = elemento.PrimerApellido;
                    profesorTemp.SegundoApellido = elemento.SegundoApellido;
                    profesorTemp.NombreLugar = elemento.NombreLugar;
                    profesorTemp.CorreoElectronico = elemento.CorreoElectronico;
                    profesorTemp.stringFoto = elemento.stringFoto;
                    profesorTemp.Usuario = elemento.Usuario;
               
                    profesorTemp.Foto = elemento.Foto;
                    
                    foreach (var value in concurrencias)
                    {

                        Horario horarioProfesor = new Horario();
                        horarioProfesor.IdHorario = value.IdHorario;
                        horarioProfesor.Dia = value.Dia;
                        horarioProfesor.HoraInicio = value.HoraInicio;
                        horarioProfesor.HoraFinal = value.HoraFinal;
                        profesorTemp.horarios.Add(horarioProfesor);
                    }
                    if (!listaSinConcurrencias.Exists(x => x.IdProfesor == profesorTemp.IdProfesor))
                    {
                        listaSinConcurrencias.Add(profesorTemp);
                    }


                    listaTemporal.RemoveAll(x => x.IdProfesor == elemento.IdProfesor);
                }

            }
            return listaSinConcurrencias;


        }
    }
}