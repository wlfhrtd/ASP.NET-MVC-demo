using Microsoft.AspNetCore.Mvc;


namespace Mvc.Areas.Collaboration.Controllers
{
    [Area("Collaboration")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
