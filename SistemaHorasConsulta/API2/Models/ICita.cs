using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos;

namespace API.Models
{
    public class ICita:Cita
    {
        ConexionBD bd = new ConexionBD();
        public ILugar lugarCita = new ILugar();

        public ICita GetCita(int id)
        {
            Cita cita = bd.Citas.FirstOrDefault(x => x.IdCita == id);
            ICita temoCita = new ICita();

            if(cita != null)
            {
                ILugar lugar = new ILugar();
                temoCita.IdCita = cita.IdCita;
                temoCita.IdHorario = cita.IdHorario;
                temoCita.IdLugar = cita.IdLugar;
                Lugar TempLugar = lugar.getLugar(temoCita.IdLugar);
                temoCita.lugarCita.IdLugar = TempLugar.IdLugar;
                temoCita.lugarCita.Nombre = TempLugar.Nombre;
            }

            return temoCita;
        }

        public List<ICita> getCitas()
        {
            var temo = bd.Citas.Select(x => x).ToList();
            List<ICita> arrayCitas = new List<ICita>();
            for (int i = 0; i < temo.Count; i++)
            {
                ICita cita = new ICita();
                cita.IdCita = temo[i].IdCita;
                cita.IdHorario = temo[i].IdHorario;
                cita.IdLugar = temo[i].IdLugar;
                ILugar lugar = new ILugar();
                Lugar TempLugar = lugar.getLugar(temo[i].IdLugar);
                cita.lugarCita.IdLugar = TempLugar.IdLugar;
                cita.lugarCita.Nombre = TempLugar.Nombre;

                arrayCitas.Add(cita);
            }

            return arrayCitas;
        }
        public void guardarCita(ICita cita)
        {
            Cita tempCita = new Cita();

            tempCita.IdHorario = cita.IdHorario;
            tempCita.IdLugar = cita.IdLugar;

            bd.Citas.Add(tempCita);
            bd.SaveChanges();
        }


    }
}