#pragma checksum "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6386e21bbe89324ff06883968bc8a51f1771c47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(fa21team9finalproject.Views.PropertyReviews.Views_PropertyReviews_Index), @"mvc.1.0.view", @"/Views/PropertyReviews/Index.cshtml")]
namespace fa21team9finalproject.Views.PropertyReviews
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6386e21bbe89324ff06883968bc8a51f1771c47", @"/Views/PropertyReviews/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b7518cfb9f5261cf869fbc89b86abbfa4db1af9", @"/Views/_ViewImports.cshtml")]
    public class Views_PropertyReviews_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<fa21team9finalproject.Models.PropertyReview>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DisputeHost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PropertyReviews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Properties", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Property Reviews.</h1>\n<p>\n    See what our users have to say about the property at <strong class=\"text-info\">");
#nullable restore
#line 9 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                                                                              Write(ViewBag.Property);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>.\n</p>\n\n");
#nullable restore
#line 12 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
 if (@Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\n        This property has an average rating of <strong class=\"text-info\">");
#nullable restore
#line 15 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                                                                    Write(ViewBag.AverageRating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>.\n    </p>\n");
#nullable restore
#line 17 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 19 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
 if (User.Identity.IsAuthenticated && User.IsInRole("Host"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"panel-heading\"><strong class=\"text-primary\">Active Reviews</strong></div>\n");
#nullable restore
#line 22 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\n    <thead>\n");
#nullable restore
#line 25 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
         if (ViewBag.noResults == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <th>\n                ");
#nullable restore
#line 29 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 32 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Review));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n");
#nullable restore
#line 36 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </thead>\n    <tbody>\n");
#nullable restore
#line 39 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
         foreach (var item in Model.Where(m => m.dStatus == disputeStatus.notViewedYet || m.dStatus == disputeStatus.Rejected))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
#nullable restore
#line 43 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 46 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Review));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <!--if the user is a host, that means the property is theirs. They are allowed to dispute reviews-->\n");
#nullable restore
#line 49 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                 if (User.Identity.IsAuthenticated && User.IsInRole("Host") && item.dStatus == disputeStatus.notViewedYet)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6386e21bbe89324ff06883968bc8a51f1771c479980", async() => {
                WriteLiteral("Dispute Review");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                                                                                       WriteLiteral(item.PropertyReviewID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </td>\n");
#nullable restore
#line 54 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\n");
#nullable restore
#line 56 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n\n<p>\n    ");
#nullable restore
#line 61 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
Write(ViewBag.noResults);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</p>\n\n");
#nullable restore
#line 64 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
 if (User.Identity.IsAuthenticated && User.IsInRole("Host") && Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"panel-heading\"><strong class=\"text-primary\">Reviews in Dispute</strong></div>\n    <table class=\"table\">\n        <thead>\n");
#nullable restore
#line 69 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
             if (Model.Where(m => m.dStatus == disputeStatus.inDispute).Count() > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <th>\n                        ");
#nullable restore
#line 73 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </th>\n                    <th>\n                        ");
#nullable restore
#line 76 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Review));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </th>\n                    <th></th>\n                </tr>\n");
#nullable restore
#line 80 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </thead>\n        <tbody>\n");
#nullable restore
#line 84 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
             if (Model.Where(m => m.dStatus == disputeStatus.inDispute).Count() == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>\n                        There are no reviews in dispute for this property.\n                    </p>\n");
#nullable restore
#line 89 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
             foreach (var item in Model.Where(m => m.dStatus == disputeStatus.inDispute))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>\n                        ");
#nullable restore
#line 94 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 97 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Review));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    \n                </tr>\n");
#nullable restore
#line 101 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n");
#nullable restore
#line 104 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\PropertyReviews\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6386e21bbe89324ff06883968bc8a51f1771c4717543", async() => {
                WriteLiteral("Back to Property Listings");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<fa21team9finalproject.Models.PropertyReview>> Html { get; private set; }
    }
}
#pragma warning restore 1591
