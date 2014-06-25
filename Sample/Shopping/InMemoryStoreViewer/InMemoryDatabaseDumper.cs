using Newtonsoft.Json;
using System;
using System.IO;

namespace InMemoryStoreViewer
{

    public class InMemoryDatabaseDumper
    {
        public static void DumpDatabaseToFile(IServiceProvider services, string path)
        {
            var inMemoryInfo = new InMemoryInformation(services, new ProjectInformationRetriever(services));
            var jsonString = JsonConvert.SerializeObject(inMemoryInfo.GetInMemoryInformation());
            File.WriteAllText(path, jsonString);
        }
    }
}