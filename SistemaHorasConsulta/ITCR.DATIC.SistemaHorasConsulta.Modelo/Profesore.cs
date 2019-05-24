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
    using System.Collections.Generic;
    
    public partial class Profesore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesore()
        {
            this.Citas = new HashSet<Cita>();
            this.Horarios = new HashSet<Horario>();
            this.Tematicas = new HashSet<Tematica>();
        }
    
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string CorreoElectronico { get; set; }
        public string Especialidades { get; set; }
        public int IdLugar { get; set; }
        public byte[] Foto { get; set; }
    
        public virtual Lugare Lugare { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Citas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario> Horarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tematica> Tematicas { get; set; }
    }
}