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

            var str = "exec Pr_Lugar_Insertar  @NombreLugar = '" + nombre+"'";
            var result = bd.Database.ExecuteSqlCommand(str);


        }


        public void eliminarLugar(int id)
        {
    
            var str = "exec Pr_Lugar_Eliminar  @IdLugar= " + id.ToString();
            var result = bd.Database.ExecuteSqlCommand(str);

        }

        public void editarLugar(int id, string nombre)

        { 
            var str = "exec Pr_Lugar_Editar @IdLugar = "+id.ToString()+", @Nombre = '" + nombre + "'";
            var result = bd.Database.ExecuteSqlCommand(str);

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
