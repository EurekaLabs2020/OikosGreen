using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data;
using OikosGreenPortal.Data.Personal;
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
                var resultado = await General.solicitudUrl<LoginSend>("", "POST", Urls.urllogin, _login);
                //var resultado = await _http.PostAsJsonAsync(Urls.urllogin, _login);
                //var dato = resultado.Content.ReadAsStringAsync();
                if (resultado.IsSuccessStatusCode)
                {
                    AuthRequest resp = JsonConvert.DeserializeObject<AuthRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if(resp.entity==null)
                        await General.MensajeModal("Error Autenticación", resp.status.message, _modal);
                    else
                    {
                        //Obtenemos el Menu
                        var resultadoMenu = await General.solicitudUrl<LoginSend>(resp.entity.token, "POST", Urls.urlmenu, _login);
                        if (resultadoMenu.IsSuccessStatusCode)
                        {
                            var infoMenu = JsonConvert.DeserializeObject<PermissionRequest>(resultadoMenu.Content.ReadAsStringAsync().Result.ToString());
                            // Organizar el Menu y crear el data para guardar en el browser
                            await General.organizaMenu(infoMenu.entities);
                            infoBrowser data = new infoBrowser();
                            data.menus = General._retMenu;
                            data.roles = General._retRol;
                            data.user = resp.entity;

                            ((CustomAuthentication)_autenticacion).MarKUserAsAuthenticated(data);
                            await _storage.SetAsync("data", data);
                        }else
                            await General.MensajeModal("SIN INFORMACIÓN", "El usuario que esta usando no tiene acceso al menu.&sPor favor reintenar con otro usuario.", _modal);

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
