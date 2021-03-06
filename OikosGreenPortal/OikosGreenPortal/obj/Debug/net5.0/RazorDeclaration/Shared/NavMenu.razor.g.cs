// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace OikosGreenPortal.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Menu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise.DataGrid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Auth.login;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.PersonalClass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Personal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Request;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 47 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Shared\NavMenu.razor"
           

        private bool collapseNavMenu = true;
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        private List<infoMenu> _lstMenu { get; set; }


        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }


        protected override async Task OnInitializedAsync()
        {
            infoBrowser userLogueado = null;
            _lstMenu = new List<infoMenu>();
            try
            {

                do
                {
                    var data = await _storage.GetAsync<infoBrowser>("data");
                    userLogueado = data.Value;
                } while (userLogueado == null);
                _lstMenu = userLogueado.menus;
                if (!userLogueado.roles.Any(a => a.rol.Contains("SISTEMAS")))
                    _lstMenu = _lstMenu.Where(w => w.permission.Substring(0, 1) == "1").ToList();

                if (_lstMenu == null || _lstMenu.Count == 0)
                {
                    await General.MensajeModal("Error", "Usuario no tiene un menu asociado.", _modal, _nav);
                    ((CustomAuthentication)_autenticacion).MarkUserAsLoggedOut();
                    //navigation.NavigateTo("/", true);
                }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("Error", "Se presento un error obteniendo el menu del usuario.&s" + ex.Message, _modal, _nav);
            }
            await base.OnInitializedAsync();
        }


    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _nav { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IModalService _modal { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider _autenticacion { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedSessionStorage _storage { get; set; }
    }
}
#pragma warning restore 1591
