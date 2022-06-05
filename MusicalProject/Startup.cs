using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicalProject.Startup))]
namespace MusicalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
