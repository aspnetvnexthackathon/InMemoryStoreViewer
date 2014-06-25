using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection.Advanced;
using WebApp.Models;
using InMemoryStoreViewer;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Http;

namespace WebApp
{
    public class Startup
    {
        public void Configure(IBuilder app)
        {
            // Set up application services
            app.UseServices(services =>
            {
                // Add EF services to the services container
                services.AddEntityFramework().AddInMemoryStore();

                // Add Identity services to the services container
                services.AddIdentity<ApplicationUser>()
                    .AddEntityFramework<ApplicationUser, ApplicationDbContext>()
                    .AddHttpSignIn();

                // Add MVC services to the services container
                services.AddMvc();

                services.AddTransient<CustomersDbContext>();
                services.AddInMemoryStoreViewer();
            });

            // Add cookie-based authentication to the request pipeline
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

            // Add MVC to the request pipeline
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "AreaRoute",
                    template: "{area}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index"});

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            CustomersDbContext.CreateSampleData(app.ApplicationServices);
        }
    }
}
