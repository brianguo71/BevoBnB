using Microsoft.AspNetCore.Mvc;

namespace fa21team9finalproject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
