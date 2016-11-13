using System.ComponentModel.DataAnnotations;
using InnovaTec.SisPol.Infraestructure.Constants;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace InnovaTec.SisPol.Web1.Areas.Administracion.Models
{
    [MetadataType(typeof(TPuntoVenta))]
    public class TPuntoVentaViewModels
    {
        public int nptv_codigo { get; set; }
        public string cptv_nombre { get; set; }                
        public string cubi_codigo { get; set; }
        public string cptv_direccion { get; set; }
        public string cptv_referencia { get; set; }
        public string ccon_telefono { get; set; }
        public int ncon_codcontacto { get; set; }
        public string ccon_celular { get; set; }
        public string ccon_nrodni { get; set; }
        public string ccon_nombres { get; set; }
        public string ccon_apepat { get; set; }
        public string ccon_apemat { get; set; }
        public string ccon_email { get; set; }
        public string cptv_RUC { get; set; }
        public DateTime? dptv_fecalta { get; set; }
        public DateTime? dptv_fecbaja { get; set; }

        public int? nptv_estdato { get; set; }
        public IEnumerable<SelectListItem> Estado { get; set; }
        public int? nptv_estreg { get; set; }        

        public string caud_usrcre { get; set; }
        public DateTime daud_feccre { get; set; }
        public string caud_usract { get; set; }
        public DateTime daud_fecact { get; set; }

        public sealed class TPuntoVenta
        {
            [Display(Name = "Cód. Punto Venta")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public int nptv_codigo { get; set; }

            [Display(Name = "Punto de Venta")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(200, ErrorMessage = Validacion.LongitudMaxima)]
            public string cptv_nombre { get; set; }

            [Display(Name = "R.U.C.")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [StringLength(11, ErrorMessage = Validacion.LongitudFija)]
            public string cptv_RUC { get; set; }

            [Display(Name = "D.N.I.")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [StringLength(8, ErrorMessage = Validacion.LongitudFija)]
            public string ccon_nrodni { get; set; }

            [Display(Name = "Nombres")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            public string ccon_nombres { get; set; }

            [Display(Name = "Ape. Paterno")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            public string ccon_apepat { get; set; }

            [Display(Name = "Ape. Materno")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            public string ccon_apemat { get; set; }

            [Display(Name = "Dirección")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(500, ErrorMessage = Validacion.LongitudMaxima)]
            public string cptv_direccion { get; set; }

            [Display(Name = "Referencia")]            
            [MaxLength(500, ErrorMessage = Validacion.LongitudMaxima)]
            public string cptv_referencia { get; set; }

            [Display(Name = "Teléfono")]            
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            public string ccon_telefono { get; set; }

            [Display(Name = "Celular")]            
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            public string ccon_celular { get; set; }
            
            [Display(Name = "Correo Electrónico")]            
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            [EmailAddress]
            [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "No es un correo electrónico válido.")]
            public string ccon_email { get; set; }
            
            [Display(Name = "Estado")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public int? nptv_estdato { get; set; }
        }
    }
}