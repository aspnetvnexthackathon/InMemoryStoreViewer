using InMemoryStoreViewer;
using Microsoft.AspNet.Mvc;


namespace WebApp.Areas.InMemoryStoreViewer.Controllers
{
    [Area("InMemoryStoreViewer")]
    public class HomeController : Controller
    {
        InMemoryInformation inMemortyInfo;
        InMemoryStore inMemoryStore;

        public HomeController(InMemoryInformation inMemortyInfo)
        {
            this.inMemortyInfo = inMemortyInfo;
            inMemoryStore = inMemortyInfo.GetInMemoryInformation();
        }

        // GET: /InMemoryStoreViewer/
        // GET: /InMemoryStoreViewer/Home
        // GET: /InMemoryStoreViewer/Home/Index
        public IActionResult Index()
        {
            return View(inMemoryStore);
        }

        public IActionResult ViewDatabase(int index)
        {
            return View(inMemoryStore.Databases[index]);
        }

        public IActionResult ViewTable(int index)
        {
            return View();
        }
    }
}
