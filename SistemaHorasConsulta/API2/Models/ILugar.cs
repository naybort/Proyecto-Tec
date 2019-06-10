using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ITCR.DATIC.SistemaHorasConsulta.Modelo;


namespace API.Models
{
    public class ILugar : Lugare
    {

        ConexionBD bd = new ConexionBD();


        public void lugarInsertar(string nombre)
        {
            var parametroNombre = new SqlParameter("@NombreLugar", nombre);
            var horario = bd.Database.ExecuteSqlCommand("exec Pr_Lugar_Insertar @NombreLugar", parametroNombre);

        }


        public void eliminarLugar(int id)
        {
            var idLugar = new SqlParameter("@IdLugar", id);

            var lugar = bd.Database.SqlQuery<int>("Pr_Lugar_Eliminar @IdLugar", idLugar);
            
        }

        public void editarLugar(int id, string nombre)
        {
            var idLugar = new SqlParameter("@IdLugar", id);
            var parametroNombre = new SqlParameter("@Nombre", nombre);

            var lugar = bd.Database.SqlQuery<int>("Pr_Lugar_Editar @IdLugar, @Nombre", idLugar, parametroNombre);
        }

        public Pr_Lugares_Consultar_Result getLugar(int id)
        {
            var lugares = bd.Database.SqlQuery<Pr_Lugares_Consultar_Result>("Pr_Lugares_Consultar").ToList();
            // buscar por id jeje en lugares
            return lugares[0];
        }

        public List<Pr_Lugares_Consultar_Result> getLugares()
        {
            var lugares = bd.Database.SqlQuery<Pr_Lugares_Consultar_Result>("Pr_Lugares_Consultar").ToList();
            return lugares;

        }
    }



}
