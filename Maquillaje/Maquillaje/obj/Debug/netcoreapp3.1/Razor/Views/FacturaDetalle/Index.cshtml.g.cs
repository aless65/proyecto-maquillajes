#pragma checksum "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9de410a412d8b843411b2bd0906d308435a7ec92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FacturaDetalle_Index), @"mvc.1.0.view", @"/Views/FacturaDetalle/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9de410a412d8b843411b2bd0906d308435a7ec92", @"/Views/FacturaDetalle/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ddf7d49a7b3cb184fc0256cd04aa919d9687b41", @"/Views/_ViewImports.cshtml")]
    public class Views_FacturaDetalle_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Maquillaje.Entities.Entities.VW_tbFacturasDetalles_List>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 9 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.fact_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 12 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.prod_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 15 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.factdeta_Cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 18 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.factdeta_Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 24 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 28 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.fact_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 31 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.prod_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 34 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.factdeta_Cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.factdeta_Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n");
            WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 45 "C:\Users\PC\Documents\GitHub\proyecto-maquillajes\Maquillaje\Maquillaje\Views\FacturaDetalle\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Maquillaje.Entities.Entities.VW_tbFacturasDetalles_List>> Html { get; private set; }
    }
}
#pragma warning restore 1591
