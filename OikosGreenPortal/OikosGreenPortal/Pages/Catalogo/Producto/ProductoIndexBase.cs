﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.PersonalClass;

namespace OikosGreenPortal.Pages.Catalogo.Producto
{
    public class ProductoIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] IWebHostEnvironment _environment { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Producto_data> _lista { get; set; }
        public List<Presentacion_data> _listaPresentacion { get; set; }
        public List<Presentacion_data> _listaUnidadVenta { get; set; }
        public List<Presentacion_data> _listaUnidadCompra { get; set; }
        public List<Presentacion_data> _listaUnidadInventario { get; set; }
        public List<TipoProducto_data> _listaTipoProducto { get; set; }
        public List<GeneralIva_data> _listaGeneralIva { get; set; }
        public Producto_data _regActual { get; set; }
        public Producto_data _regCop { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        public String fileContent { get; set; }
        public string customFilterValue { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipo { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlproducto_getall;
        private String urlinsert { get; set; } = Urls.urlproducto_insert;
        private String urlupdate { get; set; } = Urls.urlproducto_update;
        private String urlinactive { get; set; } = Urls.urlproducto_inactive;
        private String urlgetcode { get; set; } = Urls.urlproducto_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = null;
            _listaPresentacion = null;
            _listaUnidadVenta = null;
            _listaUnidadCompra = null;
            _listaUnidadInventario = null;
            _listaTipoProducto = null;
            _listaGeneralIva = null;
            _Mensaje = "";
            _regActual = new Producto_data();
            ProductosRequest _dataRequest = new ProductosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>("", "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<ProductosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                if (_lista != null && _lista.Count > 0)
                {
                    foreach (var reg in _lista)
                    {
                        reg.idtypeproduct = reg.typeproductid == null ? 0 : reg.typeproductid.Value;
                        reg.idiva = reg.ivaid == null ? 0 : reg.ivaid.Value;
                    }
                }
                else
                    _lista = new List<Producto_data>();               
                // Obtenemos la Lista adicionales
                try
                {
                    var resultadoPresentacion = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlpresentacion_getall, "");
                    PresentacionesRequest _dataRequestPresentacion = JsonConvert.DeserializeObject<PresentacionesRequest>(resultadoPresentacion.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestPresentacion != null && _dataRequestPresentacion.entities != null && _dataRequestPresentacion.entities.Count > 0)
                        _listaPresentacion = _dataRequestPresentacion.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
                try
                {
                    var resultadoUnidadVenta = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlpresentacion_getall, "");
                    PresentacionesRequest _dataRequestUnidadVenta = JsonConvert.DeserializeObject<PresentacionesRequest>(resultadoUnidadVenta.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestUnidadVenta != null && _dataRequestUnidadVenta.entities != null && _dataRequestUnidadVenta.entities.Count > 0)
                        _listaUnidadVenta = _dataRequestUnidadVenta.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }

                try
                {
                    var resultadoUnidadCompra = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlpresentacion_getall, "");
                    PresentacionesRequest _dataRequestUnidadCompra = JsonConvert.DeserializeObject<PresentacionesRequest>(resultadoUnidadCompra.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestUnidadCompra != null && _dataRequestUnidadCompra.entities != null && _dataRequestUnidadCompra.entities.Count > 0)
                        _listaUnidadCompra = _dataRequestUnidadCompra.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }

                try
                {
                    var resultadoUnidadInventario = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlpresentacion_getall, "");
                    PresentacionesRequest _dataRequestUnidadInventario = JsonConvert.DeserializeObject<PresentacionesRequest>(resultadoUnidadInventario.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestUnidadInventario != null && _dataRequestUnidadInventario.entities != null && _dataRequestUnidadInventario.entities.Count > 0)
                        _listaUnidadInventario = _dataRequestUnidadInventario.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }

                try
                {
                    var resultadoTipoProducto = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urltipoproducto_getall, "");
                    TipoProductosRequest _dataRequestTipoProducto = JsonConvert.DeserializeObject<TipoProductosRequest>(resultadoTipoProducto.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestTipoProducto != null && _dataRequestTipoProducto.entities != null && _dataRequestTipoProducto.entities.Count > 0)
                        _listaTipoProducto = _dataRequestTipoProducto.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }

                try
                {
                    var resultadoIva = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlgeneraliva_getall, "");
                    GeneralIvasRequest _dataRequestIva = JsonConvert.DeserializeObject<GeneralIvasRequest>(resultadoIva.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestIva != null && _dataRequestIva.entities != null && _dataRequestIva.entities.Count > 0)
                        _listaGeneralIva = _dataRequestIva.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Cargar Archivo
        public async Task OnChanged(FileChangedEventArgs e)
        {
            try
            {
                foreach (var file in e.Files)
                {                   
                    using (var stream = new MemoryStream())
                    {
                        try
                        {
                            String Name = DateTime.Now.Date.ToShortDateString().Replace("/", "") + "_" + DateTime.Now.ToShortTimeString().Replace(":", "").Substring(0, DateTime.Now.ToShortTimeString().Replace(":", "").Length > 4 ? 4 : 3).Trim()+ "_" + file.Name.Trim();

                            var path = Path.Combine(_environment.WebRootPath, @"Uploads", Name);

                            using (FileStream archivo = new FileStream(path, FileMode.Create, FileAccess.Write))
                            {
                                stream.WriteTo(archivo);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                this.StateHasChanged();
            }
        }

        public void OnWritten(FileWrittenEventArgs e)
        {
            Console.WriteLine($"File: {e.File.Name} Position: {e.Position} Data: {Convert.ToBase64String(e.Data)}");
        }

        public void OnProgressed(FileProgressedEventArgs e)
        {
            Console.WriteLine($"File: {e.File.Name} Progress: {e.Percentage}");
        }
        #endregion

        #region Presentación
        public void estilofila(Producto_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Producto_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        public Boolean validaDatos(Producto_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name == null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";
            if (_paraValidar.code == null)
                _Mensaje += "Por favor diligenciar el CODIGO, es un campo obligatorio.&s";
            if (_paraValidar.presentationid == 0)
                _Mensaje += "Por favor diligenciar la PRESENTACIÓN, es un campo obligatorio.&s";
            if (_paraValidar.unitbuyid == 0)
                _Mensaje += "Por favor diligenciar la UNIDAD DE COMPRA, es un campo obligatorio.&s";
            if (_paraValidar.unitsaleid == 0)
                _Mensaje += "Por favor diligenciar la UNIDAD DE VENTA, es un campo obligatorio.&s";
            if (_paraValidar.unitinventoryid == 0)
                _Mensaje += "Por favor diligenciar la UNIDAD DE INVENTARIO, es un campo obligatorio.&s";
            if (_paraValidar.typeproductid == 0)
                _Mensaje += "Por favor diligenciar el TIPO DE PRODUCTO, es un campo obligatorio.&s";
            if (_paraValidar.ivaid == 0)
                _Mensaje += "Por favor diligenciar el IVA, es un campo obligatorio.&s";
            if (_paraValidar.cost == 0)
                _Mensaje += "Por favor diligenciar el COSTO, es un campo obligatorio.&s";

            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(Producto_data data)
        {
            _Mensaje = "";
            data.idiva = 0;
            data.idtypeproduct = 0;
            data.imagepath = "";
        }

        public async Task insertFila(SavedRowItem<Producto_data, Dictionary<String, object>> e)
        {           
            e.Item.typeproductid = e.Item.idtypeproduct;
            e.Item.ivaid = e.Item.idiva;
            e.Item.id = await setUbicacion(e.Item, true, urlinsert);
            e.Item.imagepath = e.Item.code.Trim() + ".png";
        }

        public async Task updateFila(SavedRowItem<Producto_data, Dictionary<String, object>> e)
        {
            e.Item.active = _regCop.active;  e.Item.codeiva = _regCop.codeiva; e.Item.cost = _regCop.cost; 
            e.Item.id = _regCop.id; e.Item.idtypeproduct = _regCop.idtypeproduct; e.Item.imagepath = _regCop.imagepath;
            e.Item.ivaid = _regCop.ivaid; e.Item.namepresentation = _regCop.namepresentation; e.Item.nametypeproduct = _regCop.nametypeproduct;
            e.Item.nameunitbuy = _regCop.nameunitbuy; e.Item.nameunitinventory = _regCop.nameunitinventory; e.Item.nameunitsale = _regCop.nameunitsale;
            e.Item.presentationid = _regCop.presentationid; e.Item.typeproductid = _regCop.typeproductid; e.Item.unitbuyid = _regCop.unitbuyid;
            e.Item.unitinventoryid = _regCop.unitinventoryid; e.Item.unitsaleid = _regCop.unitsaleid;
            e.Item.code = _regCop.code;

            e.Item.typeproductid = e.Item.idtypeproduct;
            e.Item.ivaid = e.Item.idiva;
            e.Item.imagepath = e.Item.code.Trim() + ".png";            
            await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task updatingFila(EventArgs arg)
        {
            //nombre, desctipcion, costo, iva, 
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Producto_data>)arg).Item;
            var valor = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Producto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            //_regCop = item;
            _regCop = new Producto_data();
            _regCop.active = item.active; _regCop.codeiva = item.codeiva; _regCop.cost = item.cost;
            _regCop.id = item.id; _regCop.idtypeproduct = item.idtypeproduct; _regCop.imagepath = item.imagepath;
            _regCop.ivaid = item.ivaid; _regCop.namepresentation = item.namepresentation; _regCop.nametypeproduct = item.nametypeproduct;
            _regCop.nameunitbuy = item.nameunitbuy; _regCop.nameunitinventory = item.nameunitinventory; _regCop.nameunitsale = item.nameunitsale;
            _regCop.presentationid = item.presentationid; _regCop.typeproductid = item.typeproductid; _regCop.unitbuyid = item.unitbuyid;
            _regCop.unitinventoryid = item.unitinventoryid; _regCop.unitsaleid = item.unitsaleid; _regCop.code = item.code;

            /*valor.Remove("code");
            valor.Remove("unitbuyid");
            valor.Remove("unitsaleid");
            valor.Remove("unitinventoryid");
            valor.Remove("idtypeproduct");
            valor.Remove("presentationid");*/
        }


        public async Task inactiveFila(Producto_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<Producto_data>(_dataStorage.user.token, "POST", urlinactive, item);
                ProductoRequest _dataRequest = JsonConvert.DeserializeObject<ProductoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Producto_data item)
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

        private async Task<Int64> setUbicacion(Producto_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            if(Crear)
                Item.code = Item.code.ToUpper();
            Item.name = Item.name.ToUpper();
            Item.description = Item.description.ToUpper();
            Item.nametypeproduct = _listaTipoProducto.Where(w => w.id == Item.typeproductid).Select(s => s.name).FirstOrDefault();
            try
            {
                Item.cost = Item.cost;
            }
            catch { Item.cost = 0; }
            Item.namepresentation = _listaPresentacion.Where(w => w.id == Item.presentationid).Select(s => s.name).FirstOrDefault();
            Item.nameunitsale = _listaUnidadVenta.Where(w => w.id == Item.unitsaleid).Select(s => s.name).FirstOrDefault();
            Item.nameunitbuy = _listaUnidadCompra.Where(w => w.id == Item.unitbuyid).Select(s => s.name).FirstOrDefault();
            Item.nameunitinventory = _listaUnidadInventario.Where(w => w.id == Item.unitinventoryid).Select(s => s.name).FirstOrDefault();
            Producto_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<Producto_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                ProductoRequest _dataRequestCode = JsonConvert.DeserializeObject<ProductoRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Producto_data>(_dataStorage.user.token, "POST", Url, reg);
                        ProductoRequest _dataRequest = JsonConvert.DeserializeObject<ProductoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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

        #region Filtro
        public bool OnCustomFilter(Producto_data model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return
                model.name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.code?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.nametypeproduct?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
        }
        #endregion


    }
}
