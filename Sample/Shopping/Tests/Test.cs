using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.DependencyInjection.Fallback;
using Moq;
using System;
using WebApp.Controllers;
using WebApp.Models;
using Xunit;

namespace Tests
{
    public class Test
    {
        private IServiceProvider serviceProvider;

        public Test()
        {
            SetupServices();
        }

        [Fact]
        public void ControllerDataViewTest()
        {

            var controller = new HomeController(serviceProvider.GetService<CustomersDbContext>());
            var result = controller.DeleteUser("fooId");

            AppAssertEqual(() => Assert.Equal(result, true));
        }

        private void AppAssertEqual(Action action)
        {
            try
            {
                action();

            }
            catch (Exception e)
            {
                var dumpWriter = serviceProvider.GetService<InMemoryStoreViewer.InMemoryDatabaseDumper>();
                dumpWriter.DumpDatabaseToFile(@"C:\Users\sujosh\Desktop\memdump.txt");
                Assert.True(false, "Test failed");
            }
        }

        private void SetupServices()
        {
            var services = new ServiceCollection();

            services.AddInMemoryStoreViewer();
            services.AddEntityFramework().AddInMemoryStore();
            services.AddTransient<CustomersDbContext>();

            // Add MVC services to the services container
            services.AddMvc();

            serviceProvider = services.BuildServiceProvider();

            // Create sample data
            CustomersDbContext.CreateSampleData(serviceProvider);
        }

        
    }

}
