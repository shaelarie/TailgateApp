using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TailgateLive.Startup))]
namespace TailgateLive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
