using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSupportWebApp.Startup))]
namespace DSupportWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
