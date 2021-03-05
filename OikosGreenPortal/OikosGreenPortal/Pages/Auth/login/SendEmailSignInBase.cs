using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.PersonalClass;

namespace OikosGreenPortal.Pages.Auth.login
{
    public class SendEmailSignInBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }        
        [Inject] NavigationManager _nav { get; set; }

        public LoginRequest _usuario { get; set; } = new LoginRequest();
        public String Mensaje { get; set; } = "";
        
        protected async override Task OnInitializedAsync()
        {
            _usuario.user = "";
            await Task.Delay(1);
        }
        public async Task Enviar()
        {
            if (!String.IsNullOrEmpty(_usuario.user))
            {
                ResponsRequestBoolean _dataRequest = new ResponsRequestBoolean();
                var respuesta = await General.solicitudUrl<LoginRequest>("", "POST", Urls.urlsentemail,_usuario);
                _dataRequest = JsonConvert.DeserializeObject<ResponsRequestBoolean>(respuesta.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.status.code == 200)
                {
                    //Creamos la Autenticacion y obtenemos el Menu y Obtenemos el Usuario Logueado
                    await General.MensajeModal("Envio clave", "Su clave temporal se ha enviado al correo registrado.", _modal, _nav);
                }
                else
                {
                    //Mensaje de error
                    await General.MensajeModal("Confirmación", $"Error.&sCodigo={_dataRequest.status.code}.&s{_dataRequest.status.message}", _modal, _nav);
                }
            }
            else
                await General.MensajeModal("Confirmación", "No se ha ingresado ningun usuario.", _modal, _nav);
            _nav.NavigateTo("/", true);
        }
    }
}
