using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.PersonalClass;

namespace OikosGreenPortal.Pages.Domicilio.Concepto
{
    public class ConceptoIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Concepto_data> _lista { get; set; }
        public List<String> _listaTipo { get; set; }
        public Concepto_data _regActual { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        public String _datoTipo { get; set; }
        private infoBrowser _dataStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _mensajeIsDanger = "alert-danger";
            _lista = new List<Concepto_data>();
            _regActual = new Concepto_data();
            _Mensaje = "";
            TipoConcepto tipos = new TipoConcepto();
            _listaTipo = tipos.tiposConceptos();
            ConceptosRequest _dataRequest = new ConceptosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlconcepto_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<ConceptosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }


        #region Presentación
        public void estilofila(Concepto_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Concepto_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        public async Task insertaFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Concepto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Concepto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "description").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            var tipo = valores.Where(w => w.Key == "type").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.description = nombre;
            item.type = tipo;
            item.active = true;
            item.usercreate = _dataStorage.user.user;
            item.datecreate = DateTime.Now;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            try
            {
                _Mensaje = "";
                var resultadoValida = await General.solicitudUrl<Concepto_data>(_dataStorage.user.token, "POST", Urls.urlconcepto_getbycode, item);
                ConceptoRequest _dataRequestValida = JsonConvert.DeserializeObject<ConceptoRequest>(resultadoValida.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestValida != null && _dataRequestValida.status.code != 200)
                {
                    var resultado = await General.solicitudUrl<Concepto_data>(_dataStorage.user.token, "POST", Urls.urlconcepto_insert, item);
                    ConceptoRequest _dataRequest = JsonConvert.DeserializeObject<ConceptoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                        item.id = _dataRequest.entity.id;
                }
                else if (_dataRequestValida == null)
                {
                    _Mensaje = "Error realizando validación";
                    ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
                }
                else if (_dataRequestValida.entity != null)
                {
                    _Mensaje = "El código se encuentra duplicado";
                    ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
                }
            }
            catch (Exception) { item = new Concepto_data(); }
        }

        public async Task updateFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Concepto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Concepto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "description").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            var tipo = valores.Where(w => w.Key == "type").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.description = nombre;
            item.type = tipo;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            try
            {
                var resultado = await General.solicitudUrl<Concepto_data>(_dataStorage.user.token, "POST", Urls.urlconcepto_update, item);
                ConceptoRequest _dataRequest = JsonConvert.DeserializeObject<ConceptoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;
            }
            catch (Exception) { item = new Concepto_data(); }
        }

        public async Task inactiveFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Concepto_data>)arg).Item;
            item.active = !item.active;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
            try
            {
                var resultado = await General.solicitudUrl<Concepto_data>(_dataStorage.user.token, "POST", Urls.urlconcepto_inactive, item);
                ConceptoRequest _dataRequest = JsonConvert.DeserializeObject<ConceptoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
