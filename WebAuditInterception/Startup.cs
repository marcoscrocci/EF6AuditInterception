using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAuditInterception.Startup))]
namespace WebAuditInterception
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
