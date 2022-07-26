using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Mvc.Models
{
    public class GuitarBrandViewModel
    {
        public List<SelectListItem> Brands { get; set; }

        public int SelectedBrandId { get; set; }

        public GuitarBrand SelectedBrand { get; set; }
    }
}
