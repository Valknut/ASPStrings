using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tank_Platoons.Startup))]
namespace Tank_Platoons
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
