using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Authentication1.Startup))]
namespace Authentication1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
