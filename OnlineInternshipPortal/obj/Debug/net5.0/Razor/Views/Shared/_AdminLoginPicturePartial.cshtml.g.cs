#pragma checksum "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51acde6935775444a263dae5a28b441aca33f1ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AdminLoginPicturePartial), @"mvc.1.0.view", @"/Views/Shared/_AdminLoginPicturePartial.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml"
using OnlineInternshipPortal.Models.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51acde6935775444a263dae5a28b441aca33f1ee", @"/Views/Shared/_AdminLoginPicturePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"529bd39a71a6e8e1292f783dfcdfbdba9cf9865a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AdminLoginPicturePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/avatar-2.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100px; height:100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("user image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml"
 if (_SignInManager.IsSignedIn(User))
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"nav-item nav-profile\">\r\n        <a href=\"#\" class=\"nav-link\">\r\n            <div");
            BeginWriteAttribute("class", " class=\"", 329, "\"", 337, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 13 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml"
                 if (_UserManager.GetUserAsync(User).Result.ProfilePic != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"rounded-circle\" style=\"width:100px; height:100px;\" alt=\"user image\"");
            BeginWriteAttribute("src", " src=\"", 540, "\"", 642, 2);
            WriteAttributeValue("", 546, "data:image/*;base64,", 546, 20, true);
#nullable restore
#line 15 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml"
WriteAttributeValue("", 566, Convert.ToBase64String(_UserManager.GetUserAsync(User).Result.ProfilePic), 566, 76, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 16 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "51acde6935775444a263dae5a28b441aca33f1ee7295", async() => {
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
#line 20 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <span class=\"login-status online\"></span>\r\n                <!--change to offline or busy as needed-->\r\n            </div>\r\n\r\n        </a>\r\n    </li>\r\n");
            WriteLiteral("    <li class=\"nav-item nav-profile\">\r\n        <a href=\"#\" class=\"nav-link\">\r\n            <div class=\"nav-profile-text d-flex flex-column\">\r\n                <span class=\"font-weight-bold mb-2\">");
#nullable restore
#line 32 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml"
                                               Write(_UserManager.GetUserAsync(User).Result.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span class=\"text-secondary text-small\">Adminstrator</span>\r\n            </div>\r\n            <i class=\"mdi mdi-bookmark-check text-success nav-profile-badge\"></i>\r\n        </a>\r\n        <hr />\r\n    </li>\r\n");
#nullable restore
#line 39 "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_AdminLoginPicturePartial.cshtml"



}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> _UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> _SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
