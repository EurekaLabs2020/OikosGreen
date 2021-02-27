﻿using Blazored.Modal.Services;
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

namespace OikosGreenPortal.Pages.Catalogo.TerceroPunto
{
    public class TerceroPuntoBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<TerceroPunto_data> _lista { get; set; }
        public List<Tercero_data> _listaSecundaria { get; set; }
        public TerceroPunto_data _regActual { get; set; }
        public List<String> _listaTipo { get; set; }
        public Int64 _datoPadre { get; set; }
        public String _datoTipo { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlterceropunto_getall;
        private String urlinsert { get; set; } = Urls.urlterceropunto_insert;
        private String urlupdate { get; set; } = Urls.urlterceropunto_update;
        private String urlinactive { get; set; } = Urls.urlterceropunto_inactive;
        private String urlgetcode { get; set; } = Urls.urlterceropunto_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<TerceroPunto_data>();
            _listaSecundaria = null;
            _datoPadre = 0;
            _Mensaje = _datoTipo = "";
            _regActual = new TerceroPunto_data();
            Periodos tipoUbica = new Periodos();
            _listaTipo = tipoUbica.listaPeriodos();
            TerceroPuntosRequest _dataRequest = new TerceroPuntosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<TerceroPuntosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities.OrderBy(o => o.nombrefull).OrderByDescending(o=>o.period).ToList();
                //Obtenemos la Tabla de Terceros
                try
                {
                    var resultadoTercero = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urltercero_getall, "");
                    TercerosRequest _dataRequestTercero = JsonConvert.DeserializeObject<TercerosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestTercero != null && _dataRequestTercero.entities != null && _dataRequestTercero.entities.Count > 0)
                        _listaSecundaria = _dataRequestTercero.entities.OrderBy(o => o.nombrefull).ToList();

                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }

        #region Presentación
        public void estilofila(TerceroPunto_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(TerceroPunto_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(TerceroPunto_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.period == null)
                _Mensaje += "Por favor diligenciar el TIPO, es un campo obligatorio.&s";
            if (_paraValidar.idtercero == null || _paraValidar.idtercero == 0)
                _Mensaje += "Por favor diligenciar el TERCERO, es un campo obligatorio.&s";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(TerceroPunto_data data)
        {
            _datoPadre = 0;
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<TerceroPunto_data, Dictionary<String, object>> e)
        {
            e.Item.id = await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<TerceroPunto_data, Dictionary<String, object>> e)
        {
            await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(TerceroPunto_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<TerceroPunto_data>(_dataStorage.user.token, "POST", urlinactive, item);
                TerceroPuntoRequest _dataRequest = JsonConvert.DeserializeObject<TerceroPuntoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref TerceroPunto_data item)
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

        private async Task<Int64> setUbicacion(TerceroPunto_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Item.period = _datoTipo;
            Item.idtercero = _datoPadre;
            Item.name = _lista.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
            Item.lastname = _lista.Where(w => w.id == _datoPadre).Select(s => s.lastname).FirstOrDefault();
            TerceroPunto_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<TerceroPunto_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                TerceroPuntoRequest _dataRequestCode = JsonConvert.DeserializeObject<TerceroPuntoRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<TerceroPunto_data>(_dataStorage.user.token, "POST", Url, reg);
                        TerceroPuntoRequest _dataRequest = JsonConvert.DeserializeObject<TerceroPuntoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
