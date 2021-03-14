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

namespace OikosGreenPortal.Pages.Domicilios.Entregas
{
    public class EntregasIndexBase : ComponentBase
    {
        [Inject] public IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }
        [Inject] public NavigationManager _nav { get; set; }

        public Boolean _mostrarDetalleEncabezado { get; set; }
        public Boolean _mostrarDetalleProductos { get; set; }
        public String _resumenDetalle { get; set; }
        public Int64 _datoTipo { get; set; }
        public String _datoTipoMvto { get; set; }
        public Int64 _datoClase { get; set; }
        public DateTime? _datoFecha { get; set; }
        public Int64 _datoBodegaOrig { get; set; }
        public Int64 _datoBodegadest { get; set; }
        public Int64 _datoTercero { get; set; }

        public List<Transaccion_data> _envio { get; set; }
        public List<Documento_data> _listaTipo { get; set; }
        public List<Producto_data> _listaProducto { get; set; }
        public List<Producto_data> _listaProductoOrig { get; set; }
        public List<String> _tipo { get; set; }
        public List<String> _tipoProv { get; set; }
        public List<String> _tipoMvto { get; set; }
        public List<Bodega_data> _listaOrig { get; set; }
        public List<Bodega_data> _listaDest { get; set; }
        public List<TerceroTipo_data> _listaTerc { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        public Boolean _enProductos { get; set; }
        public decimal _puntosTercero { get; set; }


        private infoBrowser _dataStorage { get; set; }
        private String urlgetall { get; set; } = Urls.urltercero_getall;
        private String urlinsert { get; set; } = Urls.urltercero_insert;
        private String urlupdate { get; set; } = Urls.urltercero_update;
        private String urlinactive { get; set; } = Urls.urltercero_inactive;
        private String urlgetcode { get; set; } = Urls.urltercero_getbycode;



        public List<Transaccion_Producto> _listaDetalleProducto { get; set; }
        public class Transaccion_Producto
        {
            public Int32 line { get; set; }
            public Decimal quantity { get; set; }
            public Decimal unitvaluebefore { get; set; }
            public Decimal univvalue { get; set; }
            public Decimal costvalue { get; set; }
            public Decimal valueiva { get; set; }
            public Decimal points { get; set; }
            public Int64 productoid { get; set; }
            public Int64 presentationid { get; set; }
            public Int64? ivaid { get; set; }
            public String prodNombre { get; set; }
            public String presNombre { get; set; }
            public Decimal ivaporc { get; set; }
            public Decimal stock { get; set; }
        }




        protected async override Task OnInitializedAsync()
        {
            _enProductos = false;
            _mostrarDetalleEncabezado = true;
            _mostrarDetalleProductos = false;
            _resumenDetalle = "...";
            _datoTipoMvto = "M";
            _datoTipo = _datoClase = 0;
            _puntosTercero = 0;
            _datoFecha = DateTime.Now;
            _envio = new List<Transaccion_data>();

            TipoDocumento tipo = new TipoDocumento();
            _tipo = tipo.tiposDocumentos();
            TipoTerceroTipo tipoUbica = new TipoTerceroTipo();
            _tipoProv = tipoUbica.tiposTerceroTipo();
            TipoMovimiento tipoMvto = new TipoMovimiento();
            _tipoMvto = tipoMvto.tiposMovimiento();

            DocumentosRequest _dataRequest = new DocumentosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urldocumento_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<DocumentosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _listaTipo = _dataRequest.entities.Where(w => w.type == _tipo[1]).ToList();
                //Obtiene la bodega
                var resultadoBodega = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlbodega_getall, "");
                BodegasRequest _dataRequestBodega = JsonConvert.DeserializeObject<BodegasRequest>(resultadoBodega.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestBodega != null && _dataRequestBodega.entities != null && _dataRequestBodega.entities.Count > 0)
                    _listaOrig = _listaDest = _dataRequestBodega.entities;
                //Obtiene Proveedor
                var resultadoProveedor = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urltercerotipo_getall, "");
                TercerosTipoRequest _dataRequestProveedor = JsonConvert.DeserializeObject<TercerosTipoRequest>(resultadoProveedor.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestProveedor != null && _dataRequestProveedor.entities != null && _dataRequestProveedor.entities.Count > 0)
                    _listaTerc = _dataRequestProveedor.entities.ToList();
                //Obtiene Productos
                var resultadoProducto = await General.solicitudUrl<String>("", "GET", Urls.urlproducto_getall, "");
                ProductosRequest _dataRequestProductos = JsonConvert.DeserializeObject<ProductosRequest>(resultadoProducto.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestProductos != null && _dataRequestProductos.entities != null && _dataRequestProductos.entities.Count > 0)
                    _listaProductoOrig = _dataRequestProductos.entities;
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }


        public async Task Regresar()
        {
            _nav.NavigateTo("/transaccion", true);
        }

        public async Task Detalle()
        {
            _mostrarDetalleEncabezado = !_mostrarDetalleEncabezado;

        }

        #region Detalle Productos
        public async Task creaEncabezado()
        {
            if (_datoTipo > 0 && _datoBodegaOrig > 0)
            {
                _mostrarDetalleEncabezado = true;
                _resumenDetalle = "";
                if (_datoTipo != 0)
                    _resumenDetalle += " Tipo :" + _listaTipo.Where(w => w.id == _datoTipo).Select(s => s.name).FirstOrDefault();
                if (_datoBodegaOrig != 0)
                    _resumenDetalle += "   Bod Orig :" + _listaOrig.Where(w => w.id == _datoBodegaOrig).Select(s => s.name).FirstOrDefault();
                if (_datoBodegadest != 0)
                    _resumenDetalle += "   Bod Dest :" + _listaDest.Where(w => w.id == _datoBodegadest).Select(s => s.name).FirstOrDefault();
                if (_datoTercero != 0)
                    _resumenDetalle += "   Prov :" + _listaTerc.Where(w => w.terceroid == _datoTercero).Select(s => s.name).FirstOrDefault();

                _listaDetalleProducto = new List<Transaccion_Producto>();
                var _typepro = _listaTipo.Where(a => a.id == _datoTipo).Select(s => s.typeproductid).FirstOrDefault();
                if (_typepro == null || _typepro == 0)
                    _listaProducto = _listaProductoOrig.OrderBy(o => o.name).ToList();
                else
                    _listaProducto = _listaProductoOrig.Where(w => w.typeproductid == (_listaTipo.Where(a => a.id == _datoTipo).Select(s => s.typeproductid).FirstOrDefault())).ToList();
                _mostrarDetalleProductos = true;
                _enProductos = true;

                /*Recorrer Productos*/
                //Consulta Saldo
                try
                {
                    SaldoProducto_data _envio = new SaldoProducto_data();
                    _envio.cellarid = _datoBodegaOrig;
                    var resultado = await General.solicitudUrl<SaldoProducto_data>(_dataStorage.user.token, "POST", Urls.urlsaldoproducto_getbycellar, _envio);
                    SaldoProductosRequest _dataRequest = JsonConvert.DeserializeObject<SaldoProductosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    {
                        foreach (var reg in _dataRequest.entities)
                        {
                            Producto_data prod = _listaProducto.Where(w => w.id == reg.productoid).FirstOrDefault();
                            if (prod != null)
                                prod.stock = reg.balancequantity;
                        }
                    }
                }
                catch (Exception ex) { }

                //Consulta Lista
                try
                {
                    Documento_data docume = _listaTipo.Where(w => w.id == _datoTipo).FirstOrDefault();
                    ListaDetalle_data _envio = new ListaDetalle_data();
                    _envio.idlista = _envio.listid = docume.listid.Value;
                    var resultado = await General.solicitudUrl<ListaDetalle_data>(_dataStorage.user.token, "POST", Urls.urllistadetalle_getbylistid, _envio);
                    ListaDetallesRequest _dataRequest = JsonConvert.DeserializeObject<ListaDetallesRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    {
                        foreach (var reg in _dataRequest.entities)
                        {
                            Producto_data prod = _listaProducto.Where(w => w.id == reg.productid).FirstOrDefault();
                            if (prod != null)
                            {
                                try
                                {
                                    prod.points = reg.value / Convert.ToDecimal(docume.valueparam);
                                }
                                catch (Exception dx) { prod.points = 1000; }
                            }
                        }
                    }
                }
                catch (Exception ex) { }


                // Pntos Tercero
                try
                {
                    TerceroPunto_data _envio = new TerceroPunto_data();
                    _envio.terceroid = _datoTercero;
                    var resultado = await General.solicitudUrl<TerceroPunto_data>(_dataStorage.user.token, "POST", Urls.urlterceropunto_getbytercid, _envio);
                    TerceroPuntoRequest _dataRequest = JsonConvert.DeserializeObject<TerceroPuntoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                        _puntosTercero = _dataRequest.entity.currentbalance.Value;
                }
                catch (Exception ex) { }



                Detalle();
            }
            else
                await General.MensajeModal("Información Incompleta", "Por favor dilicencie todas las casillas", _modal, _nav);
        }

        #region Presentación
        public void estilofila(Transaccion_Producto reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Transaccion_Producto reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        public void iniciaDatos(Transaccion_Producto data)
        {
            data.ivaid = data.productoid = data.presentationid = data.line = 0;
            data.costvalue = data.points = data.quantity = 0;
            data.ivaporc = data.unitvaluebefore = data.univvalue = data.valueiva = 0;
            data.presNombre = data.prodNombre = "";
        }

        public async Task insertFila(SavedRowItem<Transaccion_Producto, Dictionary<String, object>> e)
        {
            Producto_data prod = _listaProducto.Where(w => w.id == e.Item.productoid).FirstOrDefault();
            e.Item.prodNombre = prod.name;
            e.Item.presNombre = prod.namepresentation;
            e.Item.costvalue = prod.cost;
            e.Item.ivaid = prod.ivaid;
            e.Item.ivaporc = prod.valueiva.Value;
            e.Item.line = _listaDetalleProducto.Count();
        }

        public async Task insertingFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Pages.Transacciones.NuevaTransaccionBase.Transaccion_Producto>)arg).Item;
            var valor = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Pages.Transacciones.NuevaTransaccionBase.Transaccion_Producto, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var prod = _listaProducto.Where(w => w.id == Convert.ToInt64(valor["productoid"])).FirstOrDefault();
            if (prod.stock < Convert.ToDecimal(valor["quantity"].ToString()) && _listaTipo.Any(w => w.id == _datoTipo && w.affect == "S"))
            {
                ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
                await General.MensajeModal("Inventario Insuficiente", $"No hay inventario {prod.stock} para {valor["quantity"]}", _modal, _nav);
            }

            Decimal totalPuntos = _listaDetalleProducto.Sum(w => w.points);
            if (((_puntosTercero - totalPuntos) < (prod.points * Convert.ToDecimal(valor["quantity"].ToString()))) && _listaTipo.Any(w => w.id == _datoTipo && w.typeclass == "I") && _listaTipo.Any(w => w.id == _datoTipo && w.affect == "S"))
            {
                ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
                await General.MensajeModal("Puntos Insuficientes", $"Total Puntos en transaccion {totalPuntos}, puntos Producto {prod.points}", _modal, _nav);
            }

        }

        public async Task updateFila(SavedRowItem<Transaccion_Producto, Dictionary<String, object>> e)
        {
        }


        public async Task terminar()
        {
            if (await validaDatos() && _listaDetalleProducto.Count > 0)
            {
                foreach (var reg in _listaDetalleProducto)
                {
                    Transaccion_data nuevo = new Transaccion_data();
                    nuevo.cashierid = _dataStorage.user.iduser;
                    nuevo.cellardestid = _datoBodegadest;
                    nuevo.cellarid = _datoBodegaOrig;
                    nuevo.cellarorigid = _datoBodegaOrig;
                    nuevo.detline = reg.line;
                    nuevo.prodid = reg.productoid;
                    nuevo.docid = _datoTipo;
                    nuevo.date = _datoFecha.Value;
                    nuevo.quantity = reg.quantity;
                    nuevo.sellerid = _dataStorage.user.iduser;


                    nuevo.terceroid = _datoTercero == 0 ? 1 : _datoTercero;
                    nuevo.encaorigin = 0;
                    nuevo.typemoviment = _datoTipoMvto; //Mostrador-Domicilio-Web
                    try
                    {
                        nuevo.namepc = System.Net.Dns.GetHostName();
                    }
                    catch { nuevo.namepc = ""; }

                    nuevo.usermodify = nuevo.usercreate = _dataStorage.user.iduser;
                    nuevo.datemodify = nuevo.datecreate = DateTime.Now;
                    _envio.Add(nuevo);
                }
                // Envio a la Api
                try
                {
                    var resultado = await General.solicitudUrl<List<Transaccion_data>>(_dataStorage.user.token, "POST", Urls.urlcreatetransacc, _envio);
                    ResponsRequestLong _dataRequest = JsonConvert.DeserializeObject<ResponsRequestLong>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity > 0)
                    {
                        await General.MensajeModal("Transacción", $"Transaccion  de {_listaTipo.Where(w => w.id == _datoTipo).Select(s => s.name).FirstOrDefault()}  Número {_dataRequest.entity}. Creada con éxito!!!!", _modal, _nav, "/transaccion");
                    }

                }
                catch (Exception ex) { }
            }
        }


        public async Task<Boolean> validaDatos()
        {
            _Mensaje = "";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;

        }

        public async Task creaTercero()
        {

        }





        #endregion


    }
}
