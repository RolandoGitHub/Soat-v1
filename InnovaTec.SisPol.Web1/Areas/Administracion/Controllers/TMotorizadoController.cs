using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using InnovaTec.SisPol.Web1.Areas.Administracion.Models;
using InnovaTec.SisPol.Model;
using InnovaTec.SisPol.Infraestructure.Constants;
using InnovaTec.SisPol.Infraestructure.Enums;
using InnovaTec.SisPol.Infraestructure.Extensions;
using InnovaTec.SisPol.Infraestructure.Functions;

namespace InnovaTec.SisPol.Web1.Areas.Administracion.Controllers
{
    public class TMotorizadoController : Controller
    {
        // GET: Administracion/TPuntoVenta
        public ActionResult Index()
        {
            return View();
        }
        public ValidationResult resultado;
        public ActionResult TMotorizado(int codigo)
        {
            TMotorizadoViewModels model = new TMotorizadoViewModels { nmot_codigo = codigo };
            Model1Container ctx = new Model1Container();
            var estado = ctx.TParamDetalle.Where(x => x.npar_codigo == 1).OrderBy(x => x.npad_orden);
            model.Estado = estado.ToSelectListItems(TipoEstadoRegistro.Activo);
            if (codigo != 0)
            {
                var dato = ctx.TMotorizado.Where(x => x.nmot_codigo == codigo).First();
                if (dato != null)
                {
                    model.nmot_codigo = dato.nmot_codigo;
                    model.cmot_dni = dato.cmot_dni;
                    model.cmot_nombres = dato.cmot_nombres;
                    model.cmot_apepat = dato.cmot_apepat;
                    model.cmot_apemat = dato.cmot_apemat;
                    model.cmot_nombrecompleto = dato.cmot_nombrecompleto;
                    model.cmot_celular = dato.cmot_celular;
                    model.cmot_telefono = dato.cmot_telefono;
                    model.cmot_email = dato.cmot_email;
                    model.cmot_sexo = dato.cmot_sexo;
                    model.dmot_fecasigna = dato.dmot_fecasigna;
                    model.cmot_placamoto = dato.cmot_placamoto;
                    model.nmot_estdato = dato.nmot_estdato;
                }
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult GuardarJSON(TMotorizadoViewModels model)
        {
            resultado = new ValidationResult();
            if (ModelState.IsValid)
            {
                Model1Container ctx = new Model1Container();
                try
                {
                    if (model.nmot_codigo == 0)
                    {
                        //Nuevo Registro
                        ObjectParameter nmot_codigo = new ObjectParameter("nmot_codigo", typeof(Int32));
                        ObjectParameter nper_codigo = new ObjectParameter("nper_codigo", typeof(Int32));

                        var result = ctx.SISPOL_GUARDAR_MOTORIZADO(model.cmot_dni, model.cmot_nombres, model.cmot_apepat, model.cmot_apemat, model.cmot_celular, model.cmot_telefono, model.cmot_email, model.cmot_sexo, model.dmot_fecasigna, model.cmot_placamoto, "SYSTEMA", nmot_codigo, nper_codigo);

                        model.nmot_codigo = Convert.ToInt32(nmot_codigo.Value);                        
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registró sactisfactoriamente";
                        resultado.Data = model.nmot_codigo;
                    }
                    else
                    {
                        //Actualiza Registro
                        var obj = ctx.TMotorizado.Where(x => x.nmot_codigo == model.nmot_codigo).First();
                        obj.cmot_nombrecompleto = model.cmot_nombrecompleto;
                        obj.cmot_dni = model.cmot_dni;
                        obj.dmot_fecasigna = model.dmot_fecasigna;
                        obj.cmot_placamoto = model.cmot_placamoto;
                        obj.nmot_estdato = model.nmot_estdato;
                        obj.nmot_estreg = model.nmot_estreg;
                        ctx.SaveChanges();
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registro sactisfactoriamente";
                        resultado.Data = model.nmot_codigo;
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
                var obj = ctx.TMotorizado.Where(x => x.nmot_codigo == codigo).First();
                obj.nmot_estreg = 0;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
            return View("Index");
        }

        public ActionResult MostrarMotorizado()
        {
            Model1Container ctx = new Model1Container();
            //var Personales = from Personal in ctx.TPersonal
            //                 select Personal;
            var Data = ctx.TMotorizado.Where(x => x.nmot_estreg == 1).ToList();
            var aaData = Data.Select(x => new[] {
                x.nmot_codigo.ToString(),
                x.cmot_nombrecompleto,
                x.cmot_dni,
                x.cmot_placamoto,
                x.nmot_codigo.ToString()
            }).ToArray();
            return Json(new { data = aaData }, JsonRequestBehavior.AllowGet);
        }
    }
}