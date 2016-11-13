using System.ComponentModel;

namespace InnovaTec.SisPol.Infraestructure
{
    public static class Notificacion
    {
        public static class Titulo
        {
            public static string Exito
            {
                get
                {
                    return "Operación Exitosa";
                }
            }

            public static string Error
            {
                get
                {
                    return "Operación Fallida";
                }
            }

            public static string Confirmacion
            {
                get
                {
                    return "Confirmación";
                }
            }

            public static string Informacion
            {
                get
                {
                    return "Información";
                }
            }

            public static string Advertencia
            {
                get
                {
                    return "Advertencia";
                }
            }
        }

        public static class Icon
        {
            public static string Exito
            {
                get
                {
                    return "glyphicon glyphicon-ok-sign";
                }
            }

            public static string Error
            {
                get
                {
                    return "glyphicon glyphicon-warning-sign";
                }
            }

            public static string Confirmacion
            {
                get
                {
                    return "glyphicon glyphicon-question-sign";
                }
            }

            public static string Informacion
            {
                get
                {
                    return "glyphicon glyphicon-info-sign";
                }
            }

            public static string Advertencia
            {
                get
                {
                    return "glyphicon glyphicon-exclamation-sign";
                }
            }
        }

        public static class Texto
        {
            #region Resaf
            public static string Eliminacion
            {
                get
                {
                    return "¿Está seguro(a) que desea eliminar el registro?";
                }
            }

            public static string Confirmacion
            {
                get
                {
                    return "¿Está seguro(a) que desea realizar la operación?";
                }
            }

            public static string EnvioSolicitud
            {
                get
                {
                    return "¿Está seguro(a) de enviar la solicitud?";
                }
            }

            public static string ObservarHoja
            {
                get
                {
                    return "¿Está seguro(a) de observar la solicitud?";
                }
            }

            public static string HojaObservada
            {
                get
                {
                    return "La solicitud ha sido observada";
                }
            }

            public static string HojaDerivada
            {
                get
                {
                    return "La hoja de evaluación ha sido derivada";
                }
            }

            public static string DerivarHoja
            {
                get
                {
                    return "¿Está seguro(a) de derivar la hoja de evaluación?";
                }
            }

            public static string ReferenciaProcesada
            {
                get
                {
                    return "El vinculo de referencia ya ha sido procesada";
                }
            }

            /* Texto de Hoja de Evaluacion de Propuesta */
            public static string HojaPropuestaEvaluacion
            {
                get
                {
                    return "La evaluación de la propuesta ha sido <b> cerrada </b> satisfactoriamente";
                }
            }
            public static string HojaPropuestaRevision
            {
                get
                {
                    return "La revisión de la propuesta ha sido <b> cerrada </b> satisfactoriamente";
                }
            }
            /*------------------------------------------------------*/

            #endregion

            #region Ses
            public static string ColegiaturaNoEditable
            {
                get
                {
                    return "Ud. No puede agregar ninguna <b>vigencia</b> de colegiatura. Registre una <b>colegiatura</b> en la carrera a elegir.";
                }
            }
            #endregion

            public static string Error
            {
                get
                {
                    return "Ocurrió un error al realizar la operación. Intente luego";
                }
            }
        }

        public static class Ancho
        {
            public static string Largo
            {
                get
                {
                    return "600px";
                }
            }

            public static string Medio
            {
                get
                {
                    return "350px";
                }
            }
            public static string Estrecho
            {
                get
                {
                    return "300px";
                }
            }
        }

        public enum TipoNotificacion
        {
            [Description("none")]
            none,

            [Description("notice")]
            notice,

            [Description("info")]
            info,

            [Description("success")]
            success,

            [Description("error")]
            error
        }
    }
}
