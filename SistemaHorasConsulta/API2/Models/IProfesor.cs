using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos;


namespace API.Models
{
    public class IProfesor:Profesor
    {
        ConexionBD bd = new ConexionBD();

        public IProfesor getProfesor(int id)
        {
            Profesor temo = bd.Profesors.FirstOrDefault(x => x.IdProfesor == id);
            IProfesor profesor = new IProfesor();

            if(temo != null)
            {
                profesor.IdProfesor = temo.IdProfesor;
                profesor.Nombre = temo.Nombre;
                profesor.PrimerApellido = temo.PrimerApellido;
                profesor.SegundoApellido = temo.SegundoApellido;
                profesor.CorreoElectronico = temo.CorreoElectronico;
            }

            return profesor;
        }

        public List<IProfesor> getProfesores()
        {
            var temo = bd.Profesors.Select(x => x).ToList();
            List<IProfesor> arrayProfesores = new List<IProfesor>();

            for (int i = 0; i < temo.Count; i++)
            {
                IProfesor profesor = new IProfesor();
                profesor.CorreoElectronico = temo[i].CorreoElectronico;
                profesor.IdProfesor = temo[i].IdProfesor;
                profesor.Nombre = temo[i].Nombre;
                profesor.PrimerApellido = temo[i].PrimerApellido;
                profesor.SegundoApellido = temo[i].SegundoApellido;
                arrayProfesores.Add(profesor);

            }
            return arrayProfesores;
        }

    }
}