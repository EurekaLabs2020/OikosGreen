﻿using Blazored.Modal;
using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.Pages.Shared;
using OikosGreenPortal.PersonalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Catalogo.Tercero
{
    public class TerceroBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Tercero_data> _lista { get; set; }
        public List<Documento_data> _listaSecundaria { get; set; }
        public Tercero_data _regActual { get; set; }
        public List<String> _listaTipo { get; set; }

        public Int64 _datoPadre { get; set; }
        public String _datoTipo
        {
            get { return datoTipo; }
            set
            {
                datoTipo = value;
                _datoPadre = 0;
            }
        }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipo { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urltercero_getall;
        private String urlinsert { get; set; } = Urls.urltercero_insert;
        private String urlupdate { get; set; } = Urls.urltercero_update;
        private String urlinactive { get; set; } = Urls.urltercero_inactive;
        private String urlgetcode { get; set; } = Urls.urltercero_getbycode;

        public string customFilterValue { get; set; }


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Tercero_data>();
            _listaSecundaria = null;
            _datoPadre = 0;
            _Mensaje = "";
            _regActual = new Tercero_data();
            TipoDocumento tipo = new TipoDocumento();
            _listaTipo = tipo.tiposDocumentos();
            TercerosRequest _dataRequest = new TercerosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<TercerosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                // Obtenemos la Lista Ciudad
                try
                {
                    var resultadoDocumento = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urldocumento_getall, "");
                    DocumentosRequest _dataRequestDocumento = JsonConvert.DeserializeObject<DocumentosRequest>(resultadoDocumento.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestDocumento != null && _dataRequestDocumento.entities != null && _dataRequestDocumento.entities.Count > 0)
                        _listaSecundaria = _dataRequestDocumento.entities.Where(w => w.type == _listaTipo[0]).ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Presentación
        public void estilofila(Tercero_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Tercero_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(Tercero_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name == null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";
            if (_paraValidar.lastname == null)
                _Mensaje += "Por favor diligenciar el CODIGO, es un campo obligatorio.&s";
            if (_paraValidar.numdocument == null)
                _Mensaje += "Por favor diligenciar el NUMERO DOCUMENTO, es un campo obligatorio.&s";
            if (_paraValidar.documentoid == null || _paraValidar.documentoid == 0)
                _Mensaje += "Por favor diligenciar el TIPO DE DOCUMENTO, es un campo obligatorio.&s";
            if (_paraValidar.address == null)
                _Mensaje += "Por favor diligenciar la Dirección, es un campo obligatorio.&s";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(Tercero_data data)
        {
            _datoPadre = 0;
            _datoTipo = "0";
            data.birthdate = DateTime.Now;
            _Mensaje = "";
            data.iddocumento = 1;
            data.documentoid = 1;
        }

        public async Task insertFila(SavedRowItem<Tercero_data, Dictionary<String, object>> e)
        {
            e.Item.id = await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Tercero_data, Dictionary<String, object>> e)
        {
            await setUbicacion(e.Item, false, urlupdate);
        }


        public async Task insertingFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Tercero_data>)arg).Item;
            var valor = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Tercero_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            try
            {
                valor["birthdate"] = Convert.ToDateTime(valor["birthdate"].ToString()).ToString();
            }
            catch { item.birthdate = DateTime.Now; }
            item.cellphone = valor["cellphone"].ToString().ToUpper();
            //item.phone = valor["phone"].ToString().ToUpper();
            item.name = valor["name"].ToString().ToUpper().ToUpper();
            item.lastname = valor["lastname"].ToString().ToUpper().ToUpper();
            item.numdocument = valor["numdocument"].ToString().ToUpper();
            item.address = valor["address"].ToString().ToUpper();
            item.email = valor["email"] == null ? "": valor["email"].ToString().ToUpper();
            item.documentoid = Convert.ToInt64( valor["documentoid"].ToString());
            //item.birthdate = DateTime.Now;
            item.phone = item.cellphone;
            //try
            //{
            //    item.birthdate = Convert.ToDateTime(valor["birthdate"].ToString());
            //}
            //catch (Exception ex)
            //{
            //    await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            //}

            await setUbicacion(item, true, urlupdate);
        }



        public async Task updatingFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Tercero_data>)arg).Item;
            var valor = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Tercero_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            try
            {
                valor["birthdate"] = Convert.ToDateTime(valor["birthdate"].ToString()).ToString();
            }catch { item.birthdate = DateTime.Now; }
            item.cellphone = valor["cellphone"].ToString();
            item.phone = item.cellphone;//valor["phone"].ToString();
            item.name = valor["name"].ToString().ToUpper();
            item.lastname = valor["lastname"].ToString().ToUpper();
            item.numdocument = valor["numdocument"].ToString();
            item.address = valor["address"].ToString();
            item.email = valor["email"].ToString();
            //try{
            //    item.birthdate = Convert.ToDateTime(valor["birthdate"].ToString());
            //}catch(Exception ex){
            //    await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            //}

            await setUbicacion(item, false, urlupdate);
        }

        public async Task inactiveFila(Tercero_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", urlinactive, item);
                TerceroRequest _dataRequest = JsonConvert.DeserializeObject<TerceroRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Tercero_data item)
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

        private async Task<Int64> setUbicacion(Tercero_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Item.iddocumento= _datoPadre = Item.documentoid.Value;
            Item.namedocum = _listaSecundaria.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
            Item.name = Item.name.ToUpper();
            Item.lastname = Item.lastname.ToUpper();
            Item.address = Item.address.ToUpper();
            
            Item.email = Item.email== null ? "" : Item.email.ToUpper();
            Item.birthdate = Item.birthdate == null ? DateTime.Now : Item.birthdate;
            if(Crear)
            {
                Item.datecreate = DateTime.Now;
                Item.usercreate = _dataStorage.user.user;
            }
            Item.datemodify = DateTime.Now;
            Item.usermodify = _dataStorage.user.user;
            Tercero_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                TerceroRequest _dataRequestCode = JsonConvert.DeserializeObject<TerceroRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", Url, reg);
                        TerceroRequest _dataRequest = JsonConvert.DeserializeObject<TerceroRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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

        public async Task nuevoTercero()
        {
            try
            {
                var parameters = new ModalParameters();
                var formModal = _modal.Show<CreateTerceroShared>($"Crear Tercero", parameters);
                var result = await formModal.Result;
                if (result.Cancelled)
                {
                    Console.WriteLine("Modal Cancelado");
                }
                else
                {
                    TercerosRequest _dataRequest = new TercerosRequest();
                    var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                    _dataRequest = JsonConvert.DeserializeObject<TercerosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                        _lista = _dataRequest.entities;
                }
            }
            catch (Exception ex)
            {

            }
        }


        #region Filtro
        public bool OnCustomFilter(Tercero_data model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return
                model.name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.lastname?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.numdocument?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }
        #endregion


    }
}
