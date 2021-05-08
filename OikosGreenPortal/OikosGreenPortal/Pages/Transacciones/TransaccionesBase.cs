using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.Data.Send;
using OikosGreenPortal.PersonalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Transacciones
{
    public class TransaccionesBase : ComponentBase
    {
        [Inject] public IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }
        [Inject] public NavigationManager _navigation { get; set; }


        public List<Transaccion_data> _lista { get; set; }
        public String _Mensaje { get; set; }
        public string customFilterValue { get; set; }

        private infoBrowser _dataStorage { get; set; }



        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Transaccion_data>();
            _Mensaje = "";
            TransaccionSend envio = new TransaccionSend();
            envio.number = 100;
            TransaccionRequest _dataRequest = new TransaccionRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<TransaccionSend>(_dataStorage.user.token, "POST", Urls.urltransaccion_gettransaccbyitem, envio);
                _dataRequest = JsonConvert.DeserializeObject<TransaccionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities.OrderByDescending(o => o.date).ToList();
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }



        #region Presentación
        public void estilofila(Transaccion_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Transaccion_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        #region Filtro
        public bool OnCustomFilter(Transaccion_data model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return
                model.name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.tercname?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.tercnumdocument?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.prodname?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.prodivacode?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.terclastname?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }
        #endregion

    }
}
