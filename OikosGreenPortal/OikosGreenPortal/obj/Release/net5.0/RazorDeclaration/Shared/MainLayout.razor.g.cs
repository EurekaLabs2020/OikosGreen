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
#line 6 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Shared\MainLayout.razor"
using OikosGreenPortal.Pages.Auth.Cambiar_Clave;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "C:\Desarrollos\2. OikosGreen S.A\OikosGreen_Web\EurekaLabs2020\OikosGreen\OikosGreenPortal\OikosGreenPortal\Shared\MainLayout.razor"
          


        private infoBrowser userLogueado { get; set; }

        private async Task LogOut()
        {
            ((CustomAuthentication)_autenticacion).MarkUserAsLoggedOut();

        }

        public async Task changePass()
        {
            userLogueado = null;

            try
            {
                var resultado = await _storage.GetAsync<infoBrowser>("data");
                userLogueado = resultado.Value;

                var parameters = new ModalParameters();
                parameters.Add(nameof(NuevaClaveIndex.userLogueado), userLogueado);
                var formModal = _modal.Show<NuevaClaveIndex>("Cambio de Clave", parameters);
                var result = await formModal.Result;

            }
            catch (Exception ex)
            {

            }
        }

        private bool collapseNavMenu = false;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }


        public async Task SugerenciaTrueque()
        {
            try
            {
                var parameters = new ModalParameters();
                var formModal = _modal.Show<SugerenciaTruequeShared>($"Sugerencias para Trueque", parameters);
                var result = await formModal.Result;
                if (result.Cancelled)
                {
                    Console.WriteLine("Modal Cancelado");
                }
                //else
                //{
                //    TerceroTipo_data resultado = (TerceroTipo_data)result.Data;
                //    _datoTercero = resultado.idtercero;
                //    _listaTerc.Add(resultado);
                //}
            }
            catch (Exception ex)
            {

            }
        }


    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IModalService _modal { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider _autenticacion { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedSessionStorage _storage { get; set; }
    }
}
#pragma warning restore 1591
