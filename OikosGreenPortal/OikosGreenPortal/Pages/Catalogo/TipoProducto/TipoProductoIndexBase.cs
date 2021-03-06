﻿using Blazored.Modal.Services;
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
using Blazorise;

namespace OikosGreenPortal.Pages.Catalogo.TipoProducto
{
    public class TipoProductoIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        public List<TipoProducto_data> _lista { get; set; }
        public TipoProducto_data _regActual { get; set; }
        public string customFilterValue { get; set; } /// Variable para Filtro
        private infoBrowser _dataStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _mensajeIsDanger = "alert-danger";
            _lista = new List<TipoProducto_data>();
            _regActual = new TipoProducto_data();
            _Mensaje = "";
            TipoProductosRequest _dataRequest = new TipoProductosRequest();
            try
            { 
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urltipoproducto_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<TipoProductosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }
        public Boolean validaDatos(TipoProducto_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name == null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";

            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        #region Presentación
        public void estilofila(TipoProducto_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(TipoProducto_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        public async Task insertaFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TipoProducto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TipoProducto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.name = nombre;
            item.active = true;
            item.usercreate = _dataStorage.user.user;
            item.datecreate = DateTime.Now;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            if (validaDatos(item))
            {
                try
                {
                    _Mensaje = "";
                    var resultadoValida = await General.solicitudUrl<TipoProducto_data>(_dataStorage.user.token, "POST", Urls.urltipoproducto_getbycode, item);
                    TipoProductoRequest _dataRequestValida = JsonConvert.DeserializeObject<TipoProductoRequest>(resultadoValida.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestValida != null && _dataRequestValida.status.code != 200)
                    {
                        var resultado = await General.solicitudUrl<TipoProducto_data>(_dataStorage.user.token, "POST", Urls.urltipoproducto_insert, item);
                        TipoProductoRequest _dataRequest = JsonConvert.DeserializeObject<TipoProductoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
                catch (Exception) { item = new TipoProducto_data(); }
            }
        }

        public async Task updateFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TipoProducto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TipoProducto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
            item.name = nombre;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            if (validaDatos(item))
            {
                try
                {
                    var resultado = await General.solicitudUrl<TipoProducto_data>(_dataStorage.user.token, "POST", Urls.urltipoproducto_update, item);
                    TipoProductoRequest _dataRequest = JsonConvert.DeserializeObject<TipoProductoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                        item.id = _dataRequest.entity.id;  
                }
                catch (Exception) { item = new TipoProducto_data(); }
            }
        
        }

        public async Task inactiveFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TipoProducto_data>)arg).Item;
            item.active = !item.active;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
            try
            {
                var resultado = await General.solicitudUrl<TipoProducto_data>(_dataStorage.user.token, "POST", Urls.urltipoproducto_inactive, item);
                TipoProductoRequest _dataRequest = JsonConvert.DeserializeObject<TipoProductoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;
            }
            catch (Exception) {  } 
        }
        #region Filtro
        public bool OnCustomFilter(TipoProducto_data model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return
                model.name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }
        #endregion
    }
}
