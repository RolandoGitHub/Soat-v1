using System.ComponentModel.DataAnnotations;
using InnovaTec.SisPol.Infraestructure.Constants;

namespace InnovaTec.SisPol.Web1.Models
{
    [MetadataType(typeof(TUsuario))]
    public class TUsuarioViewModels
    {
        public int nusr_codigo { get; set; }
        public string cusr_dni { get; set; }
        public string cusr_nombres { get; set; }
        public string cusr_apepat { get; set; }
        public string cusr_apemat { get; set; }
        public int nusr_estdato { get; set; }
        public int nusr_estdreg { get; set; }
        public string cusr_email { get; set; }
        public string cusr_clave { get; set; }
        public string cusr_claveconfirma { get; set; }
        public sealed class TUsuario
        {
            [Display(Name = "D.N.I.")]
            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [MaxLength(20, ErrorMessage = Validacion.LongitudMaxima)]
            public string cusr_dni { get; set; }

            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [Display(Name = "Nombres")]
            public string cusr_nombres { get; set; }

            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [Display(Name = "Apellido Paterno")]
            public string cusr_apepat { get; set; }

            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [Display(Name = "Apellido Materno")]
            public string cusr_apemat { get; set; }

            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [Display(Name = "Estado")]
            public int nusr_estdato { get; set; }
            public int nusr_estdreg { get; set; }

            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [EmailAddress]
            [Display(Name = "Correo electrónico")]
            public string cusr_email { get; set; }

            [Required(ErrorMessage = Validacion.CampoRequerido)]
            [StringLength(255, ErrorMessage = "Al {0} menós debe tener {2} carácteres longitud.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string cusr_clave { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y confirmación de contraseña no coinciden.")]
            public string cusr_claveconfirma { get; set; }
        }
    }
}