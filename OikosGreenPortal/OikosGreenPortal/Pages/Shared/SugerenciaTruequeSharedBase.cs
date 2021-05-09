using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Shared
{
    public class SugerenciaTruequeSharedBase : ComponentBase
    {

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Producto_data> _listaSecundaria { get; set; }
        public Producto_data _regActual { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }



        public async Task cerrarModal()
        {
            await BlazoredModal.CloseAsync();
        }

    }
}
