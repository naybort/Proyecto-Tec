using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos;

namespace API.Models
{
    public class ITematica:Tematica
    {
        ConexionBD bd = new ConexionBD();
        public ITematica getTematica(int id)
        {
            Tematica temo = bd.Tematicas.FirstOrDefault(x => x.IdTematica == id);
            ITematica tematica = new ITematica();

            if(temo != null)
            {
                tematica.IdTematica = temo.IdTematica;
                tematica.NombreTematica = temo.NombreTematica;
            }
            

            return tematica;
        }

        public List<ITematica> getTematicas()
        {
            var temo = bd.Tematicas.Select(x => x).ToList();
            List<ITematica> arrayTematicas = new List<ITematica>();

            for (int i = 0; i < temo.Count; i++)
            {
                ITematica tematica = new ITematica();
                tematica.IdTematica = temo[i].IdTematica;
                tematica.NombreTematica = temo[i].NombreTematica;
                arrayTematicas.Add(tematica);

            }

            return arrayTematicas;
        }

        public List<IProfesor> getProfesoresPorTematica(int idTematica)
        {
            ITematica temp = new ITematica();
            temp = temp.getTematica(idTematica);

            List<IProfesor> listaProfesores = new List<IProfesor>();

            var tematicaXprofesor = bd.ProfesorXTematicas.Where(x => x.IdTematica == temp.IdTematica).ToList();
            foreach (var profesor in tematicaXprofesor)
            {
                IProfesor temProfesor = new IProfesor();
                listaProfesores.Add(temProfesor.getProfesor(profesor.IdProfesor));

            }

            return listaProfesores;
        }

    }
}