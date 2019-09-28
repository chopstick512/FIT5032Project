using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BOFOY.Startup))]
namespace BOFOY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
