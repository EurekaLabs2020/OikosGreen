#pragma checksum "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0847e56d1ae070b333e805e35919306669881172"
// <auto-generated/>
#pragma warning disable 1591
namespace OikosGreenPortal.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Menu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise.DataGrid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Auth.login;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.PersonalClass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Personal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Request;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-3oecg0lfdj");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(3);
            __builder.AddAttribute(4, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "sidebar");
                __builder2.AddAttribute(7, "b-3oecg0lfdj");
                __builder2.OpenComponent<OikosGreenPortal.Shared.NavMenu>(8);
                __builder2.CloseComponent();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(9, "\r\n\r\n    ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "main");
            __builder.AddAttribute(12, "b-3oecg0lfdj");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(13);
            __builder.AddAttribute(14, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(15, "div");
                __builder2.AddAttribute(16, "class", "top-row px-4");
                __builder2.AddAttribute(17, "b-3oecg0lfdj");
                __builder2.OpenElement(18, "a");
                __builder2.AddAttribute(19, "href", "#!");
                __builder2.AddAttribute(20, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\Shared\MainLayout.razor"
                                           LogOut

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "b-3oecg0lfdj");
                __builder2.AddContent(22, "Salir");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(23, "\r\n        ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "content px-4");
            __builder.AddAttribute(26, "b-3oecg0lfdj");
            __builder.AddContent(27, 
#nullable restore
#line 24 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\Shared\MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "C:\Desarrollos\OikosGreen S.A\OikosGreen_Web\OikosGreenPortal\OikosGreenPortal\Shared\MainLayout.razor"
      


    private async Task LogOut()
    {
        ((CustomAuthentication)_autenticacion).MarkUserAsLoggedOut();
        
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider _autenticacion { get; set; }
    }
}
#pragma warning restore 1591
