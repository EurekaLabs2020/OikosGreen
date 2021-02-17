using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.PersonalClass;
using Newtonsoft.Json;
using Blazorise.DataGrid;

namespace OikosGreenPortal.Pages.Catalogo.TipoProducto
{
    public class TipoProductoIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<TipoProducto_data> _lista { get; set; }
        public TipoProducto_data _regActual { get; set; }
        public PaginationTemplates<String> template { get; set; }


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<TipoProducto_data>();
            _regActual = new TipoProducto_data();
            TipoProductoRequest _dataRequest = new TipoProductoRequest();
            try
            {
                infoBrowser _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urltipoproducto_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<TipoProductoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }


        public void estilofila(TipoProducto_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
        }

        public void filaSeleccionada(TipoProducto_data reg, DataGridRowStyling style)
        {
            style.Style = "bacground: green; color: yellow;";
        }

        public async Task<Boolean> insertFila(TipoProducto_data reg)
        {
            Boolean retorno = true;
            if (reg.name.Trim().Length > 0)
            {
                retorno = false;
            }
            return retorno;
        }

    }
}
