// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace OikosGreenPortal.Pages.Catalogo.Categorias
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Menu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise.DataGrid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Auth.login;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Reportes.Movimiento.Producto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.PersonalClass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Personal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Request;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Categorias\Categorias.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/catalogo/categorias")]
    public partial class Categorias : CategoriasBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
