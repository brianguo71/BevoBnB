#pragma checksum "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\AdminReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "073d886fd82beeb7056b29b9b105466bac424ed6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(fa21team9finalproject.Views.Properties.Views_Properties_AdminReport), @"mvc.1.0.view", @"/Views/Properties/AdminReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"073d886fd82beeb7056b29b9b105466bac424ed6", @"/Views/Properties/AdminReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b7518cfb9f5261cf869fbc89b86abbfa4db1af9", @"/Views/_ViewImports.cshtml")]
    public class Views_Properties_AdminReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<fa21team9finalproject.Models.AdminReportViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AdminReportSearch", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Properties", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary mt-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\AdminReport.cshtml"
  
    ViewData["Title"] = "AdminReport";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Admin Report.</h1>\n<p>\n    View a financial report of the reservations made on BevoBnB below.\n</p>\n<hr/>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "073d886fd82beeb7056b29b9b105466bac424ed65140", async() => {
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
            WriteLiteral("\n<div>\n    <hr />\n    <h4>Report Details</h4>\n    <dl class=\"row\">\n        <div><p class=\"text-primary\">This report includes ");
#nullable restore
#line 17 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\AdminReport.cshtml"
                                                     Write(Model.BnBTotalReservations);

#line default
#line hidden
#nullable disable
            WriteLiteral(" reservations out of the total ");
#nullable restore
#line 17 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\AdminReport.cshtml"
                                                                                                               Write(ViewBag.AllReservations);

#line default
#line hidden
#nullable disable
            WriteLiteral(" reservations made on BevoBnB.</p></div>\n        <dt class=\"col-sm-5\">\n            Total Revenue Gained\n        </dt>\n        <dd class=\"col-sm-12\">\n            ");
#nullable restore
#line 22 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\AdminReport.cshtml"
       Write(Html.DisplayFor(model => model.BnBTotalCommission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-5\">\n            Total Active Reservations\n        </dt>\n        <dd class=\"col-sm-12\">\n            ");
#nullable restore
#line 28 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\AdminReport.cshtml"
       Write(Html.DisplayFor(model => model.BnBTotalReservations));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-5\">\n            Average Commission Gained per Reservation\n        </dt>\n        <dd class=\"col-sm-12\">\n            ");
#nullable restore
#line 34 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\AdminReport.cshtml"
       Write(Html.DisplayFor(model => model.BnBAvgCommission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-5\">\n            ");
#nullable restore
#line 37 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\AdminReport.cshtml"
       Write(Html.DisplayNameFor(model => model.BnBSelectedProperties));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-12\">\n            ");
#nullable restore
#line 40 "E:\MIS_333K_Code\fa21team9finalproject\fa21team9finalproject\fa21team9finalproject\Views\Properties\AdminReport.cshtml"
       Write(Html.DisplayFor(model => model.BnBSelectedProperties));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </dl>
</div>
<hr />
<p>
    <strong>How to Read the Admin Report</strong>
<p />

<p>
    - Total Revenue Gained reflects the 10% commission BevoBnB collects from hosts for reservations on their properties.
<p />

<p>
    - Total Active Reservations lists the total number of active reservations associated with this report. This can be narrowed down by day, but includes any upcoming reservations as well as past reservations. If a user or host cancels an upcoming reservation, this report will not include the reservation anymore.
<p />

<p>
    - Average Commission Gained per Reservation is the average of the Total Revenue Gained divided by the Total Active Reservations. This number will change to only include only reservations included in the report when running a detailed search.
<p />

<div>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "073d886fd82beeb7056b29b9b105466bac424ed610180", async() => {
                WriteLiteral("Back to List");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<fa21team9finalproject.Models.AdminReportViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
