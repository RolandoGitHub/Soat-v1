using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InnovaTec.SisPol.Infraestructure.Constants;

namespace InnovaTec.SisPol.Web1.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage =Validacion.CampoRequerido)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = Validacion.CampoRequerido)]
        public string Provider { get; set; }

        [Required(ErrorMessage = Validacion.CampoRequerido)]
        [Display(Name = "Código")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Recordar está página?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = Validacion.CampoRequerido)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = Validacion.CampoRequerido)]
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = Validacion.CampoRequerido)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordar?")]
        public bool RememberMe { get; set; }
    }

    [MetadataType(typeof(Register))]
    public class RegisterViewModel
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
        public sealed class Register
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

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = Validacion.CampoRequerido)]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = Validacion.CampoRequerido)]
        [StringLength(100, ErrorMessage = "Al {0} menós debe tener {2} carácteres longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y confirmación de contraseña no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = Validacion.CampoRequerido)]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }
}
