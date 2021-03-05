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

namespace OikosGreenPortal.Pages.Catalogo.ParametroDetalle
{
    public class ParametroDetalleBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<ParametroDetalle_data> _lista { get; set; }
        public List<Parametro_data> _listaSecundaria { get; set; }
        public ParametroDetalle_data _regActual { get; set; }
 
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipo { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlparametrodetalle_getall;
        private String urlinsert { get; set; } = Urls.urlparametrodetalle_insert;
        private String urlupdate { get; set; } = Urls.urlparametrodetalle_update;
        private String urlinactive { get; set; } = Urls.urlparametrodetalle_inactive;
        private String urlgetcode { get; set; } = Urls.urlparametrodetalle_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<ParametroDetalle_data>();
            _listaSecundaria = null;
            _Mensaje = "";
            _regActual = new ParametroDetalle_data();
            ParametroDetallesRequest _dataRequest = new ParametroDetallesRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<ParametroDetallesRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                if(_lista!=null && _lista.Count > 0)
                {
                    foreach (var reg in _lista)
                        reg.idparametro = reg.parametroid;
                }
                // Obtenemos la Lista Parametro
                try
                {
                    var resultadoParametro = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlparametro_getall, "");
                    ParametrosRequest _dataRequestParametro = JsonConvert.DeserializeObject<ParametrosRequest>(resultadoParametro.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestParametro != null && _dataRequestParametro.entities != null && _dataRequestParametro.entities.Count > 0)
                        _listaSecundaria = _dataRequestParametro.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Presentación
        public void estilofila(ParametroDetalle_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(ParametroDetalle_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(ParametroDetalle_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.idparametro == null || _paraValidar.idparametro==0)
                _Mensaje += "Por favor diligenciar el PARAMETRO, es un campo obligatorio.&s";
            if (_paraValidar.value == null)
                _Mensaje += "Por favor diligenciar el VALOR, es un campo obligatorio.&s";

            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(ParametroDetalle_data data)
        {
            data.idparametro = 0;
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<ParametroDetalle_data, Dictionary<String, object>> e)
        {
            e.Item.parametroid = e.Item.idparametro;
            e.Item.id = await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<ParametroDetalle_data, Dictionary<String, object>> e)
        {
            e.Item.parametroid = e.Item.idparametro;
            await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(ParametroDetalle_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<ParametroDetalle_data>(_dataStorage.user.token, "POST", urlinactive, item);
                ParametroDetalleRequest _dataRequest = JsonConvert.DeserializeObject<ParametroDetalleRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref ParametroDetalle_data item)
        {
            if (isNuevo)
            {
                item.usercreate = _dataStorage.user.user;
                item.datecreate = DateTime.Now;
                item.active = true;
            }
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
        }

        private async Task<Int64> setUbicacion(ParametroDetalle_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Item.nameparam = _listaSecundaria.Where(w => w.id == Item.idparametro).Select(s => s.name).FirstOrDefault();
            ParametroDetalle_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<ParametroDetalle_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                ParametroDetalleRequest _dataRequestCode = JsonConvert.DeserializeObject<ParametroDetalleRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<ParametroDetalle_data>(_dataStorage.user.token, "POST", Url, reg);
                        ParametroDetalleRequest _dataRequest = JsonConvert.DeserializeObject<ParametroDetalleRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                        if (_dataRequest != null && _dataRequest.status != null && _dataRequest.status.code == 200)
                        {
                            if (_dataRequest.entity != null && _dataRequest.entity.id > 0)
                            {
                                isok = true;
                                retorno = _dataRequest.entity.id;
                            }
                        }
                        else
                            _Mensaje = _dataRequest.status.message;
                    }
                    catch (Exception ex) { _Mensaje = ex.Message; }
                }
                else
                    _Mensaje = "Por favor revisar, el código se encuentra duplicado.&s";
            }
            StateHasChanged();
            if (!isok && Crear)
                _lista.Remove(reg);
            return retorno;
        }

    }
}
