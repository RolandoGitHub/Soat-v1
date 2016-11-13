using System;
using System.Linq;
using System.Web.Mvc;
using InnovaTec.SisPol.Web1.Areas.Administracion.Models;
using InnovaTec.SisPol.Model;
using InnovaTec.SisPol.Infraestructure.Constants;
using InnovaTec.SisPol.Infraestructure.Enums;
using InnovaTec.SisPol.Infraestructure.Extensions;
using InnovaTec.SisPol.Infraestructure.Functions;

namespace InnovaTec.SisPol.Web1.Areas.Administracion.Controllers
{
    public class TPersonalController : Controller
    {
        // GET: Administracion/TPersonal
        public ActionResult Index()
        {
            return View();
        }
        public ValidationResult resultado;
        public ActionResult TPersonal(int codigo)
        {
            TPersonalViewModels model = new TPersonalViewModels { nper_codigo = codigo, dper_fecingreso = String.Format("{0:dd/MM/yyyy}", DateTime.Now) };
            Model1Container ctx = new Model1Container();
            var sexo = ctx.TParamDetalle.Where(x => x.npar_codigo == Parametro.Sexo).OrderBy(x => x.npad_orden);
            model.Sexo = sexo.ToSelectListItems("");

            var estado = ctx.TParamDetalle.Where(x => x.npar_codigo == Parametro.Estado).OrderBy(x => x.npad_orden);
            model.Estado = estado.ToSelectListItems(TipoEstadoRegistro.Activo);
            if (codigo != 0)
            {                
                var dato = ctx.TPersonal.Where(x => x.nper_codigo == codigo).First();
                if (dato != null)
                {
                    model.nper_codigo = dato.nper_codigo;
                    model.cper_nrodni = dato.cper_dni;
                    model.cper_nombres = dato.cper_nombres;
                    model.cper_apepat = dato.cper_apepat;
                    model.cper_apemat = dato.cper_apemat;
                    model.cper_celular = dato.cper_celular;
                    model.cper_telefono = dato.cper_telefono;
                    model.cper_email = dato.cper_email;
                    model.cper_sexo = dato.cper_sexo;
                    model.dper_fecingreso = string.Format("{0:dd/MM/yyyy}", dato.dper_fecingreso);
                    model.nper_estdato = dato.nper_estdato;                    
                }
            }
            return View(model);
        }

        public ActionResult Guardar(TPersonalViewModels model)
        {
            if (ModelState.IsValid)
            {
                Model1Container ctx = new Model1Container();
                try
                {
                    if (model.nper_codigo == 0)
                    {
                        //Nuevo Registro
                        TPersonal tpersonal = new TPersonal
                        {
                            nper_codigo = model.nper_codigo,
                            cper_dni = model.cper_nrodni,
                            cper_nombres = model.cper_nombres,
                            cper_apepat = model.cper_apepat,
                            cper_apemat = model.cper_apemat,
                            cper_celular = model.cper_celular,
                            cper_telefono = model.cper_telefono,
                            cper_email = model.cper_email,
                            cper_sexo = model.cper_sexo,
                            dper_fecingreso = DateTime.Now,
                            nper_estdato = model.nper_estdato, 
                            nper_estreg = 1
                        };
                        ctx.TPersonal.Add(tpersonal);
                        ctx.SaveChanges();
                        model.dper_fecingreso = string.Format("{0:dd/MM/yyyy}",tpersonal.dper_fecingreso);
                        model.nper_codigo = tpersonal.nper_codigo;
                    }
                    else
                    {
                        //Actualizacion Registro
                        var obj = ctx.TPersonal.Where(x => x.nper_codigo == model.nper_codigo).First();
                        obj.cper_dni = model.cper_nrodni;
                        obj.cper_nombres = model.cper_nombres;
                        obj.cper_apepat = model.cper_apepat;
                        obj.cper_apemat = model.cper_apemat;
                        obj.cper_celular = model.cper_celular;
                        obj.cper_telefono = model.cper_telefono;
                        obj.cper_email = model.cper_email;
                        obj.cper_sexo = model.cper_sexo;
                        obj.dper_fecingreso = Convert.ToDateTime(model.dper_fecingreso);
                        obj.nper_estdato = model.nper_estdato; 
                        ctx.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    var error = e.Message;
                }
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult GuardarJSON(TPersonalViewModels model)
        {
            resultado = new ValidationResult();
            if (ModelState.IsValid)
            {
                Model1Container ctx = new Model1Container();
                try
                {
                    if (model.nper_codigo == 0)
                    {
                        //Nuevo Registro
                        TPersonal tpersonal = new TPersonal
                        {
                            nper_codigo = model.nper_codigo,
                            cper_dni = model.cper_nrodni,
                            cper_nombres = model.cper_nombres,
                            cper_apepat = model.cper_apepat,
                            cper_apemat = model.cper_apemat,
                            cper_celular = model.cper_celular,
                            cper_telefono = model.cper_telefono,
                            cper_email = model.cper_email,
                            cper_sexo = model.cper_sexo,
                            dper_fecingreso = Convert.ToDateTime(model.dper_fecingreso),
                            nper_estdato = model.nper_estdato,
                            nper_estreg = 1
                        };
                        ctx.TPersonal.Add(tpersonal);
                        ctx.SaveChanges();
                        model.dper_fecingreso = string.Format("{0:dd/MM/yyyy}",tpersonal.dper_fecingreso);
                        model.nper_codigo = tpersonal.nper_codigo;
                        resultado.Succeeded = true;                        
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registro sactisfactoriamente";
                        resultado.Data = model.nper_codigo;
                    }
                    else
                    {
                        //Actualiza Registro
                        var obj = ctx.TPersonal.Where(x => x.nper_codigo == model.nper_codigo).First();
                        obj.cper_dni = model.cper_nrodni;
                        obj.cper_nombres = model.cper_nombres;
                        obj.cper_apepat = model.cper_apepat;
                        obj.cper_apemat = model.cper_apemat;
                        obj.cper_celular = model.cper_celular;
                        obj.cper_telefono = model.cper_telefono;
                        obj.cper_email = model.cper_email;
                        obj.cper_sexo = model.cper_sexo;
                        obj.dper_fecingreso =Convert.ToDateTime(model.dper_fecingreso);
                        obj.nper_estdato = model.nper_estdato;
                        ctx.SaveChanges();
                        resultado.Succeeded = true;
                        resultado.TypeMessage = Notificacion.TipoNotificacion.success.ToString();
                        resultado.Message = "El dato se registro sactisfactoriamente";
                        resultado.Data = model.nper_codigo;
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
                var obj = ctx.TPersonal.Where(x => x.nper_codigo == codigo).First();
                obj.nper_estreg = 0;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
            return View("Index");
        }

        public ActionResult MostrarPersonales()
        {
            Model1Container ctx = new Model1Container();
            //var Personales = from Personal in ctx.TPersonal
            //                 select Personal;
            var Data = ctx.TPersonal.Where(x => x.nper_estreg == 1).ToList();
            var aaData = Data.Select(x => new[] {
                x.nper_codigo.ToString(),
                x.cper_dni,
                x.cper_apepat + " " + x.cper_apemat + ", " + x.cper_nombres,
                x.cper_telefono,
                String.Format("{0:dd/MM/yyyy}",x.dper_fecingreso),
                x.nper_estdato == 1 ? "Activo":"Inactivo",
                x.nper_codigo.ToString()
            }).ToArray();
            return Json(new { data = aaData }, JsonRequestBehavior.AllowGet);
        }
    }
}