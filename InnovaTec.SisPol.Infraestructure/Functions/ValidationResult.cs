
namespace InnovaTec.SisPol.Infraestructure
{
    public class ValidationResult
    {
        public ValidationResult()
        {
        }               

        public ValidationResult(string message, bool succeeded = false, object data = null, Notificacion.TipoNotificacion type = Notificacion.TipoNotificacion.info)
        {
            this.Message = message;
            this.Succeeded = succeeded;
            this.Data = data;
            this.Width = Notificacion.Ancho.Medio;
            this.TypeMessage = succeeded ? Notificacion.TipoNotificacion.success.ToString() : type.ToString();
        }

        public ValidationResult(string message, int width, bool succeeded = false, object data = null, Notificacion.TipoNotificacion type = Notificacion.TipoNotificacion.info)
        {
            this.Message = message;
            this.Succeeded = succeeded;
            this.Data = data;
            this.Width = string.Format("{0}px", width);
            this.TypeMessage = succeeded ? Notificacion.TipoNotificacion.success.ToString() : type.ToString();
        }

        public ValidationResult(string message, Notificacion.TipoNotificacion? type)
        {
            this.Message = message;
            this.TypeMessage = type.HasValue ? type.ToString() : Notificacion.TipoNotificacion.info.ToString();
        }

        public string MemberName { get; set; }

        public string Message { get; set; }

        public bool Succeeded { get; set; }

        public object Data { get; set; }

        public string TypeMessage { get; set; }

        public string Width { get; set; }

        public string Title
        {
            get
            {
                if (TypeMessage == null)
                    return Notificacion.Titulo.Informacion;

                if (TypeMessage.Equals(Notificacion.TipoNotificacion.success.ToString()))
                    return Notificacion.Titulo.Exito;

                if (TypeMessage.Equals(Notificacion.TipoNotificacion.info.ToString()))
                    return Notificacion.Titulo.Informacion;

                if (TypeMessage.Equals(Notificacion.TipoNotificacion.error.ToString()))
                    return Notificacion.Titulo.Error;

                if (TypeMessage.Equals(Notificacion.TipoNotificacion.notice.ToString()))
                    return Notificacion.Titulo.Advertencia;

                return null;
            }
        }

        public string Icon
        {
            get
            {
                if (TypeMessage == null)
                    return Notificacion.Icon.Informacion;

                if (TypeMessage.Equals(Notificacion.TipoNotificacion.success.ToString()))
                    return Notificacion.Icon.Exito;

                if (TypeMessage.Equals(Notificacion.TipoNotificacion.info.ToString()))
                    return Notificacion.Icon.Informacion;

                if (TypeMessage.Equals(Notificacion.TipoNotificacion.error.ToString()))
                    return Notificacion.Icon.Error;

                if (TypeMessage.Equals(Notificacion.TipoNotificacion.notice.ToString()))
                    return Notificacion.Icon.Advertencia;

                return null;
            }
        }
    }
}
