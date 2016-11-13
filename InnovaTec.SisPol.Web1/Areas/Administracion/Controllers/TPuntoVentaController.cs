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
    public class TPuntoVentaController : Controller
    {
        // GET: Administracion/TPuntoVenta
        public ActionResult Index()
        {
            return View();
        }
        public ValidationResult resultado;
        public ActionResult TPuntoVenta(int codigo)
        {
            TPuntoVentaViewModels model = new TPuntoVentaViewModels { nptv_codigo = codigo};
            Model1Container ctx = new Model1Container();            
            var estado = ctx.TParamDetalle.Where(x => x.npar_codigo == Parametro.Estado).OrderBy(x => x.npad_orden);
            model.Estado = estado.ToSelectListItems(TipoEstadoRegistro.Activo);
            if (codigo != 0)
            {
                var dato = ctx.TPuntoVenta.Where(x => x.nptv_codigo == codigo).First();
                if (dato != null)
                {
                    model.nptv_codigo = dato.nptv_codigo;
                    model.cptv_nombre = dato.cptv_nombre;
                    model.cptv_RUC= dato.cptv_RUC;
                    model.ccon_nrodni = dato.ccon_nrodni;
                    model.ccon_nombres = dato.ccon_nombres;
                    model.ccon_apepat = dato.ccon_apepat;
                    model.ccon_apemat = dato.ccon_apemat;
                    model.cptv_direccion= dato.cptv_direccion;
                    model.cptv_referencia = dato.cptv_referencia;
                    model.ccon_telefono = dato.ccon_telefono;
                    model.ccon_celular = dato.ccon_celular;
                    model.ccon_email = dato.ccon_email;
                    model.nptv_estreg = dato.nptv_estreg;
                    model.nptv_estdato = dato.nptv_estdato;
                    model.dptv_fecalta = dato.dptv_fecalta;
                    model.dptv_fecbaja = dato.dptv_fecbaja;                    
                }
            }
            return View(model);
        }
        
        [HttpPost]
        public JsonResult GuardarJSON(TPuntoVentaViewModels model)
        {
            resultado = new ValidationResult();
            if (ModelState.IsValid)
            {
                Model1Container ctx = new Model1Container();
                try
                {
                    if (model.nptv_codigo == 0)
                    {
                        //Nuevo Registro
                        TPuntoVenta tpuntoventa = new TPuntoVenta
                        {
                            nptv_codigo = model.nptv_codigo,
                            cptv_nombre = model.cptv_nombre,
                            cptv_RUC = model.cptv_RUC,
                            ccon_nrodni = model.ccon_nrodni,
                            ccon_nombres = model.ccon_nombres,
                            ccon_apepat = model.ccon_apepat,
                            ccon_apemat = model.ccon_apemat,
                            cptv_direccion = model.cptv_direccion,
                            cptv_referencia = model.cptv_referencia,
                            ccon_telefono = model.ccon_telefono,
                            ccon_celular = model.ccon_celular,
                            ccon_email = model.ccon_email,                        
                            dptv_fecalta = DateTime.Now,                            
                            nptv_estreg = 1,
                            nptv_estdato = 1
                        };
                        ctx.TPuntoVenta.Add(tpuntoventa);
                        ctx.SaveChanges();
                        model.dptv_fecalta = tpuntoventa.dptv_fecalta;
                        model.nptv_codigo = tpuntoventa.nptv_codigo;
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registró sactisfactoriamente";
                        resultado.Data = model.nptv_codigo;
                    }
                    else
                    {
                        //Actualiza Registro
                        var obj = ctx.TPuntoVenta.Where(x => x.nptv_codigo == model.nptv_codigo).First();
                        obj.cptv_nombre = model.cptv_nombre;
                        obj.cptv_RUC = model.cptv_RUC;
                        obj.ccon_nrodni = model.ccon_nrodni;
                        obj.ccon_nombres = model.ccon_nombres;
                        obj.ccon_apepat = model.ccon_apepat;
                        obj.ccon_apemat = model.ccon_apemat;
                        obj.cptv_direccion = model.cptv_direccion;
                        obj.cptv_referencia = model.cptv_referencia;
                        obj.ccon_telefono = model.ccon_telefono;
                        obj.ccon_celular = model.ccon_celular;
                        obj.ccon_email = model.ccon_email;                        
                        if (model.nptv_estdato == 1)
                        {
                            if(obj.nptv_estdato != model.nptv_estdato)
                                obj.dptv_fecalta = DateTime.Now;
                        }
                        else
                        {
                            if (obj.nptv_estdato != model.nptv_estdato)
                                obj.dptv_fecbaja = DateTime.Now;
                        }
                        obj.nptv_estdato = model.nptv_estdato;
                        obj.nptv_estreg = model.nptv_estreg;
                        ctx.SaveChanges();
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registró sactisfactoriamente";
                        resultado.Data = model.nptv_codigo;
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
                var obj = ctx.TPuntoVenta.Where(x => x.nptv_codigo == codigo).First();
                obj.nptv_estreg = 0;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
            return View("Index");
        }

        public ActionResult MostrarPuntoVentas()
        {
            Model1Container ctx = new Model1Container();
            //var Personales = from Personal in ctx.TPersonal
            //                 select Personal;
            var Data = ctx.TPuntoVenta.Where(x => x.nptv_estreg == 1).ToList();
            var aaData = Data.Select(x => new[] {
                x.nptv_codigo.ToString(),
                x.cptv_nombre,                
                x.ccon_telefono,
                x.ccon_nombres,                
                x.nptv_codigo.ToString()
            }).ToArray();
            return Json(new { data = aaData }, JsonRequestBehavior.AllowGet);
        }
    }
}