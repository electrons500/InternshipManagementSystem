#pragma checksum "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07b6b34ef66237b07bfd0a79275e0738b9aad544"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_InternshipDetails), @"mvc.1.0.view", @"/Views/Admin/InternshipDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07b6b34ef66237b07bfd0a79275e0738b9aad544", @"/Views/Admin/InternshipDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"529bd39a71a6e8e1292f783dfcdfbdba9cf9865a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_InternshipDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineInternshipPortal.Models.Data.ViewModel.InternshipViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
  
    ViewData["Title"] = "InternshipDetails";
    Layout = "~/Views/Shared/_DashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Internship information</h1>
<br />
<div class=""alert alert-primary"" role=""alert"">
    Internship/internship information
</div>
<br />

<div class=""card au-card shadow-lg"">
    <div class=""card-body"">
        <div>
            <div align=""center"">
");
#nullable restore
#line 18 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                 if (Model.Companylogo != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img width=\"100\" height=\"100\"");
            BeginWriteAttribute("src", " src=\"", 563, "\"", 643, 2);
            WriteAttributeValue("", 569, "data:image/*;base64,", 569, 20, true);
#nullable restore
#line 20 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
WriteAttributeValue("", 589, Html.Raw(Convert.ToBase64String(Model.Companylogo)), 589, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"company logo\" />\r\n");
#nullable restore
#line 21 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h3><span class=\"fa fa-industry fa-2x\"></span></h3>\r\n");
#nullable restore
#line 25 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n            <br />\r\n            <table class=\"table table-bordered\">\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 32 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 35 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.CompanyId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 43 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.CompanyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 48 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 51 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.IndustryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.IndustryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 64 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.InternshipStatusId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.InternshipStatusName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 73 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.RemoteId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 76 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.RemoteName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 81 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 84 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 89 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.WorkDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 92 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.WorkDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 97 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.SkillsRequired));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 100 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.SkillsRequired));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 105 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.AdditionalInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 108 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.AdditionalInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 113 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.WhoCanApply));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 116 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.WhoCanApply));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 122 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayNameFor(model => model.DeadLineDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 125 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Admin\InternshipDetails.cshtml"
                   Write(Html.DisplayFor(model => model.DeadLineDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n\r\n\r\n            </table>\r\n\r\n            <br />\r\n\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineInternshipPortal.Models.Data.ViewModel.InternshipViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
