using InMemoryStoreViewer;
using Microsoft.AspNet.Mvc;
using System;

namespace WebApp
{
    /// <summary>
    /// Summary description for DataViewer
    /// </summary>
    public class DataViewerController : Controller
    {
        public InMemoryInformation Information { get; set; }

        public DataViewerController(InMemoryInformation information)
	    {
            Information = information;
	    }

        public IActionResult Index()
        {
            var str = Information.GetInMemoryInformation();

            return View();
        }
    }
}