﻿using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection.Advanced;
using WebApp.Models;

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
                services.AddEntityFramework().AddInMemoryStore().UseDbSetInitializer<CustomersDbContextInitializer>();

                // Add MVC services to the services container
                services.AddMvc();

                services.AddTransient<CustomersDbContext>();
            });

            // Add MVC to the request pipeline
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
