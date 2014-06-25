using System;

namespace InMemoryStoreViewer
{
    public class InMemoryInformation
    {
        public IServiceProvider Services { get; set; }

        public InMemoryInformation(IServiceProvider services)
        {
            Services = services;
        }

        public InMemoryStore GetInMemoryInformation()
        {
            return null;
        }

    }
}
