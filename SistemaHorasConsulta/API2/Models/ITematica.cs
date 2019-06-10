using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace API.Models
{
    public class ITematica
    {
        public int IdProfesor { get; set; }
        public int IdTematica { get; set; }
        public string Especialidades { get; set; }

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

        public bool Asociar(ITematica tematica)
        {
            var str = "exec Pr_TematicaXProfesor_Insertar @IdTematica = " + tematica.IdTematica.ToString() + ",  @IdProfesor = " + tematica.IdProfesor.ToString() + ", @Especialidades = '" + tematica.Especialidades+"'";
            var result = bd.Database.ExecuteSqlCommand(str);

            return true;
        }

        public List<Pr_Tematicas_Consultar_Result> getTematicas()
        {
            var tematicas = bd.Database.SqlQuery<Pr_Tematicas_Consultar_Result>("Pr_Tematicas_Consultar").ToList();
            return tematicas;
        }

        public List<Pr_ProfesoresXTematica_Consultar_Result> getProfesoresPorTematica(int id)
        {
            var idTematica = new SqlParameter("@IdTematica", id);
            var profesores = bd.Database.SqlQuery<Pr_ProfesoresXTematica_Consultar_Result>("Pr_ProfesoresXTematica_Consultar @IdTematica", idTematica).ToList();
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
        public List<Pr_TematicasXProfesor_Consultar_Result> getTematicaPorProfesor(int id)
        {
            var idProfesor = new SqlParameter("@IdProfesor", id);
            var profesores = bd.Database.SqlQuery<Pr_TematicasXProfesor_Consultar_Result>("Pr_TematicasXProfesor_Consultar @IdProfesor", idProfesor).ToList();
    
        
            return profesores;
        }

        public int eliminarTematica(int id)
        {
            var idTematica = new SqlParameter("@IdTematica", id);
            var tematica = bd.Database.ExecuteSqlCommand("Pr_Tematica_Eliminar @IdTematica", idTematica);
            return tematica;
        }

        public int editarTematica(int id, string nombre, string descripcion)
        {
            var idTematica = new SqlParameter("@IdTematica", id);
            var nombreTematica = new SqlParameter("@Nombre", nombre);
            var descripcionTematica = new SqlParameter("@Descripcion", descripcion);

            var tematica = bd.Database.ExecuteSqlCommand("Pr_Tematica_Editar @IdTematica,@Nombre,@Descripcion", idTematica, nombreTematica, descripcionTematica);
            return tematica;
        }

        public int crearTematica(string nombre, string descripcion)
        {
            var nombreTematica = new SqlParameter("@NombreTematica", nombre);
            var descripcionTematica = new SqlParameter("@Descripcion", descripcion);

            var tematica = bd.Database.ExecuteSqlCommand("Pr_Tematica_Insertar @Nombre,@Descripcion", nombreTematica, descripcionTematica);
            return tematica;
        }

    }
}