#pragma checksum "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19724c5c7c7ea174457026ebc57d7ddd5a503839"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Producto_Index), @"mvc.1.0.view", @"/Views/Producto/Index.cshtml")]
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
#line 1 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\_ViewImports.cshtml"
using Maquillaje;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\_ViewImports.cshtml"
using Maquillaje.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19724c5c7c7ea174457026ebc57d7ddd5a503839", @"/Views/Producto/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ddf7d49a7b3cb184fc0256cd04aa919d9687b41", @"/Views/_ViewImports.cshtml")]
    public class Views_Producto_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Maquillaje.Entities.Entities.VW_maqu_tbProductos_VW>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""card"">
    <div class=""card-header""><h2>Productos</h2></div>
    <div class=""card-body"">
        <p>
            <a class=""btn btn-secondary"" onclick=""AbrirModalCreate()"">Nuevo</a>
        </p>
        <table class=""table table-bordered table-hover"" id=""DataTable"">
            <thead>
                <tr>
                    <th>
                        ");
#nullable restore
#line 19 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.prod_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 22 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.prod_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 25 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.prod_PrecioUni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 28 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.prod_Stock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 31 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.cate_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>Acciones</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 37 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 41 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.prod_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 44 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.prod_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 47 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.prod_PrecioUni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 50 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.prod_Stock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 53 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.cate_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <button type=\"button\" id=\"btnEditar\" class=\"btn btn-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2058, "\"", 2183, 13);
            WriteAttributeValue("", 2068, "AbrirModalEdit(\'", 2068, 16, true);
#nullable restore
#line 56 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
WriteAttributeValue("", 2084, item.prod_Id, 2084, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2097, ",", 2097, 1, true);
#nullable restore
#line 56 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
WriteAttributeValue("", 2098, item.prod_Nombre, 2098, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2115, ",", 2115, 1, true);
#nullable restore
#line 56 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
WriteAttributeValue("", 2116, item.prod_PrecioUni, 2116, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2136, ",", 2136, 1, true);
#nullable restore
#line 56 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
WriteAttributeValue("", 2137, item.cate_Id, 2137, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2150, ",", 2150, 1, true);
#nullable restore
#line 56 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
WriteAttributeValue("", 2151, item.prov_Id, 2151, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2164, ",", 2164, 1, true);
#nullable restore
#line 56 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
WriteAttributeValue("", 2165, item.prod_Stock, 2165, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2181, "\')", 2181, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button> |\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19724c5c7c7ea174457026ebc57d7ddd5a50383910941", async() => {
                WriteLiteral("Detalles");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                                                  WriteLiteral(item.prod_Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                        <button class=\"btn btn-danger\" id=\"btnEliminar\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2389, "\"", 2422, 3);
            WriteAttributeValue("", 2399, "eliminar(", 2399, 9, true);
#nullable restore
#line 58 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
WriteAttributeValue("", 2408, item.prod_Id, 2408, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2421, ")", 2421, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Borrar</button>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 61 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 67 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
Write(Html.Partial("_Modal_Create", new Maquillaje.Entities.Entities.VW_maqu_tbProductos_VW()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 69 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
Write(Html.Partial("_Modal_Edit", new Maquillaje.Entities.Entities.VW_maqu_tbProductos_VW()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 71 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
Write(Html.Partial("_Modal_Delete", new Maquillaje.Entities.Entities.VW_maqu_tbProductos_VW()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 73 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
 if (ViewBag.Script != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n        $(document).ready(function () {\r\n            ");
#nullable restore
#line 77 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"
       Write(Html.Raw(ViewBag.Script));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        });\r\n    </script>\r\n");
#nullable restore
#line 80 "C:\Users\Chris\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Producto\Index.cshtml"

    ViewBag.Script = null;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#menuMaquillaje\').addClass(\'active\');\r\n        $(\'#productosItem\').addClass(\'active\');\r\n        $(\'#subMenuMaquillaje\').addClass(\'show\');\r\n    });\r\n</script>");
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
