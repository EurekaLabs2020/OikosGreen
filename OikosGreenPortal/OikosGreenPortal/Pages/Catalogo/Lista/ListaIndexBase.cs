using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.PersonalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Catalogo.Lista
{
    public class ListaIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Lista_data> _lista { get; set; }
        public Lista_data _regActual { get; set; }
        private infoBrowser _dataStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Lista_data>();
            _regActual = new Lista_data();
            ListasRequest _dataRequest = new ListasRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urllista_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<ListasRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }


        #region Presentación
        public void estilofila(Lista_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Lista_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        public async Task insertaFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Lista_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Lista_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.name = nombre;
            item.active = true;
            item.usercreate = _dataStorage.user.user;
            item.datecreate = DateTime.Now;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            try
            {
                var resultado = await General.solicitudUrl<Lista_data>(_dataStorage.user.token, "POST", Urls.urllista_insert, item);
                ListaRequest _dataRequest = JsonConvert.DeserializeObject<ListaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;
            }
            catch (Exception) { item = new Lista_data(); }
        }

        public async Task updateFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Lista_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Lista_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.name = nombre;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            try
            {
                var resultado = await General.solicitudUrl<Lista_data>(_dataStorage.user.token, "POST", Urls.urllista_update, item);
                ListaRequest _dataRequest = JsonConvert.DeserializeObject<ListaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;

            }
            catch (Exception) { item = new Lista_data(); }
        }

        public async Task inactiveFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Lista_data>)arg).Item;
            item.active = !item.active;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
            try
            {
                var resultado = await General.solicitudUrl<Lista_data>(_dataStorage.user.token, "POST", Urls.urllista_inactive, item);
                ListaRequest _dataRequest = JsonConvert.DeserializeObject<ListaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;
            }
            catch (Exception) { }
        }

        public void validaName(ValidatorEventArgs arg)
        {
            ValidationRule.IsUppercase(arg.Value.ToString());
            if (arg.Status == ValidationStatus.Error)
                arg.ErrorText = "El nombre debe de ser en letras mayusculas";
        }

    }
}
