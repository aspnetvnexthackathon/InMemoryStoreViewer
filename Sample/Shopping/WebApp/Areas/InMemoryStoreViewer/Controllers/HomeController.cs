using Microsoft.AspNet.Mvc;


namespace WebApp.Areas.InMemoryStoreViewer.Controllers
{
    [Area("InMemoryStoreViewer")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
