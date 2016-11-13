using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using InnovaTec.SisPol.Infraestructure;
using InnovaTec.SisPol.Model;

namespace InnovaTec.SisPol.Infraestructure.Extensions
{
    public static class SelectListExtensions
    {
        //Parametrica
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<TParamDetalle> Parametrica, string codSeleccionado)
        {
            return
                Parametrica                
                    .OrderBy(x => x.npad_orden) 
                    .Select(x =>
                        new SelectListItem
                        {
                            Selected = x.cpad_valor.Equals(codSeleccionado),
                            Text = x.cpad_descripcion,
                            Value = x.cpad_valor.ToString(CultureInfo.InvariantCulture)
                        });
            
        }

        //Categorías
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<TCategoria> Categoria, decimal? codSeleccionado = null)
        {
            return
                Categoria
                    .OrderBy(x => x.ncat_orden)
                    .Select(x =>
                        new SelectListItem
                        {
                            Selected = codSeleccionado.HasValue && (x.ncat_codigo.Equals(codSeleccionado.Value)),
                            Text = x.ccat_descripcion,
                            Value = x.ncat_codigo.ToString(CultureInfo.InvariantCulture)
                        });
        }

        //Marcas
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<TMarca> Marca, decimal? codSeleccionado = null)
        {
            return
                Marca
                    .OrderBy(x => x.nmar_orden)
                    .Select(x =>
                        new SelectListItem
                        {
                            Selected = codSeleccionado.HasValue && (x.nmar_codigo.Equals(codSeleccionado.Value)),
                            Text = x.cmar_descripcion,
                            Value = x.nmar_codigo.ToString(CultureInfo.InvariantCulture)
                        });
        }

        //Modelos
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<TModelo> Modelo, decimal? codSeleccionado = null)
        {
            return
                Modelo
                    .OrderBy(x => x.nmod_orden)
                    .Select(x =>
                        new SelectListItem
                        {
                            Selected = codSeleccionado.HasValue && (x.nmod_codigo.Equals(codSeleccionado.Value)),
                            Text = x.cmod_descripcion,
                            Value = x.nmod_codigo.ToString(CultureInfo.InvariantCulture)
                        });
        }

        //Estados
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<TEstado> Modelo, decimal? codSeleccionado = null)
        {
            return
                Modelo
                    .OrderBy(x => x.nest_codigo)
                    .Select(x =>
                        new SelectListItem
                        {
                            Selected = codSeleccionado.HasValue && (x.nest_codigo.Equals(codSeleccionado.Value)),
                            Text = x.cest_desc,
                            Value = x.nest_codigo.ToString(CultureInfo.InvariantCulture)
                        });
        }
        //public static IEnumerable<SelectListItem> ToSelectListItems(
        //    this IEnumerable<TParamDetalle> Sexo, decimal? codSeleccionado = null)
        //{
        //    return
        //        Sexo
        //            .OrderBy(x => x.npad_orden).Where(x=>x.npar_codigo == 2)
        //            .Select(x =>
        //                new SelectListItem
        //                {
        //                    Selected = codSeleccionado.HasValue && (x.cpad_valor.Equals(codSeleccionado.Value)),
        //                    Text = x.cpad_descripcion,
        //                    Value = x.cpad_valor.ToString(CultureInfo.InvariantCulture)
        //                });
        //}
    }
}
