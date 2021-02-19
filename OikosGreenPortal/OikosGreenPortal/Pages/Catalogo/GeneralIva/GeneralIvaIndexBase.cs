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

namespace OikosGreenPortal.Pages.Catalogo.GeneralIva
{
    public class GeneralIvaIndexBase : ComponentBase
    {

        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<GeneralIva_data> _lista { get; set; }
        public GeneralIva_data _regActual { get; set; }
        private infoBrowser _dataStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _lista = new List<GeneralIva_data>();
            _regActual = new GeneralIva_data();
            GeneralIvasRequest _dataRequest = new GeneralIvasRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlgeneraliva_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<GeneralIvasRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }


        public void estilofila(GeneralIva_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
        }

        public void filaSeleccionada(GeneralIva_data reg, DataGridRowStyling style)
        {
            style.Style = "background: green; color: yellow;";
        }

        public async Task insertaFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.GeneralIva_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.GeneralIva_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var valor = valores.Where(w => w.Key == "value").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            var codigo = valores.Where(w => w.Key == "code").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            var startdate = valores.Where(w => w.Key == "startdate").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            var enddate = valores.Where(w => w.Key == "enddate").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.value = Convert.ToDecimal(valor);
            item.code = codigo;
            item.startdate = Convert.ToDateTime(startdate);
            item.enddate = Convert.ToDateTime(enddate);
            item.active = true;
            item.usercreate = _dataStorage.user.user;
            item.datecreate = DateTime.Now;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            try
            {
                var resultado = await General.solicitudUrl<GeneralIva_data>(_dataStorage.user.token, "POST", Urls.urlgeneraliva_insert, item);
                GeneralIvaRequest _dataRequest = JsonConvert.DeserializeObject<GeneralIvaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;
            }
            catch (Exception) { item = new GeneralIva_data(); }
        }

        public async Task updateFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.GeneralIva_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.GeneralIva_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var valor = valores.Where(w => w.Key == "value").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            var codigo = valores.Where(w => w.Key == "code").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            var startdate = valores.Where(w => w.Key == "startdate").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            var enddate = valores.Where(w => w.Key == "enddate").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.value = Convert.ToDecimal(valor);
            item.code = codigo;
            item.startdate = Convert.ToDateTime(startdate);
            item.enddate = Convert.ToDateTime(enddate);
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            try
            {
                var resultado = await General.solicitudUrl<GeneralIva_data>(_dataStorage.user.token, "POST", Urls.urlgeneraliva_update, item);
                GeneralIvaRequest _dataRequest = JsonConvert.DeserializeObject<GeneralIvaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;

            }
            catch (Exception) { item = new GeneralIva_data(); }
        }

        public async Task inactiveFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.GeneralIva_data>)arg).Item;
            item.active = !item.active;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
            try
            {
                var resultado = await General.solicitudUrl<GeneralIva_data>(_dataStorage.user.token, "POST", Urls.urlgeneraliva_inactive, item);
                GeneralIvaRequest _dataRequest = JsonConvert.DeserializeObject<GeneralIvaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
