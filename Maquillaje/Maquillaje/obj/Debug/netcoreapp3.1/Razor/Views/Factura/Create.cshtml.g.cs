#pragma checksum "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a615c041db96747cdef412f06e97516a6f8fc26"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a615c041db96747cdef412f06e97516a6f8fc26", @"/Views/Factura/Create.cshtml")]
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
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-4"">
        <div class=""card"">
            <div class=""card-header"">
                <h2>Nueva factura</h2>

            </div>
            <div class=""card-body"">
                <div>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a615c041db96747cdef412f06e97516a6f8fc266823", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a615c041db96747cdef412f06e97516a6f8fc267105", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 19 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a615c041db96747cdef412f06e97516a6f8fc268929", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 22 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a615c041db96747cdef412f06e97516a6f8fc2610560", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a615c041db96747cdef412f06e97516a6f8fc2610865", async() => {
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
#line 23 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.clie_Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 23 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a615c041db96747cdef412f06e97516a6f8fc2614244", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 29 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a615c041db96747cdef412f06e97516a6f8fc2615876", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a615c041db96747cdef412f06e97516a6f8fc2616181", async() => {
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
#line 30 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.meto_Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 30 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
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
#line 46 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
   Write(Html.Partial("_CreateDetalles", new Maquillaje.WebUI.Models.FacturaDetalleViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 47 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
   Write(Html.Partial("_Edit", new Maquillaje.WebUI.Models.FacturaDetalleViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 48 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
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
#line 66 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                         foreach (var detalle in ViewBag.detalles)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 69 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.fact_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 70 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.prod_Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 71 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.factdeta_Cantidad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 72 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.factdeta_Precio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 73 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
                           Write(detalle.factdeta_PrecioTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 3556, "\"", 3682, 11);
            WriteAttributeValue("", 3566, "AbrirModalEdit(\'", 3566, 16, true);
#nullable restore
#line 75 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3582, detalle.factdeta_Id, 3582, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3602, ",", 3602, 1, true);
#nullable restore
#line 75 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3603, detalle.prod_Id, 3603, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3619, ",", 3619, 1, true);
#nullable restore
#line 75 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3620, detalle.factdeta_Cantidad, 3620, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3646, ",", 3646, 1, true);
#nullable restore
#line 75 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3647, detalle.cate_Id, 3647, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3663, ",", 3663, 1, true);
#nullable restore
#line 75 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3664, detalle.fact_Id, 3664, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3680, "\')", 3680, 2, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"btnEditarDetalle\" class=\"btn btn-warning\">Editar</a> |\r\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 3778, "\"", 3836, 5);
            WriteAttributeValue("", 3788, "eliminar(", 3788, 9, true);
#nullable restore
#line 76 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue("", 3797, detalle.factdeta_Id, 3797, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3817, ",", 3817, 1, true);
#nullable restore
#line 76 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
WriteAttributeValue(" ", 3818, detalle.fact_Id, 3819, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3835, ")", 3835, 1, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"btnEliminarDetalle\" class=\"btn btn-danger\">Borrar</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 79 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Factura\Create.cshtml"
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

            sessionStorage.setItem(""i");
            WriteLiteral(@"nserta"", ""jaja"");
            sessionStorage.setItem(""metodo"", $(""#meto_Id"").val());
            sessionStorage.setItem(""cliente"", $(""#clie_Id"").val());

            $(""#formCreate"").submit();
        }
    });

    $(document).ready(function () {

        $('#menuMaquillaje').addClass('active');
        $('#facturasItem').addClass('active');
        $('#subMenuMaquillaje').addClass('show');

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
            $(""#cate"").prop(""disabled"",");
            WriteLiteral(" false);\r\n            $(\"#btnContinuar\").prop(\"disabled\", false);\r\n            $(\"#btnFinalizar\").prop(\"disabled\", false);\r\n        }\r\n\r\n        $(\"#esEditar\").val(\"no\");\r\n        $(\"#esEditar2\").val(\"no\");\r\n    })\r\n</script>\r\n\r\n\r\n");
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
