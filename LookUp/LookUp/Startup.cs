using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LookUp.Startup))]
namespace LookUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
