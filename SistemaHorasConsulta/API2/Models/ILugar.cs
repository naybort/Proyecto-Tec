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

        public ILugar getLugar(int id)
        {
            //Lugar temp = bd.Lugars.FirstOrDefault(x => x.IdLugar == id);
            ILugar lugar = new ILugar();
           /* if(temp != null)
            {
                lugar.IdLugar = temp.IdLugar;
                lugar.Nombre = temp.Nombre;
            }*/
            
            return lugar;
        }

        public List<ILugar> getLugares()
        {
            //var temp = bd.Lugars.Select(x => x).ToList();

            List<ILugar> listLugares = new List<ILugar>();
           /* for (int i = 0; i < temp.Count; i++)
            {
                ILugar lugar = new ILugar();
                lugar.IdLugar = temp[i].IdLugar;
                lugar.Nombre = temp[i].Nombre;

                listLugares.Add(lugar);

            }*/

            return listLugares;

        }
    }
}