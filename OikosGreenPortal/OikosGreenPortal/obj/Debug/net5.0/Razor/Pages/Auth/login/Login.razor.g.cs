#pragma checksum "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Auth\login\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c0186034586e6639ae307a26a17bc017b1fe0d9"
// <auto-generated/>
#pragma warning disable 1591
namespace OikosGreenPortal.Pages.Auth.login
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Menu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Auth.login;

#line default
#line hidden
#nullable disable
    public partial class Login : LoginBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container-fluid");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "row align-items-center");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "col-md-4");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "id", "login");
            __builder.AddMarkupContent(8, "<img src=\"img/short-logo.jpeg\" class=\"short-logo-login-oikos\" alt=\"Alternate Text\">\r\n                ");
            __builder.AddMarkupContent(9, "<h2>Ingresar</h2>\r\n                ");
            __builder.OpenComponent<Blazorise.Field>(10);
            __builder.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Blazorise.TextEdit>(12);
                __builder2.AddAttribute(13, "Placeholder", "Usuario");
                __builder2.AddAttribute(14, "Role", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.TextRole>(
#nullable restore
#line 11 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Auth\login\Login.razor"
                                                          TextRole.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(15, "\r\n\r\n                ");
            __builder.OpenComponent<Blazorise.Field>(16);
            __builder.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Blazorise.TextEdit>(18);
                __builder2.AddAttribute(19, "Placeholder", "Contraseña");
                __builder2.AddAttribute(20, "Role", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.TextRole>(
#nullable restore
#line 15 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Auth\login\Login.razor"
                                                             TextRole.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(21, "\r\n\r\n                ");
            __builder.OpenComponent<Blazorise.Button>(22);
            __builder.AddAttribute(23, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 18 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Auth\login\Login.razor"
                               Color.Primary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "Block", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 18 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Auth\login\Login.razor"
                                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(25, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(26, "Ingresar");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n        ");
            __builder.AddMarkupContent(28, "<div class=\"col-md-8 align-items-center bg-login-right\"><div class=\"text-oikos-login\"><h1>Oikos Green</h1>\r\n                <h2>Cuidamos el planeta</h2></div>\r\n            <div class=\"decoration\"></div></div>");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
