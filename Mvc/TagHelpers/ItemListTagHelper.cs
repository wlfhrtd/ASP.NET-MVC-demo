using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mvc.Controllers;
using Mvc.TagHelpers.Base;


namespace Mvc.TagHelpers
{
    public class ItemListTagHelper : ItemLinkTagHelperBase
    {
        public ItemListTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory)
            : base(contextAccessor, urlHelperFactory) { }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            BuildContent(output, nameof(HomeController.Index), "text-default", "Back to list", "list");
        }
    }
}
