#pragma checksum "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7774218282ede109421dc069b0f5a5b7ed413b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Factura_Create), @"mvc.1.0.view", @"/Views/Factura/Create.cshtml")]
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
#line 1 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\_ViewImports.cshtml"
using Maquillaje;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\_ViewImports.cshtml"
using Maquillaje.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7774218282ede109421dc069b0f5a5b7ed413b4", @"/Views/Factura/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ddf7d49a7b3cb184fc0256cd04aa919d9687b41", @"/Views/_ViewImports.cshtml")]
    public class Views_Factura_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Maquillaje.WebUI.Models.FacturaViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("clie_Id"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("meto_Id"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formCreate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-4\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                <h2>Nueva factura</h2>\r\n\r\n            </div>\r\n            <div class=\"card-body\">\r\n");
            WriteLiteral("                <div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7774218282ede109421dc069b0f5a5b7ed413b46875", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7774218282ede109421dc069b0f5a5b7ed413b47157", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 22 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"form-group\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7774218282ede109421dc069b0f5a5b7ed413b48981", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 25 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.clie_Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7774218282ede109421dc069b0f5a5b7ed413b410612", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7774218282ede109421dc069b0f5a5b7ed413b410917", async() => {
                        WriteLiteral("--Seleccione un cliente--");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 26 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.clie_Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 26 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.clie_Id;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                <label id=""clie_IdValidation"" name=""clie_IdValidation"" class=""text-danger control-label"" hidden>El campo Cliente es obligatorio</label>
                            </div>
                            <div class=""form-group mt-3"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7774218282ede109421dc069b0f5a5b7ed413b414296", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 32 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.meto_Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7774218282ede109421dc069b0f5a5b7ed413b415928", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7774218282ede109421dc069b0f5a5b7ed413b416233", async() => {
                        WriteLiteral("--Seleccione un método de pago--");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 33 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.meto_Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 33 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.meto_Id;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                <label id=""meto_IdValidation"" name=""meto_IdValidation"" class=""text-danger control-label"" hidden>El campo Método de Pago es obligatorio</label>
                            </div>
                            <div class=""form-group mt-3"">
                                <input type=""button"" value=""Siguiente"" id=""btnSiguiente"" class=""btn btn-info"" />
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"col-8\">\r\n        ");
#nullable restore
#line 49 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
   Write(Html.Partial("_CreateDetalles", new Maquillaje.WebUI.Models.FacturaDetalleViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 50 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
   Write(Html.Partial("_Edit", new Maquillaje.WebUI.Models.FacturaDetalleViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 51 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
   Write(Html.Partial("_Delete", new Maquillaje.WebUI.Models.FacturaDetalleViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>

    <div class=""row mt-4"">
        <div class=""card"">
            <div class=""card-body"">
                <table class=""table table-bordered table-hover"" id=""DataTable"">
                    <thead>
                        <tr>
                            <th>N° Factura</th>
                            <th>Nombre</th>
                            <th>Cantidad</th>
                            <th>Precio Unitario</th>
                            <th>Precio total</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 69 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                         foreach (var detalle in ViewBag.detalles)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 72 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.fact_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 73 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.prod_Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 74 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.factdeta_Cantidad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 75 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.factdeta_Precio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 76 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.factdeta_PrecioTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 3720, "\"", 3846, 11);
            WriteAttributeValue("", 3730, "AbrirModalEdit(\'", 3730, 16, true);
#nullable restore
#line 78 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3746, detalle.factdeta_Id, 3746, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3766, ",", 3766, 1, true);
#nullable restore
#line 78 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3767, detalle.prod_Id, 3767, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3783, ",", 3783, 1, true);
#nullable restore
#line 78 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3784, detalle.factdeta_Cantidad, 3784, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3810, ",", 3810, 1, true);
#nullable restore
#line 78 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3811, detalle.cate_Id, 3811, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3827, ",", 3827, 1, true);
#nullable restore
#line 78 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3828, detalle.fact_Id, 3828, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3844, "\')", 3844, 2, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"btnEditarDetalle\" class=\"btn btn-warning\">Editar</a>\r\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 3940, "\"", 3998, 5);
            WriteAttributeValue("", 3950, "eliminar(", 3950, 9, true);
#nullable restore
#line 79 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3959, detalle.factdeta_Id, 3959, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3979, ",", 3979, 1, true);
#nullable restore
#line 79 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue(" ", 3980, detalle.fact_Id, 3981, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3997, ")", 3997, 1, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"btnEliminarDetalle\" class=\"btn btn-danger\">Borrar</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 82 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<script>
    $(""#prod_Id"").prop(""disabled"", true);
    $(""#factdeta_Cantidad"").prop(""disabled"", true);
    $(""#factdeta_PrecioShow"").prop(""disabled"", true);
    $(""#cate"").prop(""disabled"", true);
    $(""#btnContinuar"").prop(""disabled"", true);
    $(""#btnFinalizar"").prop(""disabled"", true);


    $(""#btnSiguiente"").click(function () {

        if (!($(""#clie_Id"").val() > 0)) {
            $(""#clie_IdValidation"").prop(""hidden"", false);
            console.log(""cliente"");
        } else {
            $(""#clie_IdValidation"").prop(""hidden"", true);
        }

        if (!($(""#meto_Id"").val() > 0)) {
            $(""#meto_IdValidation"").prop(""hidden"", false);
            console.log(""metodo"");
        } else {
            $(""#meto_IdValidation"").prop(""hidden"", true);
        }

        if ($(""#meto_Id"").val() > 0 && $(""#clie_Id"").val() > 0) {

            sessionStorage.setItem(");
            WriteLiteral(@"""inserta"", ""jaja"");
            sessionStorage.setItem(""metodo"", $(""#meto_Id"").val());
            sessionStorage.setItem(""cliente"", $(""#clie_Id"").val());

            $(""#formCreate"").submit();
        }
    });

    $(document).ready(function () {
        console.log(sessionStorage.getItem(""inserta""));

        if (sessionStorage.getItem(""inserta"") != null) {
            $(""#clie_Id"").prop(""disabled"", true);
            $(""#clie_Id"").val(sessionStorage.getItem(""cliente""));
            $(""#meto_Id"").prop(""disabled"", true);
            $(""#meto_Id"").val(sessionStorage.getItem(""metodo""));
            $(""#empe_Id"").prop(""disabled"", true);
            $(""#btnSiguiente"").prop(""disabled"", true);

            $(""#prod_Id"").prop(""disabled"", false);
            $(""#factdeta_Cantidad"").prop(""disabled"", false);
            $(""#cate"").prop(""disabled"", false);
            $(""#btnContinuar"").prop(""disabled"", false);
            $(""#btnFinalizar"").prop(""disabled"", false);
        }
    })
</script");
            WriteLiteral(">\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Maquillaje.WebUI.Models.FacturaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
