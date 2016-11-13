using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InnovaTec.SisPol.Web1.Models
{
    public class PuntoVentaPolizaViewModels
    {
        [Display(Name = "Punto de Venta")]
        public int NPTV_CODIGO { get; set; }
        public IEnumerable<string> SelectedPuntoVenta { get; set; }
        public IEnumerable<SelectListItem> PuntoVenta { get; set; }

        public string CMOT_NOMBRECOMPLETO { get; set; }

        [Display(Name = "Estado de Poliza")]
        public int NEST_CODIGO { get; set; }
        public IEnumerable<string> SelectedEstadoPol { get; set; }
        public IEnumerable<SelectListItem> EstadoPol { get; set; }

        public string CUBI_NOMDIST { get; set; }
    }
}