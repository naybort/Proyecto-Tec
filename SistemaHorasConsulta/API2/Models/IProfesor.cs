using ITCR.DATIC.SistemaHorasConsulta.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace API.Models
{
    public class IProfesor : Profesore
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
        public List<Pr_Profesores_Consultar_Result> getProfesores() {
            var profesores = bd.Database.SqlQuery<Pr_Profesores_Consultar_Result>("Pr_Profesores_Consultar").ToList();
            return profesores;
        }
        public Pr_Profesores_Consultar_Result getProfesor(int id) {
            return getProfesores().Where(x=> x.IdProfesor == id).FirstOrDefault();
        }

    }
}