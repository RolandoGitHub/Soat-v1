using System.ComponentModel.DataAnnotations;
using InnovaTec.SisPol.Infraestructure;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace InnovaTec.SisPol.Web1.Areas.Administracion.Models
{
    [MetadataType(typeof(TMarca))]
    public class TMarcaViewModels
    {
        public int nmar_codigo { get; set; }
        public string cmar_descripcion { get; set; }
        public int? nmar_estdato { get; set; }
        public IEnumerable<SelectListItem> Estado { get; set; }
        public int? nmar_estreg { get; set; }
        public string caud_usrcre { get; set; }
        public DateTime daud_feccre { get; set; }
        public string caud_usract { get; set; }
        public DateTime daud_fecact { get; set; }

        public sealed class TMarca
        {
            [Display(Name = "Cód. Marca")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public int nmar_codigo { get; set; }

            [Display(Name = "Marca")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(20, ErrorMessage = Validacion.LongitudMaxima)]
            public string cmar_descripcion { get; set; }
            
            [Display(Name = "Estado")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public int? nmar_estdato { get; set; }
        }
    }
}