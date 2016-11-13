using System.Web.Mvc;

namespace InnovaTec.SisPol.Web1.Areas.Poliza
{
    public class PolizaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Poliza";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Poliza_default",
                "Poliza/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}