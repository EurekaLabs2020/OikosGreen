using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.Data.Send;
using OikosGreenPortal.Helpers;
using OikosGreenPortal.PersonalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Auth.login
{
    public class LoginBase: ComponentBase
    {
        [Inject] public HttpClient _http { get; set; }
        [Inject] IModalService _modal { get; set; }
        [Inject] public AuthenticationStateProvider _autenticacion { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }
        [Inject] public NavigationManager _navegacion { get; set; }


        public LoginSend _login { get; set; }

        private Task<AuthenticationState> authenticationStateTask { get; set; }
        private string _authMessage;


        protected async override Task OnInitializedAsync()
        {
            _login = new LoginSend();
            _login.user = _login.password = "";
            await Task.Delay(1);
        }

        private async Task LogUsername()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                _authMessage = $"{user.Identity.Name} is authenticated.";
            }
            else
            {
                _authMessage = "The user is NOT authenticated.";
            }
        }

        public async Task Logueo()
        {
            if(_login.user.Trim().Length>0 && _login.password.Trim().Length > 0)
            {
                var resultado = await _http.PostAsJsonAsync(Urls.urllogin, _login);
                var dato = resultado.Content.ReadAsStringAsync();
                if (resultado.IsSuccessStatusCode)
                {
                    AuthRequest token = JsonConvert.DeserializeObject<AuthRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if(token.responseLogin==null)
                        await General.MensajeModal("Error Autenticación", token.status.message, _modal);
                    else
                    {
                        ((CustomAuthentication)_autenticacion).MarKUserAsAuthenticated(token.responseLogin);
                        await _storage.SetAsync("data", token.responseLogin);
                        _navegacion.NavigateTo("/", true);
                    }
                }
                else
                {
                    ResponsRequest r = JsonConvert.DeserializeObject<ResponsRequest>((JsonConvert.DeserializeObject(resultado.Content.ReadAsStringAsync().Result.ToString())).ToString());
                    await General.MensajeModal("Error", r.status.message, _modal);
                }                
            }else
                await General.MensajeModal("SIN INFORMACIÓN", "Por favor ingrese los datos del usuario.", _modal);
        }

    }
}
