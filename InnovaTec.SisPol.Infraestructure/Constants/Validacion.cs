using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaTec.SisPol.Infraestructure.Constants
{
    public class Validacion
    {
        public const string CampoRequerido = "El campo {0} es obligatorio.";
        public const string CampoRequeridoSelOpcion = "El campo es obligatorio. Debe seleccionar una opción.";
        public const string CampoRequeridoComplete = "El campo es obligatorio. Debe seleccionar un item de la lista.";
        public const string LongitudMaxima = "El campo {0} no debe superar los {1} caracteres.";
        public const string LongitudFija = "El campo {0} deberá ingresar {1} caracteres.";
        public const string RangoHoras = "El valor debe estar entre {0} y {1} horas.";
        public const string RangoFechas = "La fecha debe estar entre {0} y {1}.";
        public const string MinimoHoras = "La cantidad de horas debe ser mayor o igual a {0}.";
        public const string SeleccionarCentroEstudio = "Debe seleccionar  el centro de estudios.";
        public const string SeleccionarEntidad = "Debe seleccionar la entidad.";
        public const string GradoAcademicoMenorResaf = "Debe seleccionar un grado académico mayor o igual a {0}";
        public const string EstadoMenorResaf = "Debe seleccionar un estado mayor o igual a {0}";
        public const string RucSunat = "Debe buscar en SUNAT el ruc ingresado.";
        public const string FechaInvalida = "Formato de fecha no válida.";
        public const string CampoRequeridoVal = "El campo no posee valor ingresado.";
    }
}
