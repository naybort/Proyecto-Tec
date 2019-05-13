using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace API.Models
{
    public class ITematica:Tematica
    {
        ConexionBD bd = new ConexionBD();
        public ITematica getTematica(int id)
        {
            //Tematica temo = bd.Tematicas.FirstOrDefault(x => x.IdTematica == id);
            ITematica tematica = new ITematica();
            /*
            if(temo != null)
            {
                tematica.IdTematica = temo.IdTematica;
                tematica.NombreTematica = temo.NombreTematica;
            }
            
            */
            return tematica;
        }

        public List<Pr_Tematicas_Consultar_Result> getTematicas()
        {
            var tematicas = bd.Database.SqlQuery<Pr_Tematicas_Consultar_Result>("Pr_Tematicas_Consultar").ToList();
            return tematicas;
        }

        public List<Pr_TematicasProfesor_Consultar_Result> getProfesoresPorTematica(int id)
        {
            var idTematica = new SqlParameter("@IdTematica", id);
            var profesores = bd.Database.SqlQuery<Pr_TematicasProfesor_Consultar_Result>("Pr_TematicasProfesor_Consultar @IdTematica", idTematica).ToList();
            //ITematica temp = new ITematica();
            //temp = temp.getTematica(idTematica);

            List<IProfesor> listaProfesores = new List<IProfesor>();
            /*
            var tematicaXprofesor = bd.ProfesorXTematicas.Where(x => x.IdTematica == temp.IdTematica).ToList();
            foreach (var profesor in tematicaXprofesor)
            {
                IProfesor temProfesor = new IProfesor();
                listaProfesores.Add(temProfesor.getProfesor(profesor.IdProfesor));

            }
            */
            return profesores;
        }

    }
}