using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InnovaTec.SisPol.Web1.Areas.Administracion.Models;
using InnovaTec.SisPol.Model;
using InnovaTec.SisPol.Infraestructure;
using InnovaTec.SisPol.Web1.Controllers;
 
namespace InnovaTec.SisPol.Web1.Areas.Administracion.Controllers
{
    public class TPolizaForController : Controller
    {
        // GET: Administracion/TPolizaFor
        public ActionResult Index()
        {
            return View();
        }
        public ValidationResult resultado;
        public ActionResult TPolizaFor(int codigo)
        {
            TPolizaForViewModels model = new TPolizaForViewModels { npol_codigo = codigo };
            Model1Container ctx = new Model1Container();
            var altabaja = ctx.TParamDetalle.Where(x => x.npar_codigo == Parametro.Estado && x.npad_estreg == 1).OrderBy(x => x.npad_orden);
            model.AltaBaja = altabaja.ToSelectListItems(TipoEstadoRegistro.Activo);

            var categoria = ctx.TCategoria.Where(x => x.ncat_estdato == 1 && x.ncat_estreg == 1).OrderBy(x => x.ncat_orden);
            //categoria.ToSelectListItems(0).ToList().Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            model.Categoria = categoria.ToSelectListItems(0);            

            var marca = ctx.TMarca.Where(x => x.nmar_estreg == 1 && x.nmar_estdato == 1).OrderBy(x => x.nmar_orden);
            model.Marca = marca.ToSelectListItems(0);
                        
            var moneda = ctx.TParamDetalle.Where(x => x.npar_codigo == Parametro.Moneda && x.npad_estreg == 1).OrderBy(x => x.npad_orden);
            model.Moneda = moneda.ToSelectListItems("");

            var estado = ctx.TEstado.Where(x => x.nest_estreg == 1).OrderBy(x => x.nest_codigo);
            model.Estado = estado.ToSelectListItems(0);

            if (codigo != 0)
            {
                var dato = ctx.TPolizaFor.Where(x => x.npol_codigo == codigo).First();
                var modelo = ctx.TModelo.Where(x => x.nmar_codigo == dato.nmar_codigo && x.nmod_estdato == 1 && x.nmod_estreg == 1).OrderBy(x => x.nmar_codigo);
                model.Modelo = modelo.ToSelectListItems(dato.nmod_codigo);
                if (dato != null)
                {
                    model.npol_codigo = dato.npol_codigo;
                    model.cpol_nroform = dato.cpol_nroform;
                    model.cpol_nropoliza = dato.cpol_nropoliza;
                    model.cpol_placaveh = dato.cpol_placaveh;
                    model.npol_aniofabveh = dato.npol_aniofabveh;
                    model.npol_nroasientoveh = dato.npol_nroasientoveh;
                    model.nmar_codigo = dato.nmar_codigo;
                    model.cmar_descripcion = dato.cmar_descripcion;
                    model.nmod_codigo = dato.nmod_codigo;
                    model.cmod_descripcion = dato.cmod_descripcion;
                    model.ccat_codigo = dato.ccat_codigo;
                    model.ccat_descripcion = dato.ccat_descripcion;
                    model.cpol_seriemotor = dato.cpol_seriemotor;
                    model.cpol_codmon = dato.cpol_codmon;
                    model.cpol_desmoneda = dato.cpol_desmoneda;
                    model.npol_precioneto = dato.npol_precioneto;
                    model.npol_porcentajecomision = dato.npol_porcentajecomision;
                    model.npol_montocomision = dato.npol_montocomision;
                    model.npol_montoprima = dato.npol_montoprima;
                    model.nest_codigo = dato.nest_codigo;
                    model.cest_descripcion = dato.cest_descripcion;
                    model.dpol_fecefecto = string.Format("{0:dd/MM/yyyy}", dato.dpol_fecefecto);
                    model.dpol_fectermino = string.Format("{0:dd/MM/yyyy}", dato.dpol_fectermino);
                    model.npol_estdato = dato.npol_estdato;
                    model.npol_estreg = dato.npol_estreg;
                }
            }
            else
            {
                var modelo = ctx.TModelo.Where(x => x.nmar_codigo == 0 && x.nmod_estdato == 1 && x.nmod_estreg == 1).OrderBy(x => x.nmar_codigo);
                model.Modelo = modelo.ToSelectListItems(0);
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult GuardarJSON(TPolizaForViewModels model)
        {
            DateTime? fecefecto;
            DateTime? fectermino;

            if (string.IsNullOrEmpty(model.dpol_fecefecto))
                fecefecto = null;
            else
                fecefecto = Convert.ToDateTime(model.dpol_fecefecto);

            if (string.IsNullOrEmpty(model.dpol_fectermino))
                fectermino = null;
            else
                fectermino = Convert.ToDateTime(model.dpol_fectermino);

            resultado = new ValidationResult();
            if (ModelState.IsValid)
            {
                Model1Container ctx = new Model1Container();
                try
                {
                    if (model.npol_codigo == 0)
                    {
                        //Nuevo Registro
                        TPolizaFor tpolizafor = new TPolizaFor
                        {
                            npol_codigo = model.npol_codigo,
                            cpol_nroform = model.cpol_nroform,
                            cpol_nropoliza = model.cpol_nropoliza,
                            cpol_placaveh = model.cpol_placaveh,
                            npol_aniofabveh = model.npol_aniofabveh,                            
                            npol_nroasientoveh = model.npol_nroasientoveh,
                            nmar_codigo = model.nmar_codigo,
                            cmar_descripcion = model.cmar_descripcion,
                            nmod_codigo = model.nmod_codigo,
                            cmod_descripcion = model.cmod_descripcion, 
                            ccat_codigo = model.ccat_codigo,
                            ccat_descripcion = model.ccat_descripcion, 
                            cpol_seriemotor = model.cpol_seriemotor,
                            cpol_codmon = model.cpol_codmon,
                            cpol_desmoneda = model.cpol_desmoneda, 
                            npol_precioneto = model.npol_precioneto,
                            npol_porcentajecomision = model.npol_porcentajecomision,
                            npol_montocomision = model.npol_montocomision,
                            npol_montoprima = model.npol_montoprima,
                            nest_codigo = model.nest_codigo,
                            cest_descripcion = model.cest_descripcion,
                            dpol_fecefecto = fecefecto,
                            dpol_fectermino = fectermino,
                            npol_estdato = 1,
                            npol_estreg = 1                            
                        };
                        ctx.TPolizaFor.Add(tpolizafor);
                        ctx.SaveChanges();
                        model.npol_codigo = tpolizafor.npol_codigo;
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registró sactisfactoriamente";
                        resultado.Data = model.npol_codigo;
                    }
                    else
                    {
                        //Actualiza Registro
                        var obj = ctx.TPolizaFor.Where(x => x.npol_codigo == model.npol_codigo).First();                        
                        obj.cpol_nroform = model.cpol_nroform;
                        obj.cpol_nropoliza = model.cpol_nropoliza;
                        obj.cpol_placaveh = model.cpol_placaveh;
                        obj.npol_aniofabveh = model.npol_aniofabveh;
                        obj.cmar_descripcion = model.cmar_descripcion;
                        obj.npol_nroasientoveh = model.npol_nroasientoveh;
                        obj.nmar_codigo = model.nmar_codigo;
                        obj.cmar_descripcion = model.cmar_descripcion; 
                        obj.nmod_codigo = model.nmod_codigo;
                        obj.cmod_descripcion = model.cmod_descripcion; 
                        obj.ccat_codigo = model.ccat_codigo;
                        obj.ccat_descripcion = model.ccat_descripcion; 
                        obj.cpol_seriemotor = model.cpol_seriemotor;
                        obj.cpol_codmon = model.cpol_codmon;
                        obj.cpol_desmoneda = model.cpol_desmoneda; 
                        obj.npol_precioneto = model.npol_precioneto;
                        obj.npol_porcentajecomision = model.npol_porcentajecomision;
                        obj.npol_montocomision = model.npol_montocomision;
                        obj.npol_montoprima = model.npol_montoprima;
                        obj.nest_codigo = model.nest_codigo;
                        obj.cest_descripcion = model.cest_descripcion;
                        obj.dpol_fecefecto = fecefecto;
                        obj.dpol_fectermino = fectermino;
                        obj.npol_estdato = model.npol_estdato;
                        obj.npol_estreg = model.npol_estreg;
                        ctx.SaveChanges();
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registro sactisfactoriamente";
                        resultado.Data = model.npol_codigo;
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
                var obj = ctx.TPolizaFor.Where(x => x.nmar_codigo == codigo).First();
                obj.npol_estreg = 0;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
            return View("Index");
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

        [HttpPost]
        public JsonResult MostrarModelos(int NMAR_CODIGO)
        {
            try
            {
                Model1Container ctx = new Model1Container();
                var modelo = ctx.TModelo.Where(x => x.nmod_estdato == 1 && x.nmod_estreg == 1 && x.nmar_codigo == NMAR_CODIGO);
                               
                return Json(modelo.Select(x => new jsonTModelo 
                {
                    nmod_codigo = x.nmod_codigo,
                    cmod_descripcion = x.cmod_descripcion  
                }), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                //INFOSAF.Infraestructure.Log.LogHelper.WriteLogFile(e);
                return Json(null);
            }
        }
    }
}