using Microsoft.Data.Entity;
using Microsoft.Data.Entity.InMemory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Diagnostics;

namespace InMemoryStoreViewer
{
    public class InMemoryInformation
    {
        public IServiceProvider Services { get; set; }

        public ProjectInformationRetriever InformationRetriever { get; set; }

        public InMemoryInformation(IServiceProvider services, ProjectInformationRetriever informationRetriever)
        {
            Services = services;
            InformationRetriever = informationRetriever;
        }

        public InMemoryStore GetInMemoryInformation()
        {
            var types = InformationRetriever.GetDbContexts();

            var result = new InMemoryStore();
            foreach (var dbContext in types)
            {
                var inMemoryDb = dbContext.Configuration.DataStore as InMemoryDataStore;
                if (inMemoryDb != null)
                {
                    var inMemoryDatabase = new InMemoryDatabase { Name = dbContext.Model.StorageName ?? dbContext.ToString() };
                    foreach (var entityType in dbContext.Model.EntityTypes)
                    {
                        var inMemoryTable = new InMemoryTable { Name = entityType.StorageName };
                        inMemoryTable.ColumnNames = entityType.Properties.Select(p => p.StorageName).ToList();
                        inMemoryTable.Rows = new List<InMemoryTableRow>();

                        var table = inMemoryDb.Database.GetTable(entityType);
                        foreach (var row in table)
                        {
                            var inMemoryRow = new InMemoryTableRow { Items = new Dictionary<string, string>() };
                            inMemoryTable.Rows.Add(inMemoryRow);
                            Debug.Assert(row.Count() == inMemoryTable.ColumnNames.Count, "Expecting different number of columns in a row");
                            for (int i = 0; i < row.Count(); i++)
                            {
                                inMemoryRow.Items.Add(inMemoryTable.ColumnNames[i], row[i].ToString());
                            }
                        }
                    }
                }
            }


            return result;
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
        public IList<DbContext> GetDbContexts()
        {
            var classList = new List<DbContext>();

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

                            classList.Add((DbContext)contxt);
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
