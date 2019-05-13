using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;

namespace API.Models
{
    public class IEstudiante : Estudiante
    {
        public List<ICita> citas = new List<ICita>();
        ConexionBD bd = new ConexionBD();
        public IEstudiante getEstudiante(int id)
        {
            //Estudiante temo = bd.Estudiantes.FirstOrDefault(x => x.IdEstudiante == id);
            IEstudiante estudiante = new IEstudiante();
           /* 
            if (temo != null) {
                estudiante.Nombre = temo.Nombre;
                estudiante.IdEstudiante = temo.IdEstudiante;
                estudiante.PrimerApellido = temo.PrimerApellido;
                estudiante.SegundoApellido = temo.SegundoApellido;
                estudiante.CorreoElectronico = temo.CorreoElectronico;
           
        

                List < CitaXEstudiante> tempCitas = bd.CitaXEstudiantes.Where(x => x.IdCita == temo.IdEstudiante).ToList();

                //estudiante.CitaXEstudiantes = temo.CitaXEstudiantes;
                foreach (var cita in tempCitas)
                {
                    ICita tempCita = new ICita();
                    estudiante.citas.Add(tempCita.GetCita(cita.IdCita));

                }
                
                return estudiante;
            }*/

            return estudiante;
        }

        public List<IEstudiante> getEstudiantes()
        {

            //var temo = bd.Estudiantes.Select(x => x).ToList();
            List<IEstudiante> arrayEstudiantes = new List<IEstudiante>();
            /*
            for (int i = 0; i < temo.Count; i++)
            {
                IEstudiante estudiante = new IEstudiante();
                estudiante.Nombre = temo[i].Nombre;
                estudiante.IdEstudiante = temo[i].IdEstudiante;
                estudiante.PrimerApellido = temo[i].PrimerApellido;
                estudiante.SegundoApellido = temo[i].SegundoApellido;
                estudiante.CorreoElectronico = temo[i].CorreoElectronico;

                arrayEstudiantes.Add(estudiante);

            }*/

            return arrayEstudiantes;

        } 


        }

        
       
    }
