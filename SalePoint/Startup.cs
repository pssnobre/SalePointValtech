using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalePoint.Startup))]
namespace SalePoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
