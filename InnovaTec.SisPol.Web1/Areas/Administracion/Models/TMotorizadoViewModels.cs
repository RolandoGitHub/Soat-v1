using System.ComponentModel.DataAnnotations;
using InnovaTec.SisPol.Infraestructure;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace InnovaTec.SisPol.Web1.Areas.Administracion.Models
{
    public class TMotorizadoViewModels
    {
        public int nmot_codigo { get; set; }        
        public string cmot_dni { get; set; }
        public string cmot_nombres { get; set; }
        public string cmot_apepat { get; set; }
        public string cmot_apemat { get; set; }
        public string cmot_nombrecompleto { get; set; }
        public string cmot_celular { get; set; }
        public string cmot_telefono { get; set; }
        public string cmot_email { get; set; }
        public string cmot_sexo { get; set; }
        public IEnumerable<SelectListItem> Sexo { get; set; }
        public DateTime? dmot_fecasigna { get; set; }
        public string cmot_placamoto { get; set; }
        public int? nmot_estdato { get; set; }
        public IEnumerable<SelectListItem> Estado { get; set; }
        public int? nmot_estreg { get; set; }
        public string caud_usrcre { get; set; }
        public DateTime? daud_feccre { get; set; }
        public string caud_usract { get; set; }
        public DateTime? daud_fecact { get; set; }
    }
}