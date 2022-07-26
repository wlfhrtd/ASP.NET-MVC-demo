using Microsoft.AspNetCore.Mvc;


namespace Mvc.Areas.Music.Controllers
{
    [Area("Music")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
