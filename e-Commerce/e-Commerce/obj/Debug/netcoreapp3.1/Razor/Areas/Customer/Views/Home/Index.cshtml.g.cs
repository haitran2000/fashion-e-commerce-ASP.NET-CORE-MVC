#pragma checksum "C:\Users\H\Desktop\ASP.NET\E-commerce\e-Commerce\Areas\Customer\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76a9f94d4ea249eb4a04b938f7d52566174b9441"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\H\Desktop\ASP.NET\E-commerce\e-Commerce\Areas\Customer\Views\_ViewImports.cshtml"
using e_Commerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\H\Desktop\ASP.NET\E-commerce\e-Commerce\Areas\Customer\Views\_ViewImports.cshtml"
using e_Commerce.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\H\Desktop\ASP.NET\E-commerce\e-Commerce\Areas\Customer\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\H\Desktop\ASP.NET\E-commerce\e-Commerce\Areas\Customer\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76a9f94d4ea249eb4a04b938f7d52566174b9441", @"/Areas/Customer/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df5d1cf00a08d75038b16198d2dd1e96ddf0f026", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\" pos_home_section\">\n    <div class=\"row pos_home\">\n        <div class=\"col-lg-3 col-md-8 col-12\">\n            ");
#nullable restore
#line 4 "C:\Users\H\Desktop\ASP.NET\E-commerce\e-Commerce\Areas\Customer\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("Category"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div><vc:category-list /></div>\n        </div>\n        <div class=\"col-lg-9 col-md-12\">\n            ");
#nullable restore
#line 8 "C:\Users\H\Desktop\ASP.NET\E-commerce\e-Commerce\Areas\Customer\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("Product"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            ");
#nullable restore
#line 9 "C:\Users\H\Desktop\ASP.NET\E-commerce\e-Commerce\Areas\Customer\Views\Home\Index.cshtml"
       Write(await Html.PartialAsync("_BannerRightBottom.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            ");
#nullable restore
#line 10 "C:\Users\H\Desktop\ASP.NET\E-commerce\e-Commerce\Areas\Customer\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("Brand"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
