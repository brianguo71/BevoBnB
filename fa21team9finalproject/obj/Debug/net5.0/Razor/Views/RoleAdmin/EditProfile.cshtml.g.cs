#pragma checksum "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aea6932ef4f7e2af7947aa6387a445244b8b2bf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(fa21team9finalproject.Views.RoleAdmin.Views_RoleAdmin_EditProfile), @"mvc.1.0.view", @"/Views/RoleAdmin/EditProfile.cshtml")]
namespace fa21team9finalproject.Views.RoleAdmin
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
#line 13 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\_ViewImports.cshtml"
using fa21team9finalproject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aea6932ef4f7e2af7947aa6387a445244b8b2bf0", @"/Views/RoleAdmin/EditProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b7518cfb9f5261cf869fbc89b86abbfa4db1af9", @"/Views/_ViewImports.cshtml")]
    public class Views_RoleAdmin_EditProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
  
    ViewBag.Title = "Edit User Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>");
#nullable restore
#line 8 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h1>\n\n<div>\n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>Name:</dt>\n        <dd>\n            ");
#nullable restore
#line 15 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
       Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <br />\n            [");
#nullable restore
#line 17 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
        Write(Html.ActionLink("Change Name", "ChangeName", "Account", new { id = Model.Email }));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\n        </dd>\n\n        <dt>User Name:</dt>\n        <dd>");
#nullable restore
#line 21 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
       Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n\n        <dt>Email:</dt>\n        <dd>");
#nullable restore
#line 24 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n\n        <dt>Password:</dt>\n        <dd>\n           [");
#nullable restore
#line 28 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
       Write(Html.ActionLink("Change password", "AdminChangePassword", "Account", new { id = Model.Email }));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\n        </dd>\n\n        <dt>Address:</dt>\n        <dd>\n            ");
#nullable restore
#line 33 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
       Write(Model.FullAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <br />\n            [");
#nullable restore
#line 35 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
        Write(Html.ActionLink("Change address", "ChangeAddress", "Account", new { id = Model.Email }));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\n        </dd>\n\n        <dt>Phone Number:</dt>\n        <dd>\n            ");
#nullable restore
#line 40 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
       Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <br />\n            [");
#nullable restore
#line 42 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
        Write(Html.ActionLink("Change phone number", "ChangePhoneNumber", "Account", new { id = Model.Email }));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\n        </dd>\n\n        <dt>Birthday:</dt>\n        <dd>\n            ");
#nullable restore
#line 47 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
       Write(Model.Birthday.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <br />\n            [");
#nullable restore
#line 49 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\RoleAdmin\EditProfile.cshtml"
        Write(Html.ActionLink("Change birthday", "ChangeBirthday", "Account", new { id = Model.Email }));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\n        </dd>\n    </dl>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591