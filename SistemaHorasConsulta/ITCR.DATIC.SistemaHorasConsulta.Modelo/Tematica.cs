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
    
    public partial class Tematica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tematica()
        {
            this.Profesores = new HashSet<Profesore>();
        }
    
        public int IdTematica { get; set; }
        public string NombreTematica { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profesore> Profesores { get; set; }
    }
}
