using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using pjo_api;

[assembly: OwinStartup(typeof(Startup))]

namespace pjo_api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            // enable cors origin requests
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ConfigureAuth(app);
        }
    }
}
