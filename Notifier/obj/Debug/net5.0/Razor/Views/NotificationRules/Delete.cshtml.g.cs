#pragma checksum "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd7141a0101230e37a2694f4284bdeef99f0edca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NotificationRules_Delete), @"mvc.1.0.view", @"/Views/NotificationRules/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd7141a0101230e37a2694f4284bdeef99f0edca", @"/Views/NotificationRules/Delete.cshtml")]
    public class Views_NotificationRules_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Notifier.Models.NotificationRule>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>NotificationRule</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.OwnerID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.OwnerID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BeforeAfterDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BeforeAfterDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TransactionDateFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TransactionDateFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BeforeAfterTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BeforeAfterTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TransactionTimeFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TransactionTimeFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LocationFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.LocationFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DepositWithdrawlFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DepositWithdrawlFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MoreLessEqualTrans));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MoreLessEqualTrans));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TransAmountFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TransAmountFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DescriptionFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "C:\Users\gogop\Downloads\semester-project-group-1-commerce-main\semester-project-group-1-commerce-main\Notifier\Views\NotificationRules\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DescriptionFilter));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </dl>
    
    <form asp-action=""Delete"">
        <input type=""hidden"" asp-for=""RuleID"" />
        <input type=""submit"" value=""Delete"" class=""btn btn-danger"" /> |
        <a asp-action=""Index"">Back to List</a>
    </form>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Notifier.Models.NotificationRule> Html { get; private set; }
    }
}
#pragma warning restore 1591
