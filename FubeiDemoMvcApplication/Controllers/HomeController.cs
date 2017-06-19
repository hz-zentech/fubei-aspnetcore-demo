using Microsoft.AspNetCore.Mvc;

namespace FubeiDemoMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
//            return View("Index");
            return Redirect("index.html");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}