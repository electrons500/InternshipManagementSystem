#pragma checksum "C:\Users\Yishmael\Documents\Visual Studio 2019\Projects\OnlineInternshipPortal\OnlineInternshipPortal\Views\Shared\_PasswordValidationAlertPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6789ec23926186efbbc6cc5798db4b0bdd570b79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PasswordValidationAlertPartial), @"mvc.1.0.view", @"/Views/Shared/_PasswordValidationAlertPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6789ec23926186efbbc6cc5798db4b0bdd570b79", @"/Views/Shared/_PasswordValidationAlertPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"529bd39a71a6e8e1292f783dfcdfbdba9cf9865a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PasswordValidationAlertPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""alert alert-danger"">
    <h2>An error has occured due to the factors below.</h2>
    <ul type=""square"">
        <li>Check your email address correctly.</li>
        <li>Passwords should contain one non-alphanumeric character.</li>
        <li>Passwords should be at least 6 characters long.</li>
        <li>Passwords should contain at least one uppercase letter (A-Z).</li>
        <li>Passwords should contain at least one lowercase letter (a-z).</li>
        <li>Passwords should contain at least one symbol (&amp;,&gt; &lt;  &alpha; &beta; ~!#$%^*? etc).</li>
    </ul>
</div>
<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
