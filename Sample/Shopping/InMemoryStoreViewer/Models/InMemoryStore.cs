using System;
using System.Collections.Generic;

namespace InMemoryStoreViewer
{
    /// <summary>
    /// Summary description for InMemoryStore
    /// </summary>
    public class InMemoryStore
    {
        public IList<InMemoryDatabase> Databases { get; set; }
    }

    public class InMemoryDatabase
    {
        public string Name { get; set; }

        public IList<InMemoryTable> Tables { get; set; }
    }

    public class InMemoryTable
    {
        public string Name { get; set; }

        public IList<string> ColumnNames { get; set; }

        public IDictionary<string, string> Rows { get; set; }
    }
}