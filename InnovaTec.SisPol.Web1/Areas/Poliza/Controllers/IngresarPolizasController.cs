using System;
using System.Linq;
using System.Web.Mvc;
using InnovaTec.SisPol.Web1.Areas.Poliza.Models;
using InnovaTec.SisPol.Model;
using InnovaTec.SisPol.Infraestructure.Constants;
using InnovaTec.SisPol.Infraestructure.Extensions;
using InnovaTec.SisPol.Infraestructure.Functions;

namespace InnovaTec.SisPol.Web1.Areas.Poliza.Controllers
{
    public class IngresarPolizasController : Controller
    {
        public ValidationResult resultado;
        // GET: Poliza/IngresarPolizas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IngresarPolizas()
        {
            IngresarPolizasViewModels model = new IngresarPolizasViewModels();
            Model1Container ctx = new Model1Container();
            var categoria = ctx.TCategoria.Where(x => x.ncat_estdato == 1 && x.ncat_estreg == 1).OrderBy(x => x.ncat_orden);
            model.Categoria = categoria.ToSelectListItems(0);
            model.d_fecingreso = string.Format("{0:dd/MM/yyyy}", DateTime.Today);            
            return View(model);
        }
        public ActionResult IngresarPolizas2(string flag)
        {
            IngresarPolizasViewModels model = new IngresarPolizasViewModels();
            Model1Container ctx = new Model1Container();
            var categoria = ctx.TCategoria.Where(x => x.ncat_estdato == 1 && x.ncat_estreg == 1).OrderBy(x => x.ncat_orden);            
            model.Categoria = categoria.ToSelectListItems(0);
            model.d_fecingreso = string.Format("{0:dd/MM/yyyy}", DateTime.Today);
            ViewBag.flag = flag;
            return View("Index",model);
        }

        [HttpPost]
        public JsonResult GenerarPoliza(IngresarPolizasViewModels model)
        {
            resultado = new ValidationResult();
            Model1Container ctx = new Model1Container();
            if (ModelState.IsValid)
            {
                try
                {
                    string ncat_codigo = model.ncat_codigo.ToString();
                    string ccat_descripcion = model.ccat_descripcion;
                    int nest_codigo = 1;
                    string cest_descripcion = "Por Derivar";
                    int? nform_desde = model.n_desde;
                    int? nform_hasta = model.n_hasta;
                    string formato = model.cpol_formato1 + "-" + model.cpol_formato2;
                    int? npol_desde = model.npol_desde;
                    int? npol_hasta = model.npol_hasta;
                    DateTime d_fecingreso = Convert.ToDateTime(model.d_fecingreso);
                    int? n_cantidadPolizas = model.n_cantidadPolizas;
                    int? n_diasVigencia = model.n_diasVigencia;

                    ctx.SISPOL_GENERAR_POLIZA(
                        ncat_codigo, ccat_descripcion, nest_codigo, cest_descripcion, nform_desde,
                        nform_hasta, formato, npol_desde, npol_hasta, d_fecingreso,
                        n_cantidadPolizas, n_diasVigencia, "SISPOL");

                    resultado.Succeeded = true;
                    resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                    resultado.Message = "La generación de pólizas tuvo éxito";
                    resultado.Data = 1;
                }
                catch (Exception e)
                {
                    resultado.Succeeded = false;
                    resultado.TypeMessage = Notificacion.TipoNotificacion.error.ToString();
                    resultado.Message = e.Message;
                    resultado.Data = 0;
                }                
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MostrarPolizas()
        {
            Model1Container ctx = new Model1Container();
            var Data = ctx.TPolizaFor.Where(x => x.npol_estreg == 1).ToList();
            var aaData = Data.Select(x => new[] {
                x.npol_codigo.ToString(),
                x.cpol_nropoliza,
                x.cpol_nroform,
                x.ccat_descripcion,
                x.cest_descripcion,
                x.npol_estdato == 1 ? "Activo":"Inactivo",
                x.npol_codigo.ToString()
            }).ToArray();
            return Json(new { data = aaData }, JsonRequestBehavior.AllowGet);
        }
    }
}