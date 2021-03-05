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

namespace OikosGreenPortal.Pages.Intercambio
{
    public class IntercambioBase : ComponentBase
    {
        [Inject] public IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }
        [Inject] public NavigationManager _navigation { get; set; }

        public Boolean _mostrarDetalleEncabezado { get; set; }
        public Boolean _mostrarDetalleProductos { get; set; }
        public String _resumenDetalle { get; set; }
        public Int64 _datoTipo { get; set; }
        public Int64 _datoClase { get; set; }
        public DateTime? _datoFecha { get; set; }
        public Int64 _datoBodegaOrig { get; set; }
        public Int64 _datoBodegadest { get; set; }
        public Int64 _datoProveedor { get; set; }

        public List<Transaccion_data> _envio { get; set; }
        public List<Documento_data> _listaTipo { get; set; }
        public List<Producto_data> _listaProducto { get; set; }
        public List<String> _tipo { get; set; }
        public List<String> _tipoProv { get; set; }
        public List<Bodega_data> _listaOrig { get; set; }
        public List<Bodega_data> _listaDest { get; set; }
        public List<TerceroTipo_data> _listaProv { get; set; }
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
            _mostrarDetalleEncabezado = _mostrarDetalleProductos = false;
            _resumenDetalle = "...";
            _datoTipo = _datoClase = 0;
            _datoFecha = DateTime.Now;
            _envio = new List<Transaccion_data>();

            TipoDocumento tipo = new TipoDocumento();
            _tipo = tipo.tiposDocumentos();
            TipoTerceroTipo tipoUbica = new TipoTerceroTipo();
            _tipoProv = tipoUbica.tiposTerceroTipo();
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
                    _listaProv = _dataRequestProveedor.entities.Where(w => w.type == _tipoProv[0]).ToList();
                //Obtiene Productos
                var resultadoProducto = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlproducto_getall, "");
                ProductosRequest _dataRequestProductos = JsonConvert.DeserializeObject<ProductosRequest>(resultadoProducto.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestProductos != null && _dataRequestProductos.entities != null && _dataRequestProductos.entities.Count > 0)
                    _listaProducto = _dataRequestProductos.entities;
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }



        #region Presentación
        public void estilofila(Transaccion_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Transaccion_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


    }
}
