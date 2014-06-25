using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class DatabaseViewModel
    {
        public string Name { get; set; }

        public List<Table> Tables { get; set; }
    }

    public class Table
    {
        public string Name { get; set; }

        public List<Row> Rows { get;set; }

        public List<Column> Columns { get; set; }
    }

    public class Row
    {
        public int Id { get; set; }
    }

    public class Column
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}