using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SLAExemptionTool.Startup))]
namespace SLAExemptionTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
