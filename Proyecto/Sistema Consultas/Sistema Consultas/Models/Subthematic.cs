//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_Consultas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subthematic
    {
        public int id_subthematic { get; set; }
        public int id_thematic { get; set; }
        public string name { get; set; }
    
        public virtual Thematic Thematic { get; set; }
    }
}
