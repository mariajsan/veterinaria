using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(veterinaria.web.Startup))]
namespace veterinaria.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
