﻿using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mvc.Controllers;
using Mvc.TagHelpers.Base;


namespace Mvc.TagHelpers
{
    public class ItemCreateTagHelper : ItemLinkTagHelperBase
    {
        public ItemCreateTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory)
            : base(contextAccessor, urlHelperFactory) { }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            BuildContent(output, nameof(HomeController.Create), "text-success", "Create new", "plus");
        }
    }
}
