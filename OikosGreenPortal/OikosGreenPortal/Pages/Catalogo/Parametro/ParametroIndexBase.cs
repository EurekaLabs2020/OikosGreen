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

namespace OikosGreenPortal.Pages.Catalogo.Parametro
{
    public class ParametroIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Parametro_data> _lista { get; set; }
        public Parametro_data _regActual { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        private infoBrowser _dataStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _mensajeIsDanger = "alert-danger";
            _lista = new List<Parametro_data>();
            _regActual = new Parametro_data();
            _Mensaje = "";
            ParametrosRequest _dataRequest = new ParametrosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlparametro_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<ParametrosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }


        #region Presentación
        public void estilofila(Parametro_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Parametro_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        public async Task insertaFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Parametro_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Parametro_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            var codigo = valores.Where(w => w.Key == "code").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.name = nombre;
            item.code = codigo;
            item.active = true;
            item.usercreate = _dataStorage.user.user;
            item.datecreate = DateTime.Now;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            try
            {
                _Mensaje = "";
                var resultadoValida = await General.solicitudUrl<Parametro_data>(_dataStorage.user.token, "POST", Urls.urlparametro_getbycode, item);
                ParametroRequest _dataRequestValida = JsonConvert.DeserializeObject<ParametroRequest>(resultadoValida.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestValida != null && _dataRequestValida.status.code != 200)
                {
                    var resultado = await General.solicitudUrl<Parametro_data>(_dataStorage.user.token, "POST", Urls.urlparametro_insert, item);
                    ParametroRequest _dataRequest = JsonConvert.DeserializeObject<ParametroRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
            catch (Exception) { item = new Parametro_data(); }
        }

        public async Task updateFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Parametro_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Parametro_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.name = nombre;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            try
            {
                var resultado = await General.solicitudUrl<Parametro_data>(_dataStorage.user.token, "POST", Urls.urlparametro_update, item);
                ParametroRequest _dataRequest = JsonConvert.DeserializeObject<ParametroRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;
            }
            catch (Exception) { item = new Parametro_data(); }
        }

        public async Task inactiveFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Parametro_data>)arg).Item;
            item.active = !item.active;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
            try
            {
                var resultado = await General.solicitudUrl<Parametro_data>(_dataStorage.user.token, "POST", Urls.urlparametro_inactive, item);
                ParametroRequest _dataRequest = JsonConvert.DeserializeObject<ParametroRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
