using System.Web;
using System.Web.Mvc;

namespace InnovaTec.SisPol.Web1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
