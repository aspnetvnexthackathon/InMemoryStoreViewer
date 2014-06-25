using Microsoft.AspNet.Mvc;
using System;
using WebApp.Models;
using System.Linq;
using InMemoryStoreViewer;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        CustomersDbContext dbContext;
        public HomeController(CustomersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var user = dbContext.Customers.FirstOrDefault();
            return View(dbContext.Customers);
        }

        public IActionResult DatabaseViewer()
        {
            InMemoryStore store = new InMemoryStore();

            InMemoryDatabase db = new InMemoryDatabase();

            InMemoryTable customers = new InMemoryTable();
            customers.ColumnNames.Add("Id");
            customers.ColumnNames.Add("Name");

            InMemoryTableRow row1 = new InMemoryTableRow();
            row1.Items["Id"] = "1";
            row1.Items["Name"] = "John";

            InMemoryTableRow row2 = new InMemoryTableRow();
            row2.Items["Id"] = "2";
            row2.Items["Name"] = "Mike";

            customers.Rows.Add(row1);
            customers.Rows.Add(row2);

            db.Tables.Add(customers);
            store.Databases.Add(db);

            return View(store);
        }
    }
}
