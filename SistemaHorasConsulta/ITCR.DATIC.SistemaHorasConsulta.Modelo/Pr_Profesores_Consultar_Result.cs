//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITCR.DATIC.SistemaHorasConsulta.Modelo
{
    using System;
    
    public partial class Pr_Profesores_Consultar_Result
    {
        public Nullable<int> IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string stringFoto { get; set; }
        public string PrimerApellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Usuario { get; set; }
        public byte[] Foto { get; set; }
        public string SegundoApellido { get; set; }
        public string Dia { get; set; }
        public Nullable<System.TimeSpan> HoraInicio { get; set; }
        public Nullable<System.TimeSpan> HoraFinal { get; set; }
        public string NombreLugar { get; set; }
        public Nullable<int> IdHorario { get; set; }
        public Nullable<int> IdLugar { get; set; }
    }
}
