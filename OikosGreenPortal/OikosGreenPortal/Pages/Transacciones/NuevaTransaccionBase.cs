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

namespace OikosGreenPortal.Pages.Transacciones
{
    public class NuevaTransaccionBase : ComponentBase
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
        public List<String> _tipo { get; set; }
        public List<String> _tipoProv { get; set; }
        public List<String> _tipoMvto { get; set; }
        public List<Bodega_data> _listaOrig { get; set; }
        public List<Bodega_data> _listaDest { get; set; }
        public List<TerceroTipo_data> _listaTerc { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }


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
        }




        protected async override Task OnInitializedAsync()
        {
            _mostrarDetalleEncabezado = true;
            _mostrarDetalleProductos = false;
            _resumenDetalle = "...";
            _datoTipoMvto = "M";
            _datoTipo = _datoClase = 0;
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
                    _listaTipo = _dataRequest.entities.Where(w=>w.type==_tipo[1]).ToList();
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
                var resultadoProducto = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlproducto_getall, "");
                ProductosRequest _dataRequestProductos = JsonConvert.DeserializeObject<ProductosRequest>(resultadoProducto.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestProductos != null && _dataRequestProductos.entities != null && _dataRequestProductos.entities.Count > 0)
                    _listaProducto = _dataRequestProductos.entities;
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }


        public async Task Detalle()
        {
            _mostrarDetalleEncabezado = !_mostrarDetalleEncabezado;
        }

        #region Detalle Productos
        public async Task creaEncabezado()
        {
            _mostrarDetalleEncabezado = true;
            _resumenDetalle = "";
            if (_datoTipo != 0)
                _resumenDetalle += " Tipo :"+ _listaTipo.Where(w => w.id == _datoTipo).Select(s => s.name).FirstOrDefault();
            if(_datoBodegaOrig!=0)
                _resumenDetalle += "   Bod Orig :" + _listaOrig.Where(w => w.id == _datoBodegaOrig).Select(s => s.name).FirstOrDefault();
            if (_datoBodegadest != 0)
                _resumenDetalle += "   Bod Dest :" + _listaDest.Where(w => w.id == _datoBodegadest).Select(s => s.name).FirstOrDefault();
            if (_datoTercero != 0)
                _resumenDetalle += "   Prov :" + _listaTerc.Where(w => w.id == _datoTercero).Select(s => s.name).FirstOrDefault();

            _listaDetalleProducto = new List<Transaccion_Producto>();
            _mostrarDetalleProductos = true;
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
            data.costvalue = data.points =  data.quantity = 0;
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
            await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Transaccion_Producto, Dictionary<String, object>> e)
        {
            await setUbicacion(e.Item, false, urlupdate);
        }
        public async Task inactiveFila(Transaccion_Producto item)
        {
            //item.active = !item.active;
            //try
            //{
            //    var resultado = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", urlinactive, item);
            //    TerceroRequest _dataRequest = JsonConvert.DeserializeObject<TerceroRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
            //    if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
            //        item.active = !item.active;
            //}
            //catch (Exception) { item.active = !item.active; }
        }


        private async Task<Int64> setUbicacion(Transaccion_Producto Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            //isok = false;
            //Item.documentoid = Item.iddocumento = _datoPadre;
            //Item.namedocum = _listaSecundaria.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
            //Item.name = Item.name.ToUpper();
            //Item.lastname = Item.lastname.ToUpper();
            //Item.address = Item.address.ToUpper();
            //Item.email = Item.email.ToUpper();
            //Tercero_data reg = Item;
            //datosAdicionales(Crear, ref reg);
            //if (validaDatos(Item))
            //{
            //    var resultadoCode = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
            //    TerceroRequest _dataRequestCode = JsonConvert.DeserializeObject<TerceroRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
            //    if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
            //    {
            //        try
            //        {
            //            var resultado = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", Url, reg);
            //            TerceroRequest _dataRequest = JsonConvert.DeserializeObject<TerceroRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
            //            if (_dataRequest != null && _dataRequest.status != null && _dataRequest.status.code == 200)
            //            {
            //                if (_dataRequest.entity != null && _dataRequest.entity.id > 0)
            //                {
            //                    isok = true;
            //                    retorno = _dataRequest.entity.id;
            //                }
            //            }
            //            else
            //                _Mensaje = _dataRequest.status.message;
            //        }
            //        catch (Exception ex) { _Mensaje = ex.Message; }
            //    }
            //    else
            //        _Mensaje = "Por favor revisar, el código se encuentra duplicado.&s";
            //}
            //StateHasChanged();
            //if (!isok && Crear)
            //    _lista.Remove(reg);            
            return retorno;
        }



        public async Task terminar()
        {
            if (await validaDatos() && _listaDetalleProducto.Count>0)
            {
                foreach(var reg in _listaDetalleProducto)
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
                    
                    
                    nuevo.terceroid = _datoTercero;
                    nuevo.encaorigin = 0;
                    nuevo.typemoviment = _datoTipoMvto; //Mostrador-Domicilio-Web
                    try{
                        nuevo.namepc = System.Net.Dns.GetHostName();
                    }catch { nuevo.namepc = ""; }

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
                        await General.MensajeModal("Transacción", $"Transaccion  de {_listaTipo.Where(w=>w.id== _datoTipo).Select(s=>s.name).FirstOrDefault()}  Número {_dataRequest.entity}. Creada con éxito!!!!",  _modal, _nav, "/transacciones");
                    }
                        
                }
                catch(Exception ex) { }
            }
        }


        public async Task<Boolean> validaDatos()
        {
            _Mensaje = "";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;

        }


        #endregion
    }
}
