using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TotaraPhotographyAssociation.Startup))]
namespace TotaraPhotographyAssociation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
