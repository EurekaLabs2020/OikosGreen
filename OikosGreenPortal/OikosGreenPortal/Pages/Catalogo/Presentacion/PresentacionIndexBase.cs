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

namespace OikosGreenPortal.Pages.Catalogo.Presentacion
{
    public class PresentacionIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Presentacion_data> _lista { get; set; }
        public Presentacion_data _regActual { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        private infoBrowser _dataStorage { get; set; }


        protected async override Task OnInitializedAsync() 
        {
            _mensajeIsDanger = "alert-danger";
            _lista = new List<Presentacion_data>();
            _regActual = new Presentacion_data();
            PresentacionesRequest _dataRequest = new PresentacionesRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlpresentacion_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<PresentacionesRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Presentación
        public void estilofila(Presentacion_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Presentacion_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        public async Task insertaFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Presentacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Presentacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.name = nombre;
            item.active = true;
            item.usercreate = _dataStorage.user.user;
            item.datecreate = DateTime.Now;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            try
            {
                var resultadoCode = await General.solicitudUrl<Presentacion_data>(_dataStorage.user.token, "POST", Urls.urlpresentacion_getbycode, item);
                PresentacionRequest _dataRequestCode = JsonConvert.DeserializeObject<PresentacionRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && _dataRequestCode.status.code != 200)
                {
                    var resultado = await General.solicitudUrl<Presentacion_data>(_dataStorage.user.token, "POST", Urls.urlpresentacion_insert, item);
                    PresentacionRequest _dataRequest = JsonConvert.DeserializeObject<PresentacionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                        item.id = _dataRequest.entity.id;
                }
                else
                {
                    _Mensaje = "Por favor revisar, el código se encuentra duplicado.&s";
                    ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
                }
            }
            catch (Exception) { item = new Presentacion_data(); }
        }

        public async Task updateFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Presentacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Presentacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.name = nombre;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            if (validaDatos(item))
            {
                try
                {
                    var resultado = await General.solicitudUrl<Presentacion_data>(_dataStorage.user.token, "POST", Urls.urlpresentacion_update, item);
                    PresentacionRequest _dataRequest = JsonConvert.DeserializeObject<PresentacionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                        item.id = _dataRequest.entity.id;

                }
                catch (Exception) { item = new Presentacion_data(); }
            }
        }

        public async Task inactiveFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Presentacion_data>)arg).Item;
            item.active = !item.active;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
            try
            {
                var resultado = await General.solicitudUrl<Presentacion_data>(_dataStorage.user.token, "POST", Urls.urlpresentacion_inactive, item);
                PresentacionRequest _dataRequest = JsonConvert.DeserializeObject<PresentacionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;
            }
            catch (Exception) { }
        }

        public Boolean validaDatos(Presentacion_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name == null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }
    }
}
