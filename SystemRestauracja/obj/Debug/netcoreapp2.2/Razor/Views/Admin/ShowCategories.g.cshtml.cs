#pragma checksum "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2cb1c33bace49c76dc578ef7c3e8602e13290ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ShowCategories), @"mvc.1.0.view", @"/Views/Admin/ShowCategories.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/ShowCategories.cshtml", typeof(AspNetCore.Views_Admin_ShowCategories))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2cb1c33bace49c76dc578ef7c3e8602e13290ec", @"/Views/Admin/ShowCategories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33cdb148a24d839d2fbfbc6358166e0c8987aa0a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ShowCategories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SystemRestauracja.Models.Admin.ShowCategoriesViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowCategories", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info col"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger col"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
  
    ViewData["Title"] = "Lista Kategorii";

#line default
#line hidden
            BeginContext(114, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
 if (!ViewData.ModelState.IsValid && ViewData.ModelState["Error"].Errors.Count > 0)
{

#line default
#line hidden
            BeginContext(204, 46, true);
            WriteLiteral("    <div class=\"alert alert-danger\">\r\n        ");
            EndContext();
            BeginContext(251, 56, false);
#line 9 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
   Write(ViewData.ModelState["Error"].Errors.First().ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(307, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 11 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
}

#line default
#line hidden
            BeginContext(324, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 13 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
 if (TempData["Success"] != null)
{

#line default
#line hidden
            BeginContext(364, 55, true);
            WriteLiteral("    <p class=\"alert alert-success\" id=\"successMessage\">");
            EndContext();
            BeginContext(420, 19, false);
#line 15 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                                                  Write(TempData["Success"]);

#line default
#line hidden
            EndContext();
            BeginContext(439, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 16 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
}


#line default
#line hidden
            BeginContext(713, 148, true);
            WriteLiteral("\r\n<div class=\"justify-content-center\">\r\n    <h2 class=\"text-dark text-center\">Kategorie</h2>\r\n</div>\r\n\r\n<div class=\"container w-50 mt-2 mb-2\">\r\n    ");
            EndContext();
            BeginContext(861, 295, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2cb1c33bace49c76dc578ef7c3e8602e13290ec8260", async() => {
                BeginContext(930, 219, true);
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
            BeginContext(1156, 67, true);
            WriteLiteral("\r\n</div>\r\n\r\n<div>\r\n    <div class=\"row\">\r\n        <div class=\"col\">");
            EndContext();
            BeginContext(1224, 84, false);
#line 38 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                    Write(Html.ActionLink("Nazwa", "ShowCategories", new { sortOrder = ViewBag.NameSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(1308, 47, true);
            WriteLiteral("</div>\r\n        <div class=\"col\">\r\n            ");
            EndContext();
            BeginContext(1356, 94, false);
#line 40 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
       Write(Html.ActionLink("Data utworzenia", "ShowCategories", new { sortOrder = ViewBag.DateSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(1450, 78, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col\">\r\n            Nadrzędna kategoria\r\n");
            EndContext();
            BeginContext(1650, 216, true);
            WriteLiteral("        </div>\r\n        <div class=\"col\"></div>\r\n        <div class=\"col\"></div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"container-fluid list-group col\" style=\"overflow-y:scroll; height: 75vh; padding-left:25px;\">\r\n    ");
            EndContext();
            BeginContext(1866, 1037, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2cb1c33bace49c76dc578ef7c3e8602e13290ec11843", async() => {
                BeginContext(1872, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 54 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
         foreach (var cat in Model.Kategorie)
        {


#line default
#line hidden
                BeginContext(1934, 115, true);
                WriteLiteral("            <div>\r\n                <div class=\"row\">\r\n                    <a class=\"form-control col text-primary\">");
                EndContext();
                BeginContext(2050, 9, false);
#line 59 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                                                        Write(cat.Nazwa);

#line default
#line hidden
                EndContext();
                BeginContext(2059, 67, true);
                WriteLiteral("</a>\r\n                    <a class=\"form-control col text-primary\">");
                EndContext();
                BeginContext(2127, 14, false);
#line 60 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                                                        Write(cat.CreateDate);

#line default
#line hidden
                EndContext();
                BeginContext(2141, 6, true);
                WriteLiteral("</a>\r\n");
                EndContext();
#line 61 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                     if (cat.ParentCategoryId != null)
                    {


#line default
#line hidden
                BeginContext(2228, 65, true);
                WriteLiteral("                        <a class=\"form-control col text-primary\">");
                EndContext();
                BeginContext(2294, 24, false);
#line 64 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                                                            Write(cat.ParentCategory.Nazwa);

#line default
#line hidden
                EndContext();
                BeginContext(2318, 6, true);
                WriteLiteral("</a>\r\n");
                EndContext();
#line 65 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                    }
                    else
                    {

#line default
#line hidden
                BeginContext(2396, 98, true);
                WriteLiteral("                        <a class=\"form-control col text-secondary\">Brak nadrzędnej kategorii</a>\r\n");
                EndContext();
#line 69 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                    }

#line default
#line hidden
                BeginContext(2517, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(2537, 136, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2cb1c33bace49c76dc578ef7c3e8602e13290ec15111", async() => {
                    BeginContext(2658, 6, true);
                    WriteLiteral("Edytuj");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-categoryId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 70 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                                                                                                                        WriteLiteral(cat.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["categoryId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-categoryId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["categoryId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2673, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(2695, 138, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2cb1c33bace49c76dc578ef7c3e8602e13290ec18052", async() => {
                    BeginContext(2820, 4, true);
                    WriteLiteral("Usuń");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-categoryId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 71 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                                                                                                                            WriteLiteral(cat.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["categoryId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-categoryId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["categoryId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2833, 46, true);
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
                EndContext();
#line 74 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"

        }

#line default
#line hidden
                BeginContext(2892, 4, true);
                WriteLiteral("    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2903, 63, true);
            WriteLiteral("\r\n    <div>\r\n        <div class=\"text-dark text-center\">Strona ");
            EndContext();
            BeginContext(2968, 60, false);
#line 78 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                                              Write(Model.totalPages < Model.currentPage ? 0 : Model.currentPage);

#line default
#line hidden
            EndContext();
            BeginContext(3029, 3, true);
            WriteLiteral(" z ");
            EndContext();
            BeginContext(3033, 16, false);
#line 78 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                                                                                                               Write(Model.totalPages);

#line default
#line hidden
            EndContext();
            BeginContext(3049, 101, true);
            WriteLiteral("</div>\r\n    </div>\r\n\r\n    <div class=\"justify-content-center row\">\r\n        <ul class=\"pagination\">\r\n");
            EndContext();
#line 83 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
             for (int i = 1; i <= Model.totalPages; i++)
            {

#line default
#line hidden
            BeginContext(3223, 19, true);
            WriteLiteral("                <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 3242, "\"", 3309, 1);
#line 85 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
WriteAttributeValue("", 3250, i== Model.currentPage ? "page-item active" : "page-item", 3250, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3310, 43, true);
            WriteLiteral(">\r\n                    <a class=\"page-link\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3353, "\"", 3471, 1);
#line 86 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
WriteAttributeValue("", 3360, Url.Action("ShowCategories", new {page=i, sortOrder=ViewBag.CurrentSort, currentFilter=ViewBag.CurrentFilter}), 3360, 111, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3472, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3474, 1, false);
#line 86 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
                                                                                                                                                           Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3475, 29, true);
            WriteLiteral("</a>\r\n                </li>\r\n");
            EndContext();
#line 88 "D:\PracaInzynierska\Final\SystemRestauracja\SystemRestauracja\Views\Admin\ShowCategories.cshtml"
            }

#line default
#line hidden
            BeginContext(3519, 39, true);
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SystemRestauracja.Models.Admin.ShowCategoriesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
