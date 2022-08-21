using Microsoft.AspNetCore.Mvc;

namespace reactmvcsample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
