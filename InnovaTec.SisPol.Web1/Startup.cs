using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InnovaTec.SisPol.Web1.Startup))]
namespace InnovaTec.SisPol.Web1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
