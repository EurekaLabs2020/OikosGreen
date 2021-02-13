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


        public LoginSend _login { get; set; }


        protected async override Task OnInitializedAsync()
        {
            _login = new LoginSend();
            _login.user = _login.password = "";            
        }

        public async Task Logueo()
        {
            if(_login.user.Trim().Length>0 && _login.password.Trim().Length > 0)
            {
                var resultado = await _http.PostAsJsonAsync(Urls.urllogin, _login);
                var dato = resultado.Content.ReadAsStringAsync();
                if (resultado.IsSuccessStatusCode)
                {
                    AuthRequest resp = JsonConvert.DeserializeObject<AuthRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if(resp.entity==null)
                        await General.MensajeModal("Error Autenticación", resp.status.message, _modal);
                    else
                    {
                        //Obtenemos el Menu

                        ((CustomAuthentication)_autenticacion).MarKUserAsAuthenticated(resp.entity);
                        await _storage.SetAsync("data", resp.entity);                        
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
