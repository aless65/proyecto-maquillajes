#pragma checksum "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25ae4755f35d3f845303a097505a1a3eea2c91df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Proveedor_Index), @"mvc.1.0.view", @"/Views/Proveedor/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25ae4755f35d3f845303a097505a1a3eea2c91df", @"/Views/Proveedor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ddf7d49a7b3cb184fc0256cd04aa919d9687b41", @"/Views/_ViewImports.cshtml")]
    public class Views_Proveedor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Maquillaje.Entities.Entities.VW_maqu_tbProveedores_VW>>
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
#line 3 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card"">
    <div class=""card-header""><h1>Proveedores</h1></div>
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
#line 18 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.prov_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 21 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.prov_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 24 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.prov_CorreoElectronico));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 27 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.prov_Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.prov_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.prov_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 43 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.prov_CorreoElectronico));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 46 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.prov_Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <button type=\"button\" id=\"btnEditar\" class=\"btn btn-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1881, "\"", 1989, 9);
            WriteAttributeValue("", 1891, "AbrirModalEdit(\'", 1891, 16, true);
#nullable restore
#line 49 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
WriteAttributeValue("", 1907, item.prov_Id, 1907, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1920, ",", 1920, 1, true);
#nullable restore
#line 49 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
WriteAttributeValue("", 1921, item.prov_Nombre, 1921, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1938, ",", 1938, 1, true);
#nullable restore
#line 49 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
WriteAttributeValue("", 1939, item.prov_CorreoElectronico, 1939, 28, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1967, ",", 1967, 1, true);
#nullable restore
#line 49 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
WriteAttributeValue("", 1968, item.prov_Telefono, 1968, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1987, "\')", 1987, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button> |\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25ae4755f35d3f845303a097505a1a3eea2c91df9693", async() => {
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
#line 50 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                                                      WriteLiteral(item.prov_Id);

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
            WriteLiteral(" |\r\n                            <button class=\"btn btn-danger\" id=\"btnEliminar\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2203, "\"", 2236, 3);
            WriteAttributeValue("", 2213, "eliminar(", 2213, 9, true);
#nullable restore
#line 51 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
WriteAttributeValue("", 2222, item.prov_Id, 2222, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2235, ")", 2235, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Borrar</button>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 54 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 61 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
Write(Html.Partial("_Modal_Create", new Maquillaje.Entities.Entities.VW_maqu_tbProveedores_VW()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 63 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
Write(Html.Partial("_Modal_Edit", new Maquillaje.Entities.Entities.VW_maqu_tbProveedores_VW()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 65 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
Write(Html.Partial("_Modal_Delete", new Maquillaje.Entities.Entities.VW_maqu_tbProveedores_VW()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 67 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
 if (ViewBag.Script != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n        $(document).ready(function () {\r\n            ");
#nullable restore
#line 71 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"
       Write(Html.Raw(ViewBag.Script));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        });\r\n    </script>\r\n");
#nullable restore
#line 74 "C:\Users\LAB01\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\Proveedor\Index.cshtml"

    ViewBag.Script = null;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#menuMaquillaje\').addClass(\'active\');\r\n        $(\'#proveedoresItem\').addClass(\'active\');\r\n        $(\'#subMenuMaquillaje\').addClass(\'show\');\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Maquillaje.Entities.Entities.VW_maqu_tbProveedores_VW>> Html { get; private set; }
    }
}
#pragma warning restore 1591
