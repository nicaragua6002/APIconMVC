//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIconMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Denuncia
    {
        public int Id { get; set; }
        public string CodCategoria { get; set; }
        public string Tipologia { get; set; }
        public string Departamento { get; set; }
        public short Cantidad { get; set; }
        public short CasosResuelto { get; set; }
        public short Annio { get; set; }
    }
}
