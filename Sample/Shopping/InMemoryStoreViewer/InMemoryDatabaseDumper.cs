using Newtonsoft.Json;
using System;
using System.IO;

namespace InMemoryStoreViewer
{

    public class InMemoryDatabaseDumper
    {
        public IServiceProvider ServiceProvider { get; set; }

        public InMemoryDatabaseDumper(IServiceProvider services)
        {
            ServiceProvider = services;
        }

        public void DumpDatabaseToFile(string path)
        {
            var inMemoryInfo = ServiceProvider.GetService(typeof(InMemoryInformation)) as InMemoryInformation;

            var jsonString = JsonConvert.SerializeObject(inMemoryInfo.GetInMemoryInformation(), new JsonSerializerSettings() { Formatting=Formatting.Indented});

            File.AppendAllText(path, jsonString);
        }
    }
}