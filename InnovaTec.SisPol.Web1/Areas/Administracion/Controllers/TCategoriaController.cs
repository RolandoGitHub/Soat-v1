using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaTec.SisPol.Web1.Areas.Administracion.Models;
using InnovaTec.SisPol.Model;
using InnovaTec.SisPol.Infraestructure.Constants;
using InnovaTec.SisPol.Infraestructure.Functions;
using InnovaTec.SisPol.Infraestructure.Enums;
using InnovaTec.SisPol.Infraestructure.Extensions;


namespace InnovaTec.SisPol.Web1.Areas.Administracion.Controllers
{
    public class TCategoriaController : Controller
    {
        // GET: Administracion/TPuntoVenta
        public ActionResult Index()
        {
            return View();
        }
        public ValidationResult resultado;
        public ActionResult TCategoria(int codigo)
        {
            TCategoriaViewModels model = new TCategoriaViewModels { ncat_codigo = codigo };
            Model1Container ctx = new Model1Container();
            var estado = ctx.TParamDetalle.Where(x => x.npar_codigo == Parametro.Estado).OrderBy(x => x.npad_orden);
            model.Estado = estado.ToSelectListItems(TipoEstadoRegistro.Activo);
            if (codigo != 0)
            {
                var dato = ctx.TCategoria.Where(x => x.ncat_codigo == codigo).First();
                if (dato != null)
                {
                    model.ncat_codigo = dato.ncat_codigo;
                    model.ccat_descripcion = dato.ccat_descripcion;
                    model.ncat_estdato = dato.ncat_estdato;
                    model.ncat_estreg = dato.ncat_estreg;
                }
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult GuardarJSON(TCategoriaViewModels model)
        {
            resultado = new ValidationResult();
            if (ModelState.IsValid)
            {
                Model1Container ctx = new Model1Container();
                try
                {
                    if (model.ncat_codigo == 0)
                    {
                        //Nuevo Registro
                        TCategoria tcategoria = new TCategoria
                        {
                            ncat_codigo = model.ncat_codigo,
                            ccat_descripcion = model.ccat_descripcion,                            
                            ncat_estreg = 1,
                            ncat_estdato = 1
                        };
                        ctx.TCategoria.Add(tcategoria);
                        ctx.SaveChanges();                        
                        model.ncat_codigo = tcategoria.ncat_codigo;
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registró sactisfactoriamente";
                        resultado.Data = model.ncat_codigo;
                    }
                    else
                    {
                        //Actualiza Registro
                        var obj = ctx.TCategoria.Where(x => x.ncat_codigo == model.ncat_codigo).First();
                        obj.ccat_descripcion = model.ccat_descripcion;                        
                        obj.ncat_estdato = model.ncat_estdato;
                        obj.ncat_estreg = model.ncat_estreg;
                        ctx.SaveChanges();
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registro sactisfactoriamente";
                        resultado.Data = model.ncat_codigo;
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
                var obj = ctx.TCategoria.Where(x => x.ncat_codigo == codigo).First();
                obj.ncat_estreg = 0;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
            return View("Index");
        }

        public ActionResult MostrarCategorias()
        {
            Model1Container ctx = new Model1Container();            
            var Data = ctx.TCategoria.Where(x => x.ncat_estreg == 1).ToList();
            var aaData = Data.Select(x => new[] {
                x.ncat_codigo.ToString(),
                x.ccat_descripcion,
                x.ncat_codigo.ToString()
            }).ToArray();
            return Json(new { data = aaData }, JsonRequestBehavior.AllowGet);
        }
    }
}