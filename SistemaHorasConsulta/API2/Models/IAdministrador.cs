using API;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API2.Models
{
    public class IAdministrador
    {
        ConexionBD bd = new ConexionBD();
        public int IdAdministrador { get; set; }
        public string Usuario { get; set; }

        public List<IAdministrador> getAdministradores()
        {
            var admins = bd.Database.SqlQuery<IAdministrador>("Pr_Administadores_Consultar").ToList();
            return admins;
        }

        public void editarAdministrador(int idAdministrador, string usuario)
        {
    

            var str = "exec Pr_Administador_Editar  @IdAdministrador = " + idAdministrador.ToString() + ", @UsuarioNuevo = '" + usuario + "'";
            var result = bd.Database.ExecuteSqlCommand(str);


        }

        public void eliminarAdministrador(int id)
        {
  

            var str = "exec Pr_Administador_Eliminar  @IdAdministrador = " + id.ToString();
            var result = bd.Database.ExecuteSqlCommand(str);
        }

        public void insertarAdministrador( string usuario)
        {
            {

   

                var str = "exec Pr_Administadores_Insertar @usuario = '" + usuario + "'";
                var result = bd.Database.ExecuteSqlCommand(str);
            }


        }
    }
}