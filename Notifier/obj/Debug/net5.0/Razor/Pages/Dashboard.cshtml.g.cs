#pragma checksum "/home/armquist/github/CS451Group1/semester-project-group-1-commerce/Notifier/Pages/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c41717fca83edd37dd05774c429e68818f60a7e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Notifier.Pages.Pages_Dashboard), @"mvc.1.0.razor-page", @"/Pages/Dashboard.cshtml")]
namespace Notifier.Pages
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
#line 1 "/home/armquist/github/CS451Group1/semester-project-group-1-commerce/Notifier/Pages/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/armquist/github/CS451Group1/semester-project-group-1-commerce/Notifier/Pages/_ViewImports.cshtml"
using Notifier;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/armquist/github/CS451Group1/semester-project-group-1-commerce/Notifier/Pages/_ViewImports.cshtml"
using Notifier.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/armquist/github/CS451Group1/semester-project-group-1-commerce/Notifier/Pages/_ViewImports.cshtml"
using Notifier.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/armquist/github/CS451Group1/semester-project-group-1-commerce/Notifier/Pages/_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/armquist/github/CS451Group1/semester-project-group-1-commerce/Notifier/Pages/_ViewImports.cshtml"
using Notifier.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c41717fca83edd37dd05774c429e68818f60a7e5", @"/Pages/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cd05cec5d49c37eee50e3cb71ce7bca229f056f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Dashboard : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/home/armquist/github/CS451Group1/semester-project-group-1-commerce/Notifier/Pages/Dashboard.cshtml"
   ViewData["Title"] = "Dashboard"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"login\">\n    <div class=\"text-center\">\n        <h1 class=\"display-4\">DASHBOARD GOES HERE</h1>\n    </div>\n</div>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591