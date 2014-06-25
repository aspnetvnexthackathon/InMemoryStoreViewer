using System;
using System.Collections.Generic;

namespace InMemoryStoreViewer
{
    /// <summary>
    /// Summary description for InMemoryStore
    /// </summary>
    public class InMemoryStore
    {
        public InMemoryStore()
        {
            this.Databases = new List<InMemoryDatabase>();
        }

        public IList<InMemoryDatabase> Databases { get; set; }
    }

    public class InMemoryDatabase
    {
        public InMemoryDatabase()
        {
            this.Tables = new List<InMemoryTable>();
        }

        public string Name { get; set; }

        public IList<InMemoryTable> Tables { get; set; }
    }

    public class InMemoryTable
    {
        public InMemoryTable()
        {
            this.ColumnNames = new List<string>();
            this.Rows = new List<InMemoryTableRow>();
        }

        public string Name { get; set; }

        public IList<string> ColumnNames { get; set; }

        public IList<InMemoryTableRow> Rows { get; set; }
    }

    public class InMemoryTableRow
    {
        public InMemoryTableRow()
        {
            this.Items = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Items { get; set; }
    }
}