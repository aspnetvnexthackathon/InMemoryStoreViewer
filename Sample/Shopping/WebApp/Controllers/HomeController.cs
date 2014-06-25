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
       public CustomersDbContext dbContext { get; set; }

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

        public IActionResult CreateData()
        {
            Customer cust1 = new Customer();
            cust1.Id = 1;
            cust1.Name = "Mike";

            Customer cust2 = new Customer();
            cust2.Id = 2;
            cust2.Name = "John";

            dbContext.Customers.Add(cust1);
            dbContext.Customers.Add(cust2);
            dbContext.SaveChanges();

            Order order1 = new Order();
            order1.Customer = cust1;
            order1.CustomerId = cust1.Id;
            order1.Id = 1;
            order1.OrderedDate = DateTime.UtcNow;

            Order order2 = new Order();
            order2.Customer = cust2;
            order2.CustomerId = cust2.Id;
            order2.Id = 1;
            order2.OrderedDate = DateTime.UtcNow;

            dbContext.Orders.Add(order1);
            dbContext.Orders.Add(order2);
            dbContext.SaveChanges();

            return View();
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
