#pragma checksum "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f95b5c1f7ced7c66efb8d9aa00acbb6b84ca4eab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_GetUserDetails), @"mvc.1.0.view", @"/Views/Users/GetUserDetails.cshtml")]
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
#line 1 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\_ViewImports.cshtml"
using OnlineInternshipPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\_ViewImports.cshtml"
using OnlineInternshipPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f95b5c1f7ced7c66efb8d9aa00acbb6b84ca4eab", @"/Views/Users/GetUserDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"529bd39a71a6e8e1292f783dfcdfbdba9cf9865a", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_GetUserDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineInternshipPortal.Models.Data.ViewModel.UsersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/UserImage.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("User image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
  
    ViewData["Title"] = "GetUserDetails";
    Layout = "~/Views/Shared/_DashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div>
   
    <hr />
    <br />
    <div class=""card shadow"">
        <div class=""card-header bg-primary text-white"">
            <span class=""fa fa-user-circle  text-white""></span> User information
        </div>
        <div class=""card-body"">

");
#nullable restore
#line 19 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
             if (Model.ProfilePic != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <img width=\"100\" height=\"100\"");
            BeginWriteAttribute("src", " src=\"", 541, "\"", 620, 2);
            WriteAttributeValue("", 547, "data:image/*;base64,", 547, 20, true);
#nullable restore
#line 21 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
WriteAttributeValue("", 567, Html.Raw(Convert.ToBase64String(Model.ProfilePic)), 567, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Student image\" />\r\n");
#nullable restore
#line 22 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f95b5c1f7ced7c66efb8d9aa00acbb6b84ca4eab6603", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <br />\r\n\r\n            <dl class=\"row\">\r\n               \r\n                <dt class=\"col-sm-2\">\r\n                   Name\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 36 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    Date of Birth\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 42 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayFor(model => model.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    Gender\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 48 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayFor(model => model.GenderName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    Home town\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 54 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayFor(model => model.HomeTown));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                   Region\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 60 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayFor(model => model.RegionName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 63 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayNameFor(model => model.Residence));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 66 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayFor(model => model.Residence));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 69 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 72 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                   Email Address\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 78 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                   Contact\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 84 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Users\GetUserDetails.cshtml"
               Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n\r\n            </dl>\r\n\r\n        </div>\r\n\r\n    </div>\r\n   \r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineInternshipPortal.Models.Data.ViewModel.UsersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591