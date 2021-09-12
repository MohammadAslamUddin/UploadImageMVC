using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UploadImageMVC.Startup))]
namespace UploadImageMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
