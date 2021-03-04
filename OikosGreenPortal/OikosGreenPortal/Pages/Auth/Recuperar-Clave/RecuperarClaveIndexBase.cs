using Microsoft.AspNetCore.Components;
using OikosGreenPortal.Data.Send;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Auth.Recuperar_Clave
{
    public class RecuperarClaveIndexBase: ComponentBase
    {
        public ForgotPassword _usuario { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _usuario = new ForgotPassword();
        }
        public async Task Enviar()
        {

        }
    }
}
