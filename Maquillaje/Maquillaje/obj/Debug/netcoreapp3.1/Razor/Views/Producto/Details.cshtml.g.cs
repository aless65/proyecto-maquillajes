#pragma checksum "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a42128f07ec9a900aec721144297ec38bdf1547"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Producto_Details), @"mvc.1.0.view", @"/Views/Producto/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a42128f07ec9a900aec721144297ec38bdf1547", @"/Views/Producto/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ddf7d49a7b3cb184fc0256cd04aa919d9687b41", @"/Views/_ViewImports.cshtml")]
    public class Views_Producto_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Maquillaje.Entities.Entities.VW_maqu_tbProductos_VW>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-header\"><h2>Detalles</h2></div>\r\n    <div class=\"card-body\">\r\n        <div>\r\n\r\n            <dl class=\"row\">\r\n");
#nullable restore
#line 14 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"form-group col-6\">\r\n                        <h5>ID</h5>\r\n                        ");
#nullable restore
#line 18 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.prod_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
            WriteLiteral("                    <div class=\"form-group col-6\">\r\n                        <h5>Producto</h5>\r\n                        ");
#nullable restore
#line 23 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.prod_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
            WriteLiteral("                    <div class=\"form-group col-6\">\r\n                        <h5>Categoria</h5>\r\n                        ");
#nullable restore
#line 28 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.cate_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
            WriteLiteral("                    <div class=\"form-group col-6 mt-2\">\r\n                        <h5>Proveedor</h5>\r\n                        ");
#nullable restore
#line 33 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.prov_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
            WriteLiteral("                    <div class=\"form-group col-6 mt-2\">\r\n                        <h5>Stock</h5>\r\n                        ");
#nullable restore
#line 38 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.prod_Stock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
            WriteLiteral("                    <div class=\"form-group col-6 mt-2\">\r\n\r\n                    </div>\r\n                    <div class=\"form-group col-6 mt-3 mb-3\">\r\n                        <button type=\"button\" id=\"btnEditar\" class=\"btn btn-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1603, "\"", 1728, 13);
            WriteAttributeValue("", 1613, "AbrirModalEdit(\'", 1613, 16, true);
#nullable restore
#line 45 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
WriteAttributeValue("", 1629, item.prod_Id, 1629, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1642, ",", 1642, 1, true);
#nullable restore
#line 45 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
WriteAttributeValue("", 1643, item.prod_Nombre, 1643, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1660, ",", 1660, 1, true);
#nullable restore
#line 45 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
WriteAttributeValue("", 1661, item.prod_PrecioUni, 1661, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1681, ",", 1681, 1, true);
#nullable restore
#line 45 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
WriteAttributeValue("", 1682, item.cate_Id, 1682, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1695, ",", 1695, 1, true);
#nullable restore
#line 45 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
WriteAttributeValue("", 1696, item.prov_Id, 1696, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1709, ",", 1709, 1, true);
#nullable restore
#line 45 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
WriteAttributeValue("", 1710, item.prod_Stock, 1710, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1726, "\')", 1726, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button>\r\n                    </div>\r\n");
            WriteLiteral(@"                    <div class=""card"">
                        <div class=""card-header""><h2>Auditoria</h2></div>
                        <div class=""card-body"">
                            <table class=""table table-striped"">
                                <thead>
                                    <tr>
                                        <td><h5>Accion</h5></td>
                                        <td><h5>Usuario</h5></td>
                                        <td><h5>Fecha</h5></td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><h5>Creacion</h5></td>
                                        <td>");
#nullable restore
#line 62 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.user_UsuCreacion_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 63 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.prod_FechaCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td><h5>Modificacion</h5></td>\r\n                                        <td>");
#nullable restore
#line 67 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.user_UsuModificacion_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 68 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.prod_FechaModificacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 74 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dl>\r\n        </div>\r\n        <div>\r\n        </div>\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a42128f07ec9a900aec721144297ec38bdf154712366", async() => {
                WriteLiteral("Regresar");
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
            WriteLiteral("\r\n</div>\r\n\r\n");
#nullable restore
#line 83 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Details.cshtml"
Write(Html.Partial("_Modal_Edit", new Maquillaje.Entities.Entities.VW_maqu_tbProductos_VW()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Maquillaje.Entities.Entities.VW_maqu_tbProductos_VW>> Html { get; private set; }
    }
}
#pragma warning restore 1591
