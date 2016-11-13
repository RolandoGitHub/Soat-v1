using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InnovaTec.SisPol.Web1.Models
{
    public class MotorizadoPtoVentaViewModels
    {              
        [Display(Name = "Motorizado")]
        public int NMOT_CODIGO { get; set; }
        public IEnumerable<string> SelectedMotorizado { get; set; }
        public IEnumerable<SelectListItem> Motorizado { get; set; }

        public string CMOT_NOMBRECOMPLETO { get; set; }

        [Display(Name = "Distrito")]
        public int CUBI_CODIGO { get; set; }
        public IEnumerable<string> SelectedDistrito { get; set; }
        public IEnumerable<SelectListItem> Distrito { get; set; }

        public string CUBI_NOMDIST { get; set; }
    }
}