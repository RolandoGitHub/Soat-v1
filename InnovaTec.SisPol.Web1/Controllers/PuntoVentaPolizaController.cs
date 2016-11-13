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
    public class PuntoVentaPolizaController : Controller
    {
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;

        public PuntoVentaPolizaController()
        {
        }
        // GET: PuntoVentaPoliza
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PuntoVentaPoliza()
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
                Text = "CO01 - Bodega Ramirez",
                Value = "01",
                Selected = false
            };
            listSelectListItems.Add(selectList);

            selectList = new SelectListItem()
            {
                Text = "CO02 - Bodega Lopez",
                Value = "02",
                Selected = false
            };
            listSelectListItems.Add(selectList);

            selectList = new SelectListItem()
            {
                Text = "CO03 - Grifo El Económico",
                Value = "03",
                Selected = false
            };
            listSelectListItems.Add(selectList);

            selectList = new SelectListItem()
            {
                Text = "CO04 - Botica El Sanador",
                Value = "04",
                Selected = false
            };
            listSelectListItems.Add(selectList);

            /////EstadoPol
            List<SelectListItem> listaEstadoPolSelectListItems = new List<SelectListItem>();
            SelectListItem selectListaEstadoPol = new SelectListItem()
            {
                Text = "-- Seleccione --",
                Value = "0",
                Selected = true
            };
            listaEstadoPolSelectListItems.Add(selectListaEstadoPol);

            selectListaEstadoPol = new SelectListItem()
            {
                Text = "01 - Por Liquidar",
                Value = "01",
                Selected = false
            };
            listaEstadoPolSelectListItems.Add(selectListaEstadoPol);

            selectListaEstadoPol = new SelectListItem()
            {
                Text = "02 - Liberada",
                Value = "02",
                Selected = false
            };
            listaEstadoPolSelectListItems.Add(selectListaEstadoPol);

            selectListaEstadoPol = new SelectListItem()
            {
                Text = "03 - Liquidado",
                Value = "03",
                Selected = false
            };
            listaEstadoPolSelectListItems.Add(selectListaEstadoPol);
            
            PuntoVentaPolizaViewModels puntoVentaPolizaViewModel = new PuntoVentaPolizaViewModels()
            {
                PuntoVenta = listSelectListItems,
                EstadoPol = listaEstadoPolSelectListItems
            };
            return View(puntoVentaPolizaViewModel);
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
                    new string[] {"05-7900062-4189", "83866794",  "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795",  "24/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796",  "25/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797",  "26/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798",  "27/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799",  "28/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800",  "01/03/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801",  "02/03/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802",  "03/03/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803",  "04/04/2017", "0"},
                    new string[] {"05-7900062-4189", "83866794",  "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795",  "24/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796",  "25/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797",  "26/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798",  "27/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799",  "28/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800",  "01/03/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801",  "02/03/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802",  "03/03/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803",  "04/04/2017", "0"},
                    new string[] {"05-7900062-4189", "83866794",  "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795",  "24/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796",  "25/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797",  "26/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798",  "27/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799",  "28/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800",  "01/03/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801",  "02/03/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802",  "03/03/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803",  "04/04/2017", "0"},
                    new string[] {"05-7900062-4189", "83866794",  "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795",  "24/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796",  "25/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797",  "26/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798",  "27/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799",  "28/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800",  "01/03/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801",  "02/03/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802",  "03/03/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803",  "04/04/2017", "0"},
                    new string[] {"05-7900062-4189", "83866794",  "23/02/2017", "0"},
                    new string[] {"05-7900062-4190", "83866795",  "24/02/2017", "0"},
                    new string[] {"05-7900062-4191", "83866796",  "25/02/2017", "0"},
                    new string[] {"05-7900062-4192", "83866797",  "26/02/2017", "0"},
                    new string[] {"05-7900062-4193", "83866798",  "27/02/2017", "0"},
                    new string[] {"05-7900062-4194", "83866799",  "28/02/2017", "0"},
                    new string[] {"05-7900062-4195", "83866800",  "01/03/2017", "0"},
                    new string[] {"05-7900062-4196", "83866801",  "02/03/2017", "0"},
                    new string[] {"05-7900062-4197", "83866802",  "03/03/2017", "0"},
                    new string[] {"05-7900062-4198", "83866803",  "04/04/2017", "0"}
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