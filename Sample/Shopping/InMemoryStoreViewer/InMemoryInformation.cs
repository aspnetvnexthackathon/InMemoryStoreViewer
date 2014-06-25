using Microsoft.Data.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace InMemoryStoreViewer
{
    public class InMemoryInformation
    {
        public IServiceProvider Services { get; set; }

<<<<<<< HEAD
        public ProjectInformationRetriever InformationRetriever { get; set; }

        public InMemoryInformation(IServiceProvider services, ProjectInformationRetriever informationRetriever)
        {
            Services = services;
            InformationRetriever = informationRetriever;
=======
        public InMemoryInformation(IServiceProvider services)
        {
            Services = services;
>>>>>>> 04120339c34b12ce8a59321e8c8db2032273379e
        }

        public InMemoryStore GetInMemoryInformation()
        {
            var types = InformationRetriever.GetDbContexts();

            return null;
        }

    }

    public class ProjectInformationRetriever
    {
        public IServiceProvider AppServices { get; set; }

        public ProjectInformationRetriever(IServiceProvider services)
        {
            AppServices = services;
        }

        /// <summary>
        /// Get list of Dbcontext files in the application
        /// </summary>
        /// <returns></returns>
        public IList GetDbContexts()
        {
            var classList = new ArrayList();

            foreach (var assemblyName in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    Assembly assembly = Assembly.Load(assemblyName.FullName);

                    foreach (var classType in assembly.GetTypes())
                    {
                        if (classType.BaseType != null && classType.BaseType.Equals(typeof(DbContext)))
                        {
                            var contxt = AppServices.GetService(classType);

                            classList.Add(contxt);
                        }
                    }
                } catch(Exception e)
                {
                    continue;
                }
            }

            return classList;
        }
    }
}
