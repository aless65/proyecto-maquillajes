#pragma checksum "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be9731a98f29866eeda77694edefd42b45023261"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categoria_Details), @"mvc.1.0.view", @"/Views/Categoria/Details.cshtml")]
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
#line 1 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\_ViewImports.cshtml"
using Maquillaje;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\_ViewImports.cshtml"
using Maquillaje.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be9731a98f29866eeda77694edefd42b45023261", @"/Views/Categoria/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ddf7d49a7b3cb184fc0256cd04aa919d9687b41", @"/Views/_ViewImports.cshtml")]
    public class Views_Categoria_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Maquillaje.Entities.Entities.VW_maqu_tbCategorias_VW>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/app/maqu/Categorias.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <h1>Detalles</h1>\r\n    </div>\r\n    <div class=\"card-body\">\r\n");
#nullable restore
#line 14 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"form-group col-3\">\r\n                    <h5>ID</h5>\r\n                    ");
#nullable restore
#line 19 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.cate_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"form-group col-3\">\r\n                    <h5>Nombre de categoria</h5>\r\n                    ");
#nullable restore
#line 24 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.cate_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group col-3 mt-3\">\r\n                <button type=\"button\" id=\"btnEditar\" class=\"btn btn-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 877, "\"", 936, 5);
            WriteAttributeValue("", 887, "AbrirModalEdit(\'", 887, 16, true);
#nullable restore
#line 28 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
WriteAttributeValue("", 903, item.cate_Id, 903, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 916, ",", 916, 1, true);
#nullable restore
#line 28 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
WriteAttributeValue("", 917, item.cate_Nombre, 917, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 934, "\')", 934, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button>\r\n            </div>\r\n");
#nullable restore
#line 30 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div style=""height:20px""></div>
        <div class=""card"">
            <div class=""card-header""><h2>Auditoria</h2></div>
            <table class=""table table-striped"">
                <thead>
                    <tr>
                        <th>Accion</th>
                        <th>Usuario</th>
                        <th>Fecha</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 43 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td><label>Creacion</label></td>\r\n                            <td>");
#nullable restore
#line 47 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
                           Write(Html.DisplayFor(modelItem => item.cate_UsuCreacion_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 48 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
                           Write(Html.DisplayFor(modelItem => item.cate_FechaCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>Modificacion</td>\r\n                            <td>");
#nullable restore
#line 52 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
                           Write(Html.DisplayFor(modelItem => item.cate_UsuModificacion_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 53 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
                           Write(Html.DisplayFor(modelItem => item.cate_FechaModificacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 55 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9731a98f29866eeda77694edefd42b4502326110010", async() => {
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
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
#nullable restore
#line 64 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Categoria\Details.cshtml"
Write(Html.Partial("_Modal_Edit", new Maquillaje.Entities.Entities.VW_maqu_tbCategorias_VW()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9731a98f29866eeda77694edefd42b4502326111592", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Maquillaje.Entities.Entities.VW_maqu_tbCategorias_VW>> Html { get; private set; }
    }
}
#pragma warning restore 1591
