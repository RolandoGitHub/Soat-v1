using System.ComponentModel.DataAnnotations;
using InnovaTec.SisPol.Infraestructure.Constants;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InnovaTec.SisPol.Web1.Areas.Administracion.Models
{
    [MetadataType(typeof(TPersonal))]
    public class TPersonalViewModels
    {
        public int nper_codigo { get; set; }
        public string cper_nrodni { get; set; }
        public string cper_nombres { get; set; }
        public string cper_apepat { get; set; }
        public string cper_apemat { get; set; }
        public string cper_celular { get; set; }
        public string cper_telefono { get; set; }
        public string cper_email { get; set; }
        public string cper_sexo { get; set; }        
        public IEnumerable<SelectListItem> Sexo { get; set; }        
        public int? nper_estdato { get; set; }        
        public IEnumerable<SelectListItem> Estado { get; set; }
        public string dper_fecingreso { get; set; }

        public sealed class TPersonal
        {
            [Display(Name = "Cód. Personal")]
            public int nper_codigo { get; set; }

            [Display(Name = "D.N.I.")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [StringLength(8, ErrorMessage = Validacion.LongitudFija)]
            public string cper_nrodni { get; set; }

            [Display(Name = "Nombres")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            public string cper_nombres { get; set; }

            [Display(Name = "Ape. Paterno")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            public string cper_apepat { get; set; }

            [Display(Name = "Ape. Materno")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            public string cper_apemat { get; set; }

            [Display(Name = "Celular")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(20, ErrorMessage = Validacion.LongitudMaxima)]
            public string cper_celular { get; set; }

            [Display(Name = "Teléfono")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(20, ErrorMessage = Validacion.LongitudMaxima)]
            public string cper_telefono { get; set; }

            [Display(Name = "Correo Electrónico")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(50, ErrorMessage = Validacion.LongitudMaxima)]
            [EmailAddress]
            [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "No es un correo electrónico válido.")]
            public string cper_email { get; set; }

            [Display(Name = "Sexo")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(1, ErrorMessage = Validacion.LongitudMaxima)]
            public string cper_sexo { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
            [Display(Name = "Fec. Ingreso")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public string dper_fecingreso { get; set; }

            [Display(Name = "Estado")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public int? nper_estdato { get; set; }
        }
    }
}