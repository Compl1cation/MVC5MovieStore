using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5MovieStore.Startup))]
namespace MVC5MovieStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
