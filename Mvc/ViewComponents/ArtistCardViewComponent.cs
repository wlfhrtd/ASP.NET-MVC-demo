using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using System.Threading.Tasks;


namespace Mvc.ViewComponents
{
    public class ArtistCardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Artist artist)
        {
            return View(artist);
        }
    }
}
