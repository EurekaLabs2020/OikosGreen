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

namespace OikosGreenPortal.Pages.Catalogo.ListaDetalle
{
    public class ListaDetalleBase : ComponentBase
    {

        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<ListaDetalle_data> _lista { get; set; }
        public List<Lista_data> _listaSecundaria { get; set; }
        public List<Producto_data> _listaTercera { get; set; }
        public ListaDetalle_data _regActual { get; set; }

        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipo { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urllistadetalle_getall;
        private String urlinsert { get; set; } = Urls.urllistadetalle_insert;
        private String urlupdate { get; set; } = Urls.urllistadetalle_update;
        private String urlinactive { get; set; } = Urls.urllistadetalle_inactive;
        private String urlgetcode { get; set; } = Urls.urllistadetalle_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<ListaDetalle_data>();
            _listaSecundaria = null;
            _Mensaje = "";
            _regActual = new ListaDetalle_data();
            ListaDetallesRequest _dataRequest = new ListaDetallesRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<ListaDetallesRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                if (_lista != null && _lista.Count > 0)
                {
                    foreach (var reg in _lista)
                    {
                        reg.idlist = reg.listid;
                        reg.idproduct = reg.productid;
                    }
                }
                // Obtenemos la Lista Parametro
                try
                {
                    var resultadoLista = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urllista_getall, "");
                    ListasRequest  _dataRequestLista = JsonConvert.DeserializeObject<ListasRequest>(resultadoLista.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestLista != null && _dataRequestLista.entities != null && _dataRequestLista.entities.Count > 0)
                        _listaSecundaria = _dataRequestLista.entities;
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal); }
                // Obtenemos la Producto
                try
                {
                    var resultadoProd = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlproducto_getall, "");
                    ProductosRequest _dataRequestProd = JsonConvert.DeserializeObject<ProductosRequest>(resultadoProd.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestProd != null && _dataRequestProd.entities != null && _dataRequestProd.entities.Count > 0)
                        _listaTercera = _dataRequestProd.entities;
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }

        #region Presentación
        public void estilofila(ListaDetalle_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(ListaDetalle_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(ListaDetalle_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.idlist == null || _paraValidar.idlist== 0)
                _Mensaje += "Por favor diligenciar el LISTA, es un campo obligatorio.&s";
            if (_paraValidar.idproduct == null || _paraValidar.idproduct == 0)
                _Mensaje += "Por favor diligenciar el PRODUCTO, es un campo obligatorio.&s";

            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(ListaDetalle_data data)
        {
            data.idlist = data.idproduct = 0;
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<ListaDetalle_data, Dictionary<String, object>> e)
        {
            e.Item.listid = e.Item.idlist;
            e.Item.productid = e.Item.idproduct;
            e.Item.id = await setData(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<ListaDetalle_data, Dictionary<String, object>> e)
        {
            e.Item.listid = e.Item.idlist;
            e.Item.productid = e.Item.idproduct;
            await setData(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(ListaDetalle_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<ListaDetalle_data>(_dataStorage.user.token, "POST", urlinactive, item);
                ListaDetalleRequest _dataRequest = JsonConvert.DeserializeObject<ListaDetalleRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref ListaDetalle_data item)
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

        private async Task<Int64> setData(ListaDetalle_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Item.namelist = _listaSecundaria.Where(w => w.id == Item.idlist).Select(s => s.name).FirstOrDefault();
            Item.nameprod = _listaSecundaria.Where(w => w.id == Item.idproduct).Select(s => s.name).FirstOrDefault();
            ListaDetalle_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<ListaDetalle_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                ListaDetalleRequest _dataRequestCode = JsonConvert.DeserializeObject<ListaDetalleRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<ListaDetalle_data>(_dataStorage.user.token, "POST", Url, reg);
                        ListaDetalleRequest _dataRequest = JsonConvert.DeserializeObject<ListaDetalleRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
