//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InnovaTec.SisPol.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TPolizaFor
    {
        public int npol_codigo { get; set; }
        public string cpol_nroform { get; set; }
        public string cpol_nropoliza { get; set; }
        public string cpol_placaveh { get; set; }
        public Nullable<int> npol_aniofabveh { get; set; }
        public Nullable<int> npol_nroasientoveh { get; set; }
        public Nullable<int> nmar_codigo { get; set; }
        public string cmar_descripcion { get; set; }
        public Nullable<int> nmod_codigo { get; set; }
        public string cmod_descripcion { get; set; }
        public string ccat_codigo { get; set; }
        public string ccat_descripcion { get; set; }
        public string cpol_seriemotor { get; set; }
        public string cpol_codmon { get; set; }
        public string cpol_desmoneda { get; set; }
        public Nullable<decimal> npol_precioneto { get; set; }
        public Nullable<decimal> npol_porcentajecomision { get; set; }
        public Nullable<decimal> npol_montocomision { get; set; }
        public Nullable<decimal> npol_montoprima { get; set; }
        public int nest_codigo { get; set; }
        public string cest_descripcion { get; set; }
        public Nullable<System.DateTime> dpol_fecefecto { get; set; }
        public Nullable<System.DateTime> dpol_fectermino { get; set; }
        public Nullable<System.DateTime> dpol_fecingreso { get; set; }
        public Nullable<int> npol_nrocarga { get; set; }
        public Nullable<int> npol_estdato { get; set; }
        public Nullable<int> npol_estreg { get; set; }
        public string caud_usrcre { get; set; }
        public Nullable<System.DateTime> daud_feccre { get; set; }
        public string caud_usract { get; set; }
        public Nullable<System.DateTime> daud_fecact { get; set; }
    }
}
