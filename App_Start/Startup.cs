using Microsoft.Owin;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(MVCTutorial.App_Start.Startup))]

namespace MVCTutorial.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "1012567851540-eqav11nkrlftg9ev71o0oaerlgpavb2o.apps.googleusercontent.com",
                ClientSecret = "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"
            });
        }
    }
}
