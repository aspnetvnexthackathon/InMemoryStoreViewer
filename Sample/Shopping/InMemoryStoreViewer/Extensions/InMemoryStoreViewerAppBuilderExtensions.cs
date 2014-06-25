using InMemoryStoreViewer;
using Microsoft.Framework.DependencyInjection;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// Summary description for InMemoryStoreViewerAppBuilderExtensions
    /// </summary>
    public static class InMemoryStoreViewerAppBuilderExtensions
    {
        public static void AddInMemoryStoreViewer(this IServiceCollection services)
        {
            services.AddSingleton<InMemoryInformation>();
            services.AddSingleton<ProjectInformationRetriever>();
            services.AddSingleton<InMemoryDatabaseDumper>();
        }
     }
}