using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using InnovaTec.SisPol.Infraestructure.Constants;


namespace InnovaTec.SisPol.Web1.Areas.Administracion.Models
{
    [MetadataType(typeof(TPolizaFor))]
    public class TPolizaForViewModels
    {
        public int npol_codigo { get; set; }
        public string cpol_nroform { get; set; }
        public string cpol_nropoliza { get; set; }
        public string cpol_placaveh { get; set; }
        public int? npol_aniofabveh { get; set; }
        public int? npol_nroasientoveh { get; set; }
        public int? nmar_codigo { get; set; }
        public string cmar_descripcion { get; set; }
        public IEnumerable<SelectListItem> Marca { get; set; }        
        public int? nmod_codigo { get; set; }
        public string cmod_descripcion { get; set; }
        public IEnumerable<SelectListItem> Modelo { get; set; }
        public string ccat_codigo { get; set; }
        public string ccat_descripcion { get; set; }
        public IEnumerable<SelectListItem> Categoria { get; set; }
        public string cpol_seriemotor { get; set; }
        public string cpol_codmon { get; set; }
        public string cpol_desmoneda { get; set; }
        public IEnumerable<SelectListItem> Moneda { get; set; }
        public decimal? npol_precioneto { get; set; }
        public decimal? npol_porcentajecomision { get; set; }
        public decimal? npol_montocomision { get; set; }
        public decimal? npol_montoprima { get; set; }
        public int nest_codigo { get; set; }
        public string cest_descripcion { get; set; }
        public IEnumerable<SelectListItem> Estado { get; set; }
        public string dpol_fecefecto { get; set; }
        public string dpol_fectermino { get; set; }
        public int? npol_estdato { get; set; }
        public IEnumerable<SelectListItem> AltaBaja { get; set; }
        public int? npol_estreg { get; set; }
        public string caud_usrcre { get; set; }
        public DateTime daud_feccre { get; set; }
        public string caud_usract { get; set; }
        public DateTime daud_fecact { get; set; }
        
        public sealed class TPolizaFor
        {
            public int npol_codigo { get; set; }

            [Display(Name = "Nro. Formulario")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(20, ErrorMessage = Validacion.LongitudFija)]
            public string cpol_nroform { get; set; }

            [Display(Name = "Nro. Poliza")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(20, ErrorMessage = Validacion.LongitudFija)]
            public string cpol_nropoliza { get; set; }

            [Display(Name = "Placa Vehículo")]            
            [MaxLength(20, ErrorMessage = Validacion.LongitudFija)]
            public string cpol_placaveh { get; set; }

            [Display(Name = "Año Fabricación")]            
            public int npol_aniofabveh { get; set; }

            [Display(Name = "Nro. de Asientos")]
            public int npol_nroasientoveh { get; set; }

            [Display(Name = "Categoría")]
            public string ccat_codigo { get; set; }

            [Display(Name = "Marca")]            
            public int? nmar_codigo { get; set; }

            [Display(Name = "Módelo")]
            public int? nmod_codigo { get; set; }
            
            [Display(Name = "Serie Motor")]
            [MaxLength(20, ErrorMessage = Validacion.LongitudFija)]
            public string cpol_seriemotor { get; set; }

            [Display(Name = "Moneda")]
            public string cpol_codmon { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Fec. Efecto")]            
            public string dpol_fecefecto { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Fec. Termino")]            
            public string dpol_fectermino { get; set; }

            [Display(Name = "Precio Neto")]            
            public decimal? npol_precioneto { get; set; }

            [Display(Name = "Porcentaje Comisión")]            
            public decimal? npol_porcentajecomision { get; set; }

            [Display(Name = "Monto Comisión")]            
            public decimal? npol_montocomision { get; set; }

            [Display(Name = "Monto Prima")]            
            public decimal? npol_montoprima { get; set; }

            [Display(Name = "Estado Registro")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public int? npol_estdato { get; set; }

            [Display(Name = "Estado Poliza")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public int nest_codigo { get; set; }
        }
    }
}