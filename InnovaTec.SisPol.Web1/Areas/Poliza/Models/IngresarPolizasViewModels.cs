using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InnovaTec.SisPol.Infraestructure.Constants;

namespace InnovaTec.SisPol.Web1.Areas.Poliza.Models
{
    [MetadataType(typeof(IngresarPolizas))]
    public class IngresarPolizasViewModels
    {
        public int ncat_codigo { get; set; }
        public string ccat_descripcion { get; set; }
        public IEnumerable<SelectListItem> Categoria { get; set; }
        public int n_desde { get; set; }
        public int n_hasta { get; set; }
        public string cpol_formato1 { get; set; }
        public string cpol_formato2 { get; set; }
        public int npol_desde { get; set; }
        public int npol_hasta { get; set; }
        public string d_fecingreso { get; set; }
        public int n_cantidadPolizas { get; set; }
        public int n_diasVigencia { get; set; }
        public sealed class IngresarPolizas
        {
            [Display(Name = "Categorías")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public int ncat_codigo { get; set; }

            [Display(Name = "Formulario - desde")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            //[MaxLength(10, ErrorMessage = Validacion.LongitudMaxima)]
            public int n_desde { get; set; }

            [Display(Name = "Formulario - hasta")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            //[MaxLength(10, ErrorMessage = Validacion.LongitudMaxima)]
            public int n_hasta { get; set; }

            [Display(Name = "serie 1 poliza")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [StringLength(2, ErrorMessage = Validacion.LongitudFija)]
            public string cpol_formato1 { get; set; }

            [Display(Name = "serie 2 poliza")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [StringLength(7, ErrorMessage = Validacion.LongitudFija)]
            public string cpol_formato2 { get; set; }

            [Display(Name = "Nro. Poliza desde")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            //[MaxLength(5, ErrorMessage = Validacion.LongitudMaxima)]
            public int npol_desde { get; set; }

            [Display(Name = "Nro. Poliza hasta")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            //[MaxLength(5, ErrorMessage = Validacion.LongitudMaxima)]
            public int npol_hasta { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
            [Display(Name = "Fecha Ingreso")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            public string d_fecingreso { get; set; }

            [Display(Name = "cantidad pólizas")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            //[MaxLength(3, ErrorMessage = Validacion.LongitudMaxima)]
            public int? n_cantidadPolizas { get; set; }

            [Display(Name = "días de vigencia")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            //[MaxLength(3, ErrorMessage = Validacion.LongitudMaxima)]
            public int n_diasVigencia { get; set; }
        }
    }
}