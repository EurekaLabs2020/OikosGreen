using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.Data.Send;
using OikosGreenPortal.PersonalClass;

namespace OikosGreenPortal.Pages.Auth.Cambiar_Clave
{
    public class NuevaClaveIndexBase : ComponentBase
    {
        [CascadingParameter] public BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public infoBrowser userLogueado { get; set; }
        public ChangePassword _usuario { get; set; }
        public String Mensaje { get; set; } = "";
        public Boolean _mostrarPassword { get; set; } = true;
        public Boolean _mostrarPassword2 { get; set; } = true;
        public Boolean _mostrarPassword3 { get; set; } = true;
        [Inject] public ProtectedSessionStorage _sessionStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _usuario = new ChangePassword();
            await Cargue();
        }
        private async Task Cargue()
        {
            await Task.Delay(1);
        }
        public async Task togglePassTMP()
        {
            _mostrarPassword = !_mostrarPassword;
        }

        public async Task togglePass()
        {
            _mostrarPassword2 = !_mostrarPassword2;
        }

        public async Task toggleConfirmPass()
        {
            _mostrarPassword3 = !_mostrarPassword3;
        }

        public async Task changePass()
        {
            if (_usuario.password == _usuario.passwordconfirm)
            {
                String statusApi = "";
                try
                {
                    ChangePassword changePass = new ChangePassword();
                    _usuario.user = userLogueado.user.user;
                    var resultado = await General.solicitudUrl<ChangePassword>(userLogueado.user.token, "POST", Urls.urlchange_Pass, _usuario);
                    ResponsRequestBoolean respAuth = JsonConvert.DeserializeObject<ResponsRequestBoolean>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (respAuth != null && respAuth.status != null && respAuth.status.code == 200)
                    {
                        Mensaje = "Contraseña cambiada con éxito!!!";
                        StateHasChanged();
                    }
                    else if (!String.IsNullOrEmpty(statusApi))
                        Mensaje = "ERROR " + statusApi;
                    else
                        Mensaje = "ERROR " + respAuth.status.message + " VALIDE SU CONTRASEÑA ACTUAL";
                }
                catch (Exception ex)
                {
                    Mensaje = "ERROR CONSULTANDO DATOS" + ex.Message;
                }
            }
            else
            {
                Mensaje = "CONTRASEÑAS NO COINCIDEN";

            }

        }



    }
}
