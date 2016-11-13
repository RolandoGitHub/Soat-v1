using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using InnovaTec.SisPol.Web1.Models;
using Mvc.JQuery.DataTables;

namespace InnovaTec.SisPol.Web1.Controllers
{
    [AllowAnonymous]
    public class MotorizadoPolizaController : Controller
    {
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;

        public MotorizadoPolizaController()
        {

        }
        // GET: MotorizadoPoliza
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MotorizadoPoliza()
        {
            //SampleDBContext db = new SampleDBContext();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();
            SelectListItem selectList = new SelectListItem()
            {
                Text = "-- Seleccione --",
                Value = "0",
                Selected = true
            };
            listSelectListItems.Add(selectList);

            selectList = new SelectListItem()
            {
                Text = "001 - Jorge Cajavilca",
                Value = "1",
                Selected = false
            };
            listSelectListItems.Add(selectList);

            selectList = new SelectListItem()
            {
                Text = "002 - Eduardo Gonzales",
                Value = "2",
                Selected = false
            };
            listSelectListItems.Add(selectList);

            selectList = new SelectListItem()
            {
                Text = "003 - Juan Perez",
                Value = "2",
                Selected = false
            };
            listSelectListItems.Add(selectList);

            /////Uso
            List<SelectListItem> listaUsoSelectListItems = new List<SelectListItem>();
            SelectListItem selectListaUso = new SelectListItem()
            {
                Text = "-- Seleccione --",
                Value = "0",
                Selected = true
            };
            listaUsoSelectListItems.Add(selectListaUso);

            selectListaUso= new SelectListItem()
            {
                Text = "01 - Particular",
                Value = "01",
                Selected = false
            };
            listaUsoSelectListItems.Add(selectListaUso);

            selectListaUso = new SelectListItem()
            {
                Text = "02 - Urbano Carga",
                Value = "02",
                Selected = false
            };
            listaUsoSelectListItems.Add(selectListaUso);

            selectListaUso = new SelectListItem()
            {
                Text = "03 - Urbano Taxi",
                Value = "03",
                Selected = false
            };
            listaUsoSelectListItems.Add(selectListaUso);

            selectListaUso = new SelectListItem()
            {
                Text = "04 - Urbano Escolar",
                Value = "04",
                Selected = false
            };
            listaUsoSelectListItems.Add(selectListaUso);


            MotorizadoPolizaViewModels motorizadoViewModel = new MotorizadoPolizaViewModels()
            {
                Motorizado = listSelectListItems,
                Uso = listaUsoSelectListItems
            };
            return View(motorizadoViewModel);
        }

        [HttpGet]
        public ActionResult MostrarPolizas()//[ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest request, string ruc, string codigo, string razonsocial, string departamento)
        {
            try
            {
                //var echo = Request.Params.Get("sEcho");
                //int totalRecords = 0;
                //var data = this._soaService.ListarSOA(request, out totalRecords, ruc, codigo, razonsocial, departamento);
                //var aaData = data.Select(x => new[] {
                //                                x.CSOA_CODE4,
                //                                x.CSOA_RAZONSOCIAL,
                //                                x.DSOA_FECHAREGISTRO.HasValue ? x.DSOA_FECHAREGISTRO.Value.ToShortDateString() : "",
                //                                x.CDPTO_NOMBRE
                //                            }).ToArray();
                var data = new List<string[]>() {
                    new string[] {"05-7900062-4189", "83866794", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800", "Ur-Ca", "23/02/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801", "Ur-Es", "23/02/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803", "Ur-Ca", "23/02/2017", "0"},
                    new string[] {"05-7900062-4189", "83866794", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800", "Ur-Ca", "23/02/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801", "Ur-Es", "23/02/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803", "Ur-Ca", "23/02/2017", "0"},
                    new string[] {"05-7900062-4189", "83866794", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800", "Ur-Ca", "23/02/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801", "Ur-Es", "23/02/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803", "Ur-Ca", "23/02/2017", "0"},
                    new string[] {"05-7900062-4189", "83866794", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800", "Ur-Ca", "23/02/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801", "Ur-Es", "23/02/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803", "Ur-Ca", "23/02/2017", "0"},
                    new string[] {"05-7900062-4189", "83866794", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798", "Pa", "23/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800", "Ur-Ca", "23/02/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801", "Ur-Es", "23/02/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802", "Ur-Ta", "23/02/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803", "Ur-Ca", "23/02/2017", "0"}
                    };
                //return Json(new { sEcho = echo, aaData = aaData, iTotalRecords = totalRecords, iTotalDisplayRecords = totalRecords }, JsonRequestBehavior.AllowGet);
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = 0, data = "", error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}