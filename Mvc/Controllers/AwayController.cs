using Microsoft.AspNetCore.Mvc;


namespace Mvc.Controllers
{
    public class AwayController : Controller
    {
        public IActionResult Somewhere()
        {
            ViewBag.Message = "AwayController.Somewhere()";
            return View();
        }
    }
}
