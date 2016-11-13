using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaTec.SisPol.Web1.Areas.Administracion.Models;
using InnovaTec.SisPol.Model;
using InnovaTec.SisPol.Infraestructure;

namespace InnovaTec.SisPol.Web1.Areas.Administracion.Controllers
{
    public class TModeloController : Controller
    {
        // GET: Administracion/TModelo
        public ActionResult Index()
        {
            return View();
        }
        public ValidationResult resultado;
        public ActionResult TModelo(int codigo)
        {
            TModeloViewModels model = new TModeloViewModels { nmod_codigo = codigo };
            Model1Container ctx = new Model1Container();
            var estado = ctx.TParamDetalle.Where(x => x.npar_codigo == Parametro.Estado).OrderBy(x => x.npad_orden);
            model.Estado = estado.ToSelectListItems(TipoEstadoRegistro.Activo);
            if (codigo != 0)
            {
                var dato = ctx.TModelo.Where(x => x.nmod_codigo == codigo).First();
                if (dato != null)
                {
                    model.nmod_codigo = dato.nmod_codigo; 
                    model.nmar_codigo = dato.nmar_codigo;
                    model.cmod_descripcion = dato.cmod_descripcion;
                    model.cmar_descripcion = dato.cmar_descripcion;
                    model.nmod_estdato = dato.nmod_estdato;
                    model.nmod_estreg = dato.nmod_estreg;
                }
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult GuardarJSON(TModeloViewModels model)
        {
            resultado = new ValidationResult();
            if (ModelState.IsValid)
            {
                Model1Container ctx = new Model1Container();
                try
                {
                    if (model.nmod_codigo == 0)
                    {
                        //Nuevo Registro
                        TModelo tmodelo = new TModelo
                        {
                            nmod_codigo = model.nmod_codigo,
                            cmod_descripcion = model.cmod_descripcion,
                            nmar_codigo = model.nmar_codigo,
                            nmod_estreg = 1,
                            nmod_estdato = 1
                        };
                        ctx.TModelo.Add(tmodelo);
                        ctx.SaveChanges();
                        model.nmod_codigo = tmodelo.nmod_codigo;
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registró sactisfactoriamente";
                        resultado.Data = model.nmar_codigo;
                    }
                    else
                    {
                        //Actualiza Registro
                        var obj = ctx.TModelo.Where(x => x.nmod_codigo == model.nmod_codigo).First();
                        obj.cmod_descripcion = model.cmod_descripcion;
                        obj.nmar_codigo = model.nmar_codigo; 
                        obj.nmod_estdato = model.nmod_estdato;
                        obj.nmod_estreg = model.nmod_estreg;
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
                    //LogHelper.WriteLogFile(e);
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
                var obj = ctx.TModelo.Where(x => x.nmod_codigo == codigo).First();
                obj.nmod_estreg = 0;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
            return View("Index");
        }

        public ActionResult MostrarModelos()
        {
            Model1Container ctx = new Model1Container();
            var Data = ctx.TModelo.Where(x => x.nmod_estreg == 1).ToList();
            var aaData = Data.Select(x => new[] {
                x.nmod_codigo.ToString(),
                x.cmar_descripcion,
                x.cmod_descripcion,
                x.nmod_codigo.ToString()
            }).ToArray();
            return Json(new { data = aaData }, JsonRequestBehavior.AllowGet);
        }
    }
}