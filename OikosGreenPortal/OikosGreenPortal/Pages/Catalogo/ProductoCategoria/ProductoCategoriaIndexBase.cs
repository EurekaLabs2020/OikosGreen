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

namespace OikosGreenPortal.Pages.Catalogo.ProductoCategoria
{
    public class ProductoCategoriaIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<ProductoCategoria_data> _lista { get; set; }
        public List<Categoria_data> _listaCategoria { get; set; }
        public List<Producto_data> _listaProducto { get; set; }
        public ProductoCategoria_data _regActual { get; set; }

        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipo { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlproductocategoria_getall;
        private String urlinsert { get; set; } = Urls.urlproductocategoria_insert;
        private String urlupdate { get; set; } = Urls.urlproductocategoria_update;
        private String urlinactive { get; set; } = Urls.urlproductocategoria_inactive;
        private String urlgetcode { get; set; } = Urls.urlproductocategoria_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<ProductoCategoria_data>();
            _listaCategoria = null;
            _listaProducto = null;
            _Mensaje = "";
            _regActual = new ProductoCategoria_data();
            ProductoCategoriasRequest _dataRequest = new ProductoCategoriasRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<ProductoCategoriasRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                if (_lista != null && _lista.Count > 0)
                {
                    foreach (var reg in _lista)
                    {
                        reg.idcategory = reg.categoryid;
                        reg.idproduct = reg.productid;
                    }
                }
                // Obtenemos las Listas asociadas
                try
                {
                    var resultadoCategoria = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlcategoria_getall, "");
                    CategoriasRequest _dataRequestCategoria = JsonConvert.DeserializeObject<CategoriasRequest>(resultadoCategoria.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestCategoria != null && _dataRequestCategoria.entities != null && _dataRequestCategoria.entities.Count > 0)
                        _listaCategoria = _dataRequestCategoria.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal); }

                try
                {
                    var resultadoProducto = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlproducto_getall, "");
                    ProductosRequest _dataRequestProductos = JsonConvert.DeserializeObject<ProductosRequest>(resultadoProducto.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestProductos != null && _dataRequestProductos.entities != null && _dataRequestProductos.entities.Count > 0)
                        _listaProducto = _dataRequestProductos.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }

        #region Presentación
        public void estilofila(ProductoCategoria_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }


        public void filaSeleccionada(ProductoCategoria_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(ProductoCategoria_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.idcategory == 0)
                _Mensaje += "Por favor diligenciar el CATEGORIA, es un campo obligatorio.&s";
            if (_paraValidar.idproduct == 0)
                _Mensaje += "Por favor diligenciar el PRODUCTO, es un campo obligatorio.&s";

            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(ProductoCategoria_data data)
        {
            data.idcategory = 0;
            data.idproduct = 0;
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<ProductoCategoria_data, Dictionary<String, object>> e)
        {
            e.Item.categoryid = e.Item.idcategory;
            e.Item.productid = e.Item.idproduct;
            e.Item.id = await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<ProductoCategoria_data, Dictionary<String, object>> e)
        {
            e.Item.categoryid = e.Item.idcategory;
            e.Item.productid = e.Item.idproduct;
            await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(ProductoCategoria_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<ProductoCategoria_data>(_dataStorage.user.token, "POST", urlinactive, item);
                ProductoCategoriaRequest _dataRequest = JsonConvert.DeserializeObject<ProductoCategoriaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref ProductoCategoria_data item)
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

        private async Task<Int64> setUbicacion(ProductoCategoria_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Item.namecateg = _listaCategoria.Where(w => w.id == Item.idcategory).Select(s => s.name).FirstOrDefault();
            Item.nameprod = _listaProducto.Where(w => w.id == Item.idproduct).Select(s => s.name).FirstOrDefault();

            ProductoCategoria_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<ProductoCategoria_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                ProductoCategoriaRequest _dataRequestCode = JsonConvert.DeserializeObject<ProductoCategoriaRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<ProductoCategoria_data>(_dataStorage.user.token, "POST", Url, reg);
                        ProductoCategoriaRequest _dataRequest = JsonConvert.DeserializeObject<ProductoCategoriaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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

