using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InnovaTec.SisPol.Web1.Models
{
    public class MotorizadoPolizaViewModels
    {
        [Display(Name = "Motorizado")]
        public int NMOT_CODIGO { get; set; }
        public IEnumerable<string> SelectedMotorizado { get; set; }
        public IEnumerable<SelectListItem> Motorizado { get; set; }

        public string CMOT_NOMBRECOMPLETO { get; set; }

        [Display(Name = "Uso")]
        public int NSCT_CODIGO { get; set; }
        public IEnumerable<string> SelectedUso { get; set; }
        public IEnumerable<SelectListItem> Uso { get; set; }

        public string CSCT_DESCRIPCION { get; set; }
    }
}