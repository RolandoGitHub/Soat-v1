using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InnovaTec.SisPol.Web1.Areas.Administracion.Models;
using InnovaTec.SisPol.Model;
using InnovaTec.SisPol.Infraestructure.Functions;
using InnovaTec.SisPol.Infraestructure.Enums;
using InnovaTec.SisPol.Infraestructure.Extensions;
using InnovaTec.SisPol.Infraestructure.Constants;

namespace InnovaTec.SisPol.Web1.Areas.Administracion.Controllers
{
    public class TMarcaController : Controller
    {
        // GET: Administracion/TMarca
        public ActionResult Index()
        {
            return View();
        }
        public ValidationResult resultado;
        public ActionResult TMarca(int codigo)
        {
            TMarcaViewModels model = new TMarcaViewModels { nmar_codigo = codigo };
            Model1Container ctx = new Model1Container();
            var estado = ctx.TParamDetalle.Where(x => x.npar_codigo == Parametro.Estado).OrderBy(x => x.npad_orden);
            model.Estado = estado.ToSelectListItems(TipoEstadoRegistro.Activo);
            if (codigo != 0)
            {
                var dato = ctx.TMarca.Where(x => x.nmar_codigo == codigo).First();
                if (dato != null)
                {
                    model.nmar_codigo = dato.nmar_codigo;
                    model.cmar_descripcion = dato.cmar_descripcion;
                    model.nmar_estdato = dato.nmar_estdato;
                    model.nmar_estreg = dato.nmar_estreg;
                }
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult GuardarJSON(TMarcaViewModels model)
        {
            resultado = new ValidationResult();
            if (ModelState.IsValid)
            {
                Model1Container ctx = new Model1Container();
                try
                {
                    if (model.nmar_codigo == 0)
                    {
                        //Nuevo Registro
                        TMarca tmarca = new TMarca
                        {
                            nmar_codigo = model.nmar_codigo,
                            cmar_descripcion = model.cmar_descripcion,                            
                            nmar_estreg = 1,
                            nmar_estdato = 1
                        };
                        ctx.TMarca.Add(tmarca);
                        ctx.SaveChanges();                        
                        model.nmar_codigo = tmarca.nmar_codigo;
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registró sactisfactoriamente";
                        resultado.Data = model.nmar_codigo;
                    }
                    else
                    {
                        //Actualiza Registro
                        var obj = ctx.TMarca.Where(x => x.nmar_codigo == model.nmar_codigo).First();
                        obj.cmar_descripcion = model.cmar_descripcion;                        
                        obj.nmar_estdato = model.nmar_estdato;
                        obj.nmar_estreg = model.nmar_estreg;
                        ctx.SaveChanges();
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registro sactisfactoriamente";
                        resultado.Data = model.nmar_codigo;
                    }
                    return Json(resultado, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {                    
                    //Ocurrio un error
                    resultado.Succeeded = false;
                    resultado.TypeMessage = Notificacion.TipoNotificacion.error.ToString();
                    resultado.Message = e.Message;
                    return Json(resultado, JsonRequestBehavior.AllowGet);
                }
            }
            //Ocurrio un error
            resultado.Succeeded = false;
            resultado.TypeMessage = Notificacion.TipoNotificacion.error.ToString();
            resultado.Message = "Ocurrio un error\n hay Un dato no valido";
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DarDeBaja(int codigo)
        {
            Model1Container ctx = new Model1Container();
            try
            {
                var obj = ctx.TMarca.Where(x => x.nmar_codigo == codigo).First();
                obj.nmar_estreg = 0;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
            return View("Index");
        }

        public ActionResult MostrarMarcas()
        {
            Model1Container ctx = new Model1Container();            
            var Data = ctx.TMarca.Where(x => x.nmar_estreg == 1).ToList();
            var aaData = Data.Select(x => new[] {
                x.nmar_codigo.ToString(),
                x.cmar_descripcion,
                x.nmar_codigo.ToString()
            }).ToArray();
            return Json(new { data = aaData }, JsonRequestBehavior.AllowGet);
        }
    }
}