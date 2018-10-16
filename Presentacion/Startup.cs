using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Presentacion.Startup))]
namespace Presentacion
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
