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
        public List<Pr_Profesores_Consultar_Result> getProfesores()
        {
            var profesores = bd.Database.SqlQuery<Pr_Profesores_Consultar_Result>("Pr_Profesores_Consultar").ToList();
            return profesores;
        }
        public Pr_Profesores_Consultar_Result getProfesor(int id)
        {
            return getProfesores().Where(x => x.IdProfesor == id).FirstOrDefault();
        }

        public void editarProfesor(int idProfesor, string name, string primerApellido, string segundoApellido, string usuario, string contrasena, string correoElectronico,  int idLugar, byte[] foto)
        {
            var idP = new SqlParameter("@IdProfesor", idProfesor);
            var nombre = new SqlParameter("@Nombre", name);
            var apellido1 = new SqlParameter("@PrimerApellido", primerApellido);
            var apellido2 = new SqlParameter("@SegundoApellido", segundoApellido);
            var user = new SqlParameter("@Usuario", usuario);
            var pass = new SqlParameter("@Contrasena", contrasena);
            var correo = new SqlParameter("@CorreoElectronico", correoElectronico);
          
            var lugar = new SqlParameter("@IdLugar", idLugar);
            var pic = new SqlParameter("@Foto", foto);

            var profesor = bd.Database.SqlQuery<int>("Pr_Profesor_Editar @IdProfesor,@Nombre, @PrimerApellido, @SegundoApellido,@Usuario,@Contrasena,@CorreoElectronico" +
                ",@IdLugar,@Foto", idP, nombre, apellido1, apellido2, user, pass, correo, lugar, pic);


        }

        public void eliminarProfesor(int id)
        {
            var idP = new SqlParameter("@IdProfesor", id);

            var profesor = bd.Database.SqlQuery<int>("Pr_Profesor_Eliminar @IdProfesor", idP);


        }

        public void insertarProfesor(string name, string primerApellido, string segundoApellido, string usuario, string correoElectronico,  int idLugar)
        {
            {

                var nombre = new SqlParameter("@Nombre", name);
                var apellido1 = new SqlParameter("@PrimerApellido", primerApellido);
                var apellido2 = new SqlParameter("@SegundoApellido", segundoApellido);
                var user = new SqlParameter("@Usuario", usuario);
                
                var correo = new SqlParameter("@CorreoElectronico", correoElectronico);
           
                var lugar = new SqlParameter("@IdLugar", idLugar);
                //var pic = new SqlParameter("@Foto", foto);

                //var profesor = bd.Database.SqlQuery<int>("Pr_Profesores_Insertar @Nombre, @PrimerApellido, @SegundoApellido,@Usuario,@CorreoElectronico" +
                //    ",@IdLugar", nombre, apellido1, apellido2, user, correo, lugar);

                var str = "exec Pr_Profesores_Insertar @Nombre = '"+ name + "', @PrimerApellido = '"+primerApellido+"', @SegundoApellido = '"+segundoApellido+
                    "',@Usuario='"+usuario+"',@CorreoElectronico ='" + correoElectronico + "',  @IdLugar = " + idLugar.ToString() + ",@Foto=NULL";
                var result = bd.Database.ExecuteSqlCommand(str);
            }


        }
    }
}