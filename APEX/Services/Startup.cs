using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(APEX.Services.StartupOwin))]

namespace APEX.Services
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
