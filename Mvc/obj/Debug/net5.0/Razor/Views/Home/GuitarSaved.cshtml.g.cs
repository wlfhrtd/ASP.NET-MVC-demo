#pragma checksum "D:\dev\cs\RAZOR and ASP.NET MVC demo\Mvc\Views\Home\GuitarSaved.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e3259e9f4d1a1f9d84c9a73fff1f16638b1f0f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GuitarSaved), @"mvc.1.0.view", @"/Views/Home/GuitarSaved.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\dev\cs\RAZOR and ASP.NET MVC demo\Mvc\Views\_ViewImports.cshtml"
using Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\dev\cs\RAZOR and ASP.NET MVC demo\Mvc\Views\_ViewImports.cshtml"
using Mvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e3259e9f4d1a1f9d84c9a73fff1f16638b1f0f9", @"/Views/Home/GuitarSaved.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa254474c328ea0773d02916e61575cd1f09a141", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GuitarSaved : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Guitar>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\dev\cs\RAZOR and ASP.NET MVC demo\Mvc\Views\Home\GuitarSaved.cshtml"
  
    ViewBag.Title = "Guitar Saved";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Guitar has been saved</h2>\r\n\r\n");
#nullable restore
#line 8 "D:\dev\cs\RAZOR and ASP.NET MVC demo\Mvc\Views\Home\GuitarSaved.cshtml"
Write(Html.DisplayForModel(Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Guitar> Html { get; private set; }
    }
}
#pragma warning restore 1591
