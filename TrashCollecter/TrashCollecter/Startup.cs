using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrashCollecter.Startup))]
namespace TrashCollecter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
