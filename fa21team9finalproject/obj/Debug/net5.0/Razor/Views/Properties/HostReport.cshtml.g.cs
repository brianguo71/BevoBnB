#pragma checksum "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d30dc8ba59104b56f5a9a1c536d664c8b7a52b6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(fa21team9finalproject.Views.Properties.Views_Properties_HostReport), @"mvc.1.0.view", @"/Views/Properties/HostReport.cshtml")]
namespace fa21team9finalproject.Views.Properties
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d30dc8ba59104b56f5a9a1c536d664c8b7a52b6d", @"/Views/Properties/HostReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b7518cfb9f5261cf869fbc89b86abbfa4db1af9", @"/Views/_ViewImports.cshtml")]
    public class Views_Properties_HostReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<fa21team9finalproject.Models.HostReportViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "HostReportSearch", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Properties", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary mt-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
  
    ViewData["Title"] = "HostReport";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Host Report.</h1>\n<p>\n    View a report of your property listings and revenue below.\n</p>\n<hr/>\n<!--button for detailed search and -->\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d30dc8ba59104b56f5a9a1c536d664c8b7a52b6d5464", async() => {
                WriteLiteral("Detailed Search");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n<div>\n    <hr />\n\n    <h4>Report Details</h4>\n    <dl class=\"row\">\n        <p class=\"text-primary\">This report includes ");
#nullable restore
#line 19 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
                                                Write(Model.CompletedReservations);

#line default
#line hidden
#nullable disable
            WriteLiteral(" reservations out of the total ");
#nullable restore
#line 19 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
                                                                                                           Write(ViewBag.AllReservations);

#line default
#line hidden
#nullable disable
            WriteLiteral(" reservations made on your properties.</p>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 21 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalDailyPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 24 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayFor(model => model.TotalDailyPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            Number of Reservations in Report\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 30 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayFor(model => model.CompletedReservations));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 33 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalHostDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 36 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayFor(model => model.TotalHostDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 39 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalStayRevenue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 42 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayFor(model => model.TotalStayRevenue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 45 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalHostStayRevenue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 48 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayFor(model => model.TotalHostStayRevenue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 51 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalCleaningFees));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 54 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayFor(model => model.TotalCleaningFees));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 57 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayNameFor(model => model.HostPayout));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 60 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
       Write(Html.DisplayFor(model => model.HostPayout));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </dl>
</div>
<hr/>
<h4>Detailed Information per Property</h4>
<table class=""table table-striped"">
    <thead>
        <tr>
            <th>
                Full Address
            </th>
            <th>
                Total Stay Revenue
            </th>
            <th>
                Total Cleaning Fees
            </th>
            <th>
                Total Discount
            </th>
            <th>
                Number of Reservations on Property
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 88 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
         foreach (var item in @Model.IndividualPropertyReports)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
#nullable restore
#line 92 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.property.FullAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 95 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.pTotalStayRevenue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 98 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.pTotalCleaningFees));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 101 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.pTotalDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 104 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.pCompletedReservations));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d30dc8ba59104b56f5a9a1c536d664c8b7a52b6d15155", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
                                              WriteLiteral(item.property.PropertyID);

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
            WriteLiteral("\n                </td>\n            </tr>\n");
#nullable restore
#line 110 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\HostReport.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>
<br/>
<hr/>
<p>
    <strong>How to Read the Host Report</strong>
<p />

<p>
    - Total Daily Price shows the total daily price of reservations made on your properties.
<p />

<p>
    - Total Discount shows the total amount of discounts offered to customers.
<p />

<p>
    - Total Stay Revenue shows the total amount charged to customers for their stay. This is the Total Daily Price charged minus Total Discounts offered.
<p />

<p>
    - Total Host Stay Revenue is the total amount you get to keep of the Total Stay Revenue. BevoBnB charges a small commission of 10%. This means you get to keep 90% of the rental fees charged to guests! (The largest cut in our industry)
<p />

<p>
    - Total Cleaning Fees are the total cleaning fees charged. You get to keep 100% of any cleaning fee listed for all properties.
<p />

<p>
    - Total Payout is the total amount that you will be receiving from BevoBnB for reservations on your properties.
</p>

<p>
    - This report includes any active reservation");
            WriteLiteral(" made on your property. Thus, both upcoming and past. Note that if a member cancels their reservation within the cancellation period, your revenue will change.\n<p />\n\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d30dc8ba59104b56f5a9a1c536d664c8b7a52b6d18887", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<fa21team9finalproject.Models.HostReportViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
