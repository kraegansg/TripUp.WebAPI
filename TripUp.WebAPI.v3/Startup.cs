using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TripUp.WebAPI.v3.Startup))]
namespace TripUp.WebAPI.v3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
