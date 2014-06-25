using InMemoryStoreViewer;
using Microsoft.AspNet.Mvc;


namespace WebApp.Areas.InMemoryStoreViewer.Controllers
{
    [Area("InMemoryStoreViewer")]
    public class HomeController : Controller
    {
        InMemoryInformation inMemortyInfo;
        public HomeController(InMemoryInformation inMemortyInfo)
        {
            this.inMemortyInfo = inMemortyInfo;
        }

        // GET: /InMemoryStoreViewer/
        // GET: /InMemoryStoreViewer/Home
        // GET: /InMemoryStoreViewer/Home/Index
        public IActionResult Index()
        {
            var store = inMemortyInfo.GetInMemoryInformation();
            return View(store);
        }
    }
}
