#pragma checksum "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e831162f4e71671bf2e7d76a0e2698de841adc1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ShowDania), @"mvc.1.0.view", @"/Views/Admin/ShowDania.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/ShowDania.cshtml", typeof(AspNetCore.Views_Admin_ShowDania))]
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
#line 1 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\_ViewImports.cshtml"
using SystemRestauracja;

#line default
#line hidden
#line 2 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\_ViewImports.cshtml"
using SystemRestauracja.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e831162f4e71671bf2e7d76a0e2698de841adc1d", @"/Views/Admin/ShowDania.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33cdb148a24d839d2fbfbc6358166e0c8987aa0a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ShowDania : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SystemRestauracja.Models.Admin.ShowDaniaViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowDania", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info col"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditDanie", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger col"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteDanie", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("container"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
  
    ViewData["Title"] = "Lista Kategorii";

#line default
#line hidden
            BeginContext(109, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
 if (!ViewData.ModelState.IsValid && ViewData.ModelState["Error"].Errors.Count > 0)
{

#line default
#line hidden
            BeginContext(199, 46, true);
            WriteLiteral("    <div class=\"alert alert-danger\">\r\n        ");
            EndContext();
            BeginContext(246, 56, false);
#line 9 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
   Write(ViewData.ModelState["Error"].Errors.First().ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(302, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 11 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
}

#line default
#line hidden
            BeginContext(319, 144, true);
            WriteLiteral("\r\n<div class=\"justify-content-center\">\r\n    <h2 class=\"text-dark text-center\">Dania</h2>\r\n</div>\r\n\r\n<div class=\"container w-25 mt-2 mb-2\">\r\n    ");
            EndContext();
            BeginContext(463, 290, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e831162f4e71671bf2e7d76a0e2698de841adc1d7548", async() => {
                BeginContext(527, 219, true);
                WriteLiteral("\r\n        <input id=\"searchString\" name=\"searchString\" type=\"text\" placeholder=\"Wyszukaj po nazwie\" class=\"form-control col\">\r\n        <button type=\"submit\" runat=\"server\" class=\"btn btn-dark mr-5\">Szukaj</button>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(753, 129, true);
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <label class=\"col w-25\"></label>\r\n        <label class=\"col\">");
            EndContext();
            BeginContext(883, 79, false);
#line 27 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                      Write(Html.ActionLink("Nazwa", "ShowDania", new { sortOrder = ViewBag.NameSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(962, 37, true);
            WriteLiteral("</label>\r\n        <label class=\"col\">");
            EndContext();
            BeginContext(1000, 82, false);
#line 28 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                      Write(Html.ActionLink("Kategoria", "ShowDania", new { sortOrder = ViewBag.CatSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(1082, 37, true);
            WriteLiteral("</label>\r\n        <label class=\"col\">");
            EndContext();
            BeginContext(1120, 79, false);
#line 29 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                      Write(Html.ActionLink("Cena", "ShowDania", new { sortOrder = ViewBag.PriceSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(1199, 10, true);
            WriteLiteral("</label>\r\n");
            EndContext();
            BeginContext(1305, 76, true);
            WriteLiteral("        <label class=\"col\">Opublikowane</label>\r\n        <label class=\"col\">");
            EndContext();
            BeginContext(1382, 89, false);
#line 33 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                      Write(Html.ActionLink("Data utworzenia", "ShowDania", new { sortOrder = ViewBag.DateSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(1471, 118, true);
            WriteLiteral("</label>\r\n        <label class=\"col\">Edycja</label>\r\n        <label class=\"col\">Usuwanie</label>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(1589, 1448, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e831162f4e71671bf2e7d76a0e2698de841adc1d11958", async() => {
                BeginContext(1613, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 39 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
     foreach (var danie in Model.Dania)
    {

#line default
#line hidden
                BeginContext(1663, 168, true);
                WriteLiteral("        <div>\r\n            <div class=\"row\">\r\n                <i class=\"col w-25 btn btn-outline-info\">?</i>\r\n                <a class=\"col text-primary\" role=\"button\">");
                EndContext();
                BeginContext(1832, 11, false);
#line 44 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                                                     Write(danie.Nazwa);

#line default
#line hidden
                EndContext();
                BeginContext(1843, 56, true);
                WriteLiteral("</a>\r\n                <label class=\"col text-primary\">\r\n");
                EndContext();
#line 46 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                     foreach (var cat in Model.Kategorie)
                    {
                        if (cat.Id == danie.CategoryId)
                        {

#line default
#line hidden
                BeginContext(2065, 33, true);
                WriteLiteral("                            <div>");
                EndContext();
                BeginContext(2099, 9, false);
#line 50 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                            Write(cat.Nazwa);

#line default
#line hidden
                EndContext();
                BeginContext(2108, 8, true);
                WriteLiteral("</div>\r\n");
                EndContext();
#line 51 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                        }
                    }

#line default
#line hidden
                BeginContext(2166, 74, true);
                WriteLiteral("                </label>\r\n                <label class=\"col text-primary\">");
                EndContext();
                BeginContext(2241, 10, false);
#line 54 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                                           Write(danie.Cena);

#line default
#line hidden
                EndContext();
                BeginContext(2251, 10, true);
                WriteLiteral("</label>\r\n");
                EndContext();
                BeginContext(2459, 50, true);
                WriteLiteral("                <label class=\"col text-primary\">\r\n");
                EndContext();
#line 58 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                     if (danie.CzyUpublicznione)
                    {

#line default
#line hidden
                BeginContext(2580, 12, true);
                WriteLiteral("<div>x</div>");
                EndContext();
#line 59 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                                 ;
                    }

#line default
#line hidden
                BeginContext(2618, 68, true);
                WriteLiteral("            </label>\r\n            <label class=\"col text-secondary\">");
                EndContext();
                BeginContext(2687, 16, false);
#line 62 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                                         Write(danie.CreateDate);

#line default
#line hidden
                EndContext();
                BeginContext(2703, 22, true);
                WriteLiteral("</label>\r\n            ");
                EndContext();
                BeginContext(2725, 122, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e831162f4e71671bf2e7d76a0e2698de841adc1d16180", async() => {
                    BeginContext(2837, 6, true);
                    WriteLiteral("Edytuj");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-danieId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 63 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                                                                                                     WriteLiteral(danie.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["danieId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-danieId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["danieId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2847, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(2861, 124, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e831162f4e71671bf2e7d76a0e2698de841adc1d19038", async() => {
                    BeginContext(2977, 4, true);
                    WriteLiteral("Usuń");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-danieId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 64 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                                                                                                         WriteLiteral(danie.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["danieId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-danieId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["danieId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2985, 42, true);
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <hr />\r\n");
                EndContext();
#line 68 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
}

#line default
#line hidden
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3037, 57, true);
            WriteLiteral("\r\n\r\n<div>\r\n    <div class=\"text-dark text-center\">Strona ");
            EndContext();
            BeginContext(3096, 60, false);
#line 72 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                                          Write(Model.totalPages < Model.currentPage ? 0 : Model.currentPage);

#line default
#line hidden
            EndContext();
            BeginContext(3157, 3, true);
            WriteLiteral(" z ");
            EndContext();
            BeginContext(3161, 16, false);
#line 72 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                                                                                                           Write(Model.totalPages);

#line default
#line hidden
            EndContext();
            BeginContext(3177, 89, true);
            WriteLiteral("</div>\r\n</div>\r\n\r\n<div class=\"justify-content-center row\">\r\n    <ul class=\"pagination\">\r\n");
            EndContext();
#line 77 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
         for (int i = 1; i <= Model.totalPages; i++)
        {

#line default
#line hidden
            BeginContext(3331, 15, true);
            WriteLiteral("            <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 3346, "\"", 3413, 1);
#line 79 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
WriteAttributeValue("", 3354, i== Model.currentPage ? "page-item active" : "page-item", 3354, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3414, 39, true);
            WriteLiteral(">\r\n                <a class=\"page-link\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3453, "\"", 3571, 1);
#line 80 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
WriteAttributeValue("", 3460, Url.Action("ShowCategories", new {page=i, sortOrder=ViewBag.CurrentSort, currentFilter=ViewBag.CurrentFilter}), 3460, 111, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3572, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3574, 1, false);
#line 80 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
                                                                                                                                                       Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3575, 25, true);
            WriteLiteral("</a>\r\n            </li>\r\n");
            EndContext();
#line 82 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowDania.cshtml"
        }

#line default
#line hidden
            BeginContext(3611, 17, true);
            WriteLiteral("    </ul>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SystemRestauracja.Models.Admin.ShowDaniaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
