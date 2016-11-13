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
    public class MotorizadoPtoVentaController : Controller 
    {
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;

        public MotorizadoPtoVentaController()
        {
        }

        public ActionResult MotorizadoPtoVenta()
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

            /////Distrito
            List<SelectListItem> listaDistritoSelectListItems = new List<SelectListItem>();
            SelectListItem selectListaDistrito = new SelectListItem()
            {
                Text = "-- Seleccione --",
                Value = "0",
                Selected = true
            };
            listaDistritoSelectListItems.Add(selectListaDistrito);

            selectListaDistrito = new SelectListItem()
            {
                Text = "15 - Comas",
                Value = "15",
                Selected = false
            };
            listaDistritoSelectListItems.Add(selectListaDistrito);

            selectListaDistrito = new SelectListItem()
            {
                Text = "14 - Los Olivos",
                Value = "14",
                Selected = false
            };
            listaDistritoSelectListItems.Add(selectListaDistrito);

            selectListaDistrito = new SelectListItem()
            {
                Text = "12 - San Martín",
                Value = "12",
                Selected = false
            };
            listaDistritoSelectListItems.Add(selectListaDistrito);


            MotorizadoPtoVentaViewModels motorizadoViewModel = new MotorizadoPtoVentaViewModels()
            {
                Motorizado = listSelectListItems,
                Distrito = listaDistritoSelectListItems 
            };

            return View(motorizadoViewModel);            
        }
        
        [HttpGet]
        public ActionResult MostrarPtosVenta()//[ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest request, string ruc, string codigo, string razonsocial, string departamento)
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
                    new string[] {"C001 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C002 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C003 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C004 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C005 - Botica El Sanador", "789-5620", "Jesús", "0" },
                    new string[] {"C006 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C007 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C008 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C009 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C010 - Botica El Sanador", "789-5620", "Jesús", "0" },
                    new string[] {"C011 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C012 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C013 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C014 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C015 - Botica El Sanador", "789-5620", "Jesús", "0" },
                    new string[] {"C016 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C017 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C018 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C019 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C020 - Botica El Sanador", "789-5620", "Jesús", "0" },
                    new string[] {"C021 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C022 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C023 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C024 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C025 - Botica El Sanador", "789-5620", "Jesús", "0" },
                    new string[] {"C026 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C027 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C028 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C029 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C030 - Botica El Sanador", "789-5620", "Jesús", "0" },
                    new string[] {"C031 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C032 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C033 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C034 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C035 - Botica El Sanador", "789-5620", "Jesús", "0" },
                    new string[] {"C036 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C037 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C038 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C039 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C040 - Botica El Sanador", "789-5620", "Jesús", "0" },
                    new string[] {"C041 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C042 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C043 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C044 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C045 - Botica El Sanador", "789-5620", "Jesús", "0" },
                    new string[] {"C046 - Bodega Ramirez", "456-7890", "Lucho", "0"},
                    new string[] {"C047 - Bodega Lupita", "560-8945", "Carlos", "0"},
                    new string[] {"C048 - Grifo El Económico", "557-2569", "Serbia", "0"},
                    new string[] {"C049 - Farmacia La Cura", "645-7890", "Salome", "0"},
                    new string[] {"C050 - Botica El Sanador", "789-5620", "Jesús", "0" }
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