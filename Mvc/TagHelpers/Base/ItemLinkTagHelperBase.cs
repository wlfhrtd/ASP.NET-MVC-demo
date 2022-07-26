using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mvc.Controllers;
using Mvc.Utilities;


namespace Mvc.TagHelpers.Base
{
    public abstract class ItemLinkTagHelperBase : TagHelper
    {
        protected readonly IUrlHelper urlHelper;

        public int? ItemId { get; set; }


        protected ItemLinkTagHelperBase(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory)
        {
            urlHelper = urlHelperFactory.GetUrlHelper(contextAccessor.ActionContext);
        }


        protected void BuildContent(
            TagHelperOutput output,
            string actionName,
            string className,
            string displayText,
            string fontAwesome)
        {
            output.TagName = "a";
            var target = (ItemId.HasValue)
                ? urlHelper.Action(actionName, nameof(HomeController).OmitControllerWord(), new { id = ItemId })
                : urlHelper.Action(actionName, nameof(HomeController).OmitControllerWord());
            output.Attributes.SetAttribute("href", target);
            output.Attributes.Add("class", className);
            output.Content.AppendHtml($@"{displayText} <i class=""fas fa-{fontAwesome}""></i>");
        }
    }
}
