#pragma checksum "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "171ff9c0dead071e103ee3483d5de0ee5be92e19"
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
#line 17 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Auth.login;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddAttribute(2, "b-xpioe6umow");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href b-xpioe6umow>OikosGreenPortal</a>\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "b-xpioe6umow");
            __builder.AddMarkupContent(8, "<span class=\"navbar-toggler-icon\" b-xpioe6umow></span>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", 
#nullable restore
#line 8 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Shared\NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Shared\NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "b-xpioe6umow");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "C:\Users\ancou\Source\Repos\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
