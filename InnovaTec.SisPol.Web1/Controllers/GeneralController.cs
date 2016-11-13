using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnovaTec.SisPol.Web1.Controllers
{
    public class GeneralController : Controller
    {
        // GET: General
        public ActionResult Index()
        {
            return View();
        }
    }
        public sealed class jsonTModelo
    {
        public int nmod_codigo { get; set; }
        public string cmod_descripcion { get; set; }
    }
}